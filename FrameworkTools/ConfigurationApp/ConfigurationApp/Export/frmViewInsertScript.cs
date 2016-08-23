using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd;
using Fwk.ConfigSection;
using Fwk.Configuration.Common;


namespace ConfigurationApp.Export
{
    public partial class frmViewInsertScript : FrmBase
    {
        String insert = "INSERT [dbo].[fwk_ConfigManager] ([ConfigurationFileName], [group], [key], [encrypted], [value]) VALUES (N'{0}', N'{1}', N'{2}', {3}, N'{4}')";
        ConfigurationFile sourceConfigFile = null;
        
        public frmViewInsertScript(System.Collections.Specialized.ListDictionary source)
        {
            InitializeComponent();

            sourceConfigFile = (source["ConfigurationFile"] as ConfigurationFile).Clone<ConfigurationFile>();
            
            txtFileName.Text = sourceConfigFile.FileName;
            txtSQLInserts.TitleVisible = true;


            Build();
        }

        void Build()
        {

            StringBuilder inserts = new StringBuilder();
            foreach (var group in sourceConfigFile.Groups)
            {
                foreach (var key in group.Keys)
                {
                    inserts.AppendLine(String.Format(insert, 
                        sourceConfigFile.FileName, 
                        group.Name, 
                        key.Name, 
                        "0", 
                        key.Value.Text));
                }
            }
            txtSQLInserts.TitleText = sourceConfigFile.FileName;
            txtSQLInserts.Text = inserts.ToString();
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
            if (String.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("file name musn't be empty ");
                txtFileName.Focus();
                return;
            }
            sourceConfigFile.FileName = txtFileName.Text;
            Build();
        }
    }
}