using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dummies.BackendServices;
using Dummies.Core;

namespace UIForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackendServicesClient client = new BackendServicesClient(new Uri("http://localhost:59608/api/"));

            client.ExecuteCommand<string, string>(
                "BmiLibrary"
                , "BmiLibrary"
                , "Service"
                , "CalcBMI"
                , "70,180"
                , r => { MessageBox.Show(r); }
                , (RPCServiceException r) => { MessageBox.Show(r.Message); });

        }
    }
}
