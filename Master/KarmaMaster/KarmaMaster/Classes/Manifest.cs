using KarmaUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarmaMaster.Classes
{
    public class DeploymentManifest
    {
        public Meta manifestMeta { get; set; }
        public ManifestPayload payload { get; set; }

        public DeploymentManifest()
        {
            manifestMeta = new Meta();
            payload = new ManifestPayload();
        }
    }
    public class ManifestPayload
    {   
        public Environment environment { get; set; }
        public Notification notification { get; set; }
        public Build buildInfo { get; set; }
        public DeploymentModules modules { get; set; }

        public ManifestPayload()
        {
            
            environment = new Environment();
            notification = new Notification();
            buildInfo = new Build();
            modules = new DeploymentModules();
        }
       
    }

    public class Meta
    {
        public string ManifestId { get; set; }
        public string TimeStamp { get; set; }
        //Any other deployments / tasks need to be finished before this?
        //Say you want to deploy to Preprod, but you should not until TEST is deployed correctly.
        //Slave will reject this if this is false
        public bool HasDependenciesResolved { get; set; }
        public string Checksum { get; set; }

    }
    public class Environment
    {
        public Environment()
        {
            PostDeploymentTasks = new PostDeploymentTasks();
            PreDeploymentTasks = new PreDeploymentTasks();
        }

        //Environment name this manifest file is for
        public string EnvironmentName { get; set; }
        public string DeployableEntity { get; set; }

        public PostDeploymentTasks PostDeploymentTasks { get; set; }
        public PreDeploymentTasks PreDeploymentTasks { get; set; }

    }

    public class PostDeploymentTasks
    {
        //ToDo: Order
        public bool ExecuteUnitTest { get; set; }
        public bool ExecuteSeleniumtest { get; set; }
        public bool ExecuteFRSTest { get; set; }
    }

    public class PreDeploymentTasks
    {
        //ToDo: Order
        public bool ExecuteUnitTest { get; set; }
        public bool ExecuteSeleniumtest { get; set; }
        public bool ExecuteFRSTest { get; set; }
        
    }

    public class Notification
    {
        public string EmailAddress { get; set; }
        public bool SendOnSuccess { get; set; }
        public bool SendOnFailure { get; set; }
    }

    public class Build
    {
        public Build()
        {
            DatabaseScript = new DBScript();
        }

        //Jenkins build number, typically an integer
        public string BuildNumber { get; set; }

        //Our API version  - like v1.9.02
        public string DeploymentVersion { get; set; }

        //URL for Jenkins builds
        public string JenkinsArtifactUrl { get; set; }

        public DBScript DatabaseScript { get; set; }
        
    }

    public class DBScript
    {
        //Full path to DB script file
        public string DBScriptFileUrl { get; set; }
        public string DBRollbackScriptFileUrl { get; set; }
        public string AuthToken { get; set; }

    }

    public class DeploymentModules
    {
        public string Entity { get; set; }
        public bool HasDBChanges { get; set; }
        
    }
}
