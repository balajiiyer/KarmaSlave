using CloudQueueing;
using CloudQueueing.Messages;
using Karma.Powershell;
using KarmaUtil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarmaSlave
{
    public partial class KarmaSlaveUI : Form
    {
        public KarmaSlaveUI()
        {
            InitializeComponent();
        }

        private void InvokeCBAS()
        {
            CBASInteractions cbas = new CBASInteractions();
           string CBASOutput =  cbas.RunCBASCommand();
           Logger.Text = Logger.Text + Utils.FormatLog(CBASOutput);
        }

        private void btn_PollQ_Click(object sender, EventArgs e)
        {
            Logger.Text = Logger.Text + Utils.FormatLog("Checking for new commands...");

            CQClient qClient = new CQClient();
            List<QueueMessage> claimMessages = qClient.ClaimMessages(Utils.Queues.KARMA_DEPLOY_SYD.ToString());

            if (claimMessages == null)
            {
                Logger.Text = Logger.Text + Utils.FormatLog("No messages, waiting...");
               // return;
            }

            Logger.Text = Logger.Text + Utils.FormatLog("Received Deployment Command");

            Logger.Text = Logger.Text + Utils.FormatLog("Received Manifest File");

            Logger.Text = Logger.Text + Utils.FormatLog("Deployment Started");


            InvokeCBAS();


            Logger.Text = Logger.Text + Utils.FormatLog("Deployment Complete");

            PostDeploymentSuccessMessage();

        }

        private void btn_Clear_Log_Click(object sender, EventArgs e)
        {
            Logger.Text = string.Empty;
        }

        /// <summary>
        /// Initiates a deployment message to slave
        /// </summary>
        private void PostDeploymentSuccessMessage()
        {

            KarmaSlaveCommand deploySuccessMessage = new KarmaSlaveCommand();
            deploySuccessMessage.ttl = 300;
            deploySuccessMessage.TimeStamp = Utils.GetCurrentUTCTimeStamp();
            deploySuccessMessage.Action = KarmaSlaveActions.FinishDeployment.ToString();

            List<QueueMessage> lstMessages = new List<QueueMessage>();

            QueueMessage qMessage = new QueueMessage();
            qMessage.body = deploySuccessMessage;

            lstMessages.Add(qMessage);
            CQClient qClient = new CQClient();
            if (qClient.PostMessage(Utils.Queues.KARMA_DEPLOY_SYD.ToString(), lstMessages))
            {
                Logger.Text = Logger.Text + Utils.FormatLog(string.Format(" {0} message sent to {1}", KarmaSlaveActions.FinishDeployment.ToString(), Utils.Queues.KARMA_DEPLOY_SYD.ToString()));
            }

        }
    }
}
