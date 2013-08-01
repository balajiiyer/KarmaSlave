using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KarmaUtil;
using KarmaMaster.Classes;
using Newtonsoft.Json;
using CloudQueueing;
using CloudQueueing.Messages;
using System.Security.Cryptography;

namespace KarmaMaster
{
    public partial class ManageDeploymentUI : Form
    {
        public ManageDeploymentUI()
        {
            InitializeComponent();
            Logger.Text = Utils.FormatLog("Program Starting..");
           
        }

        private void btn_deploy_Click(object sender, EventArgs e)
        {
            DeploymentPipeline pipeline =  ConstructDeploymentPipeline();

            var ItemsInPipeline = pipeline.GetDeploymentPipeline();

            foreach (Utils.DeployableEntity deployableEntity in ItemsInPipeline)
            {
                //string manifestFile = GenerateManifestFile(Utils.Environments.SYD,deployableEntity);

                //Logger.Text = Logger.Text + Utils.FormatLog(string.Format ("Generating Manifest File for {0} - {1}...",Utils.Environments.SYD,deployableEntity.ToString()));
                //Logger.Text = Logger.Text + Utils.FormatLog(manifestFile);
            }

            //Send down initiate Deployment request
            PostInitiateDeploymentMessage();

            //Post manifest file
            string manifestFile = GenerateManifestFile(Utils.Environments.SYD,Utils.DeployableEntity.API);
            PostManifest(manifestFile);
            Logger.Text = Logger.Text + Utils.FormatLog(manifestFile);

            
        }

        /// <summary>
        /// Constructs the deployment pipeline, order in which actions will be executed
        /// </summary>
        private DeploymentPipeline ConstructDeploymentPipeline()
        {
            DeploymentPipeline deploymentPipeline = new DeploymentPipeline();

            //WinServices is lower priority, add this first, goes to bottom of stack
            if (chk_WinServices.Checked)
            {
                deploymentPipeline.AddToDeploymentPipeline(Utils.DeployableEntity.WinServices);
            }

            if (chk_CP.Checked)
            {
                deploymentPipeline.AddToDeploymentPipeline(Utils.DeployableEntity.CP);
            }

            if (chk_API.Checked)
            {
                deploymentPipeline.AddToDeploymentPipeline(Utils.DeployableEntity.API);
            }

            if (chk_DBChanges.Checked)
            {
                deploymentPipeline.AddToDeploymentPipeline(Utils.DeployableEntity.DBChanges);
            }

            return deploymentPipeline;
        }

        private string GenerateManifestFile(Utils.Environments env, Utils.DeployableEntity deployableEntity)
        {
            DeploymentManifest manifestFile = new DeploymentManifest();

            //Meta
            manifestFile.manifestMeta.HasDependenciesResolved = true;
            manifestFile.manifestMeta.ManifestId = Guid.NewGuid().ToString();
            manifestFile.manifestMeta.TimeStamp = DateTime.UtcNow.ToString("U");
           
            //build info
            manifestFile.payload.buildInfo.BuildNumber = txt_Jenkins_Build_Number.Text.Trim();
            manifestFile.payload.buildInfo.DatabaseScript.DBScriptFileUrl = string.Format("https://storage101.ord1.clouddrive.com/v1/MossoCloudFS_6ed5d516-7294-49e3-9014-311b4d23f1c0/DBScripts/{0}.sql", manifestFile.payload.buildInfo.BuildNumber);
            manifestFile.payload.buildInfo.DatabaseScript.DBRollbackScriptFileUrl = string.Format("https://storage101.ord1.clouddrive.com/v1/MossoCloudFS_6ed5d516-7294-49e3-9014-311b4d23f1c0/DBScripts/Rollback_{0}.sql", manifestFile.payload.buildInfo.BuildNumber);
            manifestFile.payload.buildInfo.DatabaseScript.AuthToken = KarmaGlobal.IdentityAuthToken;
            manifestFile.payload.buildInfo.DeploymentVersion = txt_Deployment_Number.Text.Trim();
            manifestFile.payload.buildInfo.JenkinsArtifactUrl = string.Format("http://jenkins.drivesrvr-dev.com/view/API/job/api-prod-tag/{0}/artifact/syd2/", txt_Jenkins_Build_Number.Text.Trim());

            //env details
            manifestFile.payload.environment.EnvironmentName = env.ToString();

            //Predeployment Tasks
            manifestFile.payload.environment.PreDeploymentTasks.ExecuteFRSTest = true;
            manifestFile.payload.environment.PreDeploymentTasks.ExecuteSeleniumtest = true;
            manifestFile.payload.environment.PreDeploymentTasks.ExecuteUnitTest = true;
            //post deployment tasks
            manifestFile.payload.environment.PostDeploymentTasks.ExecuteFRSTest = true;
            manifestFile.payload.environment.PostDeploymentTasks.ExecuteSeleniumtest = true;
            manifestFile.payload.environment.PostDeploymentTasks.ExecuteUnitTest = true;

            manifestFile.payload.modules.HasDBChanges = chk_DBChanges.Checked;
            manifestFile.payload.environment.DeployableEntity = deployableEntity.ToString();

            //notification options
            manifestFile.payload.notification.EmailAddress = txt_Email.Text.Trim();
            manifestFile.payload.notification.SendOnFailure = true;
            manifestFile.payload.notification.SendOnSuccess = true;

            //modules
            manifestFile.payload.modules.Entity = deployableEntity.ToString();

            string serializedManifestPayload = JsonConvert.SerializeObject(manifestFile.payload);
            manifestFile.manifestMeta.Checksum = Utils.ComputeMD5Hash(serializedManifestPayload);

            return JsonConvert.SerializeObject(manifestFile);

        }

        /// <summary>
        /// Initiates a deployment message to slave
        /// </summary>
        private void PostInitiateDeploymentMessage()
        {
            
            KarmaMasterCommand initiateCommand = new KarmaMasterCommand();
            initiateCommand.ttl = 300;
            initiateCommand.TimeStamp = Utils.GetCurrentUTCTimeStamp();
            initiateCommand.CommandId = Guid.NewGuid().ToString();
            initiateCommand.Action = KarmaMasterActions.InitiateDeployment.ToString();

            List<QueueMessage> lstMessages = new List<QueueMessage>();
            
            QueueMessage qMessage = new QueueMessage();
            qMessage.body = initiateCommand;

            lstMessages.Add(qMessage);
            CQClient qClient = new CQClient();
            if (qClient.PostMessage(Utils.Queues.KARMA_DEPLOY_SYD.ToString(), lstMessages))
            {
                Logger.Text = Logger.Text + Utils.FormatLog(string.Format(" {0} Command Sent to {1}", KarmaMasterActions.InitiateDeployment.ToString(), Utils.Queues.KARMA_DEPLOY_SYD.ToString()));
            }
            
        }

        /// <summary>
        /// Posts manifest file
        /// </summary>
        private void PostManifest(string manifestFileContents)
        {
            KarmaMasterCommand manifestCommand = new KarmaMasterCommand();
            manifestCommand.ttl = 300;
            manifestCommand.TimeStamp = Utils.GetCurrentUTCTimeStamp();
            manifestCommand.CommandId = Guid.NewGuid().ToString();
            manifestCommand.Action = KarmaMasterActions.DownloadManifest.ToString();
            manifestCommand.payload = manifestFileContents;

            List<QueueMessage> lstMessages = new List<QueueMessage>();

            QueueMessage qMessage = new QueueMessage();
            qMessage.body = manifestCommand;

            lstMessages.Add(qMessage);
            CQClient qClient = new CQClient();
            if (qClient.PostMessage(Utils.Queues.KARMA_DEPLOY_SYD.ToString(), lstMessages))
            {
                Logger.Text = Logger.Text + Utils.FormatLog(string.Format(" {0} Command Sent to {1}", KarmaMasterActions.DownloadManifest.ToString(), Utils.Queues.KARMA_DEPLOY_SYD.ToString()));
            }
        }

        private void btn_Clear_logs_Click(object sender, EventArgs e)
        {
            Logger.Text = string.Empty;
        }

        private void btn_Poll_Q_Click(object sender, EventArgs e)
        {
            Logger.Text = Logger.Text + Utils.FormatLog("Checking for new messages...");

            CQClient qClient = new CQClient();
            List<QueueMessage> claimMessages = qClient.ClaimMessages(Utils.Queues.KARMA_DEPLOY_SYD.ToString());

            if (claimMessages == null)
            {
                Logger.Text = Logger.Text + Utils.FormatLog("No messages, waiting...");
                return;
            }

            Logger.Text = Logger.Text + Utils.FormatLog(string.Format ("{0} message(s) received...", claimMessages.Count));

        }

    }
}
