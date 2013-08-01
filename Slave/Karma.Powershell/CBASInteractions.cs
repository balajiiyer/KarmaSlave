using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel; 


namespace Karma.Powershell
{
    public class CBASInteractions
    {
        public string RunCBASCommand()
        {
            const string CBASCOMMAND = "dc api all";

            InitialSessionState initialSession = InitialSessionState.CreateDefault();
            initialSession.ImportPSModule(new[] { @"C:\CBAS\modules\ps\CBAS.psm1" });
            Runspace runspace = RunspaceFactory.CreateRunspace(initialSession);

            // open it
            runspace.Open();

            // create a pipeline and feed it the script text
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(CBASCOMMAND);

            // add an extra command to transform the script output objects into nicely formatted strings
            // remove this line to get the actual objects that the script returns. For example, the script
            // "Get-Process" returns a collection of System.Diagnostics.Process instances.
            pipeline.Commands.Add("Out-String");

            // execute the script
            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace
            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            //result of command execution
            return stringBuilder.ToString();

        }

    }
}
