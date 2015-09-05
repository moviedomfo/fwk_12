using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd;
using Fwk.ConfigSection;
using System.Collections;
using Fwk.Configuration.Common;

namespace ConfigurationApp
{
    public partial class frmExport1 : FrmBase
    {
        
        public frmExport1()
        {
            InitializeComponent();
            Init();
            
        }
       
        void Init()
        {



            IEnumerable<ConfigProviderElement> l = Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.OfType<ConfigProviderElement>();

            var lista = from s in l select s.Name;
            source.DataSource = lista.ToList<string>();
            source.SelectedItem = 0;
            source.Refresh();

            dest.DataSource = lista.ToList<string>();
            dest.SelectedItem = 1;
            dest.Refresh(); 
            btnOk.Enabled = true;
        }

        private void source_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!init)
            //{
                provider1.Populate(Fwk.Configuration.ConfigurationManager.ConfigProvider.GetProvider(source.Text));
            //}
        }

        private void dest_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!init)
            //{
               

                provider2.Populate(Fwk.Configuration.ConfigurationManager.ConfigProvider.GetProvider(dest.Text));
               
            //}

           
        }



        void Expòrt()
        {
            bool wHasErrors = false;
            if (dest.SelectedItem.ToString().Equals(source.SelectedItem.ToString()))
            {
                base.MessageViewer.Show("The providers, source and destination must be diferents");
                return;
            }
            ConfigurationFile sourceConfigFile = null;
            StringBuilder log = new StringBuilder();
            try
            {
                sourceConfigFile = Fwk.Configuration.ConfigurationManager.GetConfigurationFile(source.Text);
            }
            catch (Exception te)
            {
                log.AppendLine(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(te));
                textBox1.Text = log.ToString();
                wHasErrors = true;

            }

            if (!wHasErrors)
            {
                foreach (Group g in sourceConfigFile.Groups)
                {
                    try
                    {

                        Fwk.Configuration.ConfigurationManager_CRUD.AddGroup(dest.Text, g);
                        log.AppendLine(string.Concat("grupo : ", g.Name, " OK"));

                    }
                    catch (Fwk.Exceptions.TechnicalException te)
                    {
                        if (te.ErrorId.Equals("7002"))
                            log.AppendLine(string.Concat("grupo : ", g.Name, " already exist"));
                        else
                            log.AppendLine(string.Concat("grupo : ", g.Name, Fwk.Exceptions.ExceptionHelper.GetAllMessageException(te)));
                        wHasErrors = true;
                    }

                }
            }
            textBox1.Text = log.ToString();
            if (wHasErrors)
                this.MessageViewer.Show("Export terminated with warnings or errors!! ");
            else
                this.MessageViewer.Show("Export terminated successfully !! ");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnOk.Enabled)
                this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            Expòrt();
         
            btnCancel.Text = "Exit";

         
        }

    }
}
