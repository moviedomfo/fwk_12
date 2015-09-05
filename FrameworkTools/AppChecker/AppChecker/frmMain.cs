using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppChecker.Properties;
using AppChecker.core;

namespace AppChecker
{
    public partial class frmMain : Form
    {
        List<ICheckerBase> checkers = new List<ICheckerBase>();
        List<CheckMesage> checkMesageList = new List<CheckMesage>();
        public frmMain()
        {
            InitializeComponent();
            checkMesageBindingSource.DataSource = checkMesageList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Image = Resources.applications_16;

            LoadCheckers();
            foreach (ICheckerBase c in checkers)
            {
                c.Run();
            }

            button1.Image = Resources.play;

            dataGridView1.DataSource = checkMesageList;
        }

        /// <summary>
        /// Carga todos los checkes a ser ejecutados 
        /// </summary>
        void LoadCheckers()
        {

            #region Cargo los checkers por defecto
            LoadChecker(new Check_DoNetFramework());
            LoadChecker(new Check_XP_SPK());
            LoadChecker(new Check_SQLServerAccess());
            #endregion

            #region Cargo los checkers por dinamicos
            CheckersAssemlist list = CheckersAssemlist.Load();
            if (list != null)
            {
                foreach (CheckersAssem assembly in list)
                {
                    try
                    {
                        if (assembly.Enabled)
                        {
                            ICheckerBase checker = (ICheckerBase)Helper.CreateInstance(assembly.Assembly);
                            LoadChecker(checker);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            #endregion
        }
        void LoadChecker(ICheckerBase checker)
        {
           
             checkers.Add(checker);
             checker.StartEvent += new CheckEven(checker_StartEvent);
             checker.MessageEvent += new CheckEven(checker_MessageEvent);
             checker.FinalizeEvent += new CheckEven(checker_FinalizeEvent);
        }

        void checker_FinalizeEvent(CheckMesage pCheckMesage)
        
        {
            checkMesageList.Add( pCheckMesage);
       
        }

        void checker_MessageEvent(CheckMesage pCheckMesage)
        {
            checkMesageList.Add(pCheckMesage);
        
        }

        void checker_StartEvent(CheckMesage pCheckMesage)
        {
            checkMesageList.Add(pCheckMesage);
   
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.BindingContext[this.dataGridView1.DataSource].EndCurrentEdit();
            dataGridView1.Refresh();
            this.dataGridView1.Parent.Refresh();

            dataGridView1.DataSource = checkMesageList;
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Concat("MachineName: ", Environment.MachineName)); 
            str.AppendLine(string.Concat("MachineIp: ", Helper.GetMachineIp())); 
            str.AppendLine(string.Concat("User: ", Environment.UserName));
        

            str.AppendLine(string.Concat("Date: ", System.DateTime.Now));
            str.AppendLine();
            foreach (CheckMesage s in checkMesageList)
            {
                str.AppendLine(s.Message);
            }

            string name = string.Concat (Environment.MachineName , "_",
                System.DateTime.Now.Day.ToString(),"_",
                System.DateTime.Now.Month.ToString(),"_",
                System.DateTime.Now.Year.ToString()
                ); 
            Helper.OpenFileDialog_New(name,str.ToString());
        }
    }
}
