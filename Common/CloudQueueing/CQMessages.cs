using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudQueueing.Messages
{
    public enum KarmaMasterActions
    {
        InitiateDeployment,
        DownloadManifest,
        TearDown
        
    }
    public enum KarmaSlaveActions
    {
        RequestManifestFile,
        DownloadBits,
        DownloadDatabaseScriptFile,
        DownloadDatabaseRollbackScriptFile,
        PerformConfigTransformations,
        StartDeployment,
        FinishDeployment,
        DownloadBitsError,
        DownloadDatabaseScriptFileError,
        DownloadDatabaseRollbackScriptFileError,
        ConfigTransformationError,
        StartDeploymentError,
        FinishDeploymentError
    }

    public  class KarmaMasterCommand
    {
        public int ttl { get; set; }
        public  string TimeStamp { get; set; }
        public  string CommandId { get; set; }
        public  string Action { get; set; }
        public Object payload { get; set; }

    }

    public class KarmaSlaveCommand
    {
        public int ttl { get; set; }
        public string TimeStamp { get; set; }
        public string SlaveId { get { return "SYD-Slave"; } }
        public string AckCommandId { get; set; }
        public string Action { get; set; }
        public Object payload { get; set; }
    }

    public class QueueMessage
    {
        public QueueMessage()
        {
            body = new object();
        }

        public int ttl { get { return 500; } }
        public Object body { get; set; }
    }
}
