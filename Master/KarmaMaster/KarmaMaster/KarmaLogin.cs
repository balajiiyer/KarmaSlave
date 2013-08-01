using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarmaMaster
{
    public partial class KarmaLogin : Form
    {
        public KarmaLogin()
        {
            InitializeComponent();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string authToken = Karma.CloudAPI.Identity.Identity.Authenticate(txtUserName.Text, txtAPIKey.Text);
            if (string.IsNullOrEmpty(authToken))
            {
                MessageBox.Show("Invalid Credentials. No Karma for you!");
            }
            else
            {
                KarmaUtil.KarmaGlobal.IdentityAuthToken = authToken;
                ManageDeploymentUI deploymentUI = new ManageDeploymentUI();
                deploymentUI.Show();
            }
        }
    }
}
