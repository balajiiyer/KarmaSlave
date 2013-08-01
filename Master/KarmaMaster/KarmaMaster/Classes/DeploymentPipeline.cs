using KarmaUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarmaMaster.Classes
{
    //Manages the deployment pipeline
    public class DeploymentPipeline
    {
        public DeploymentPipeline()
        {
            deploymentPipelineStack = new Stack<Utils.DeployableEntity>();
        }

        private Stack<Utils.DeployableEntity> deploymentPipelineStack;

        public Stack<Utils.DeployableEntity> GetDeploymentPipeline()
        {
            return deploymentPipelineStack;
        }

        public void AddToDeploymentPipeline(Utils.DeployableEntity deployableEntity)
        {
            deploymentPipelineStack.Push(deployableEntity);
        }

        public Utils.DeployableEntity GetNextInPipeline()
        {
            return deploymentPipelineStack.Pop();
        }

    }
}
