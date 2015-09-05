using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Fwk.DataBase.DataEntities;
using Fwk.DataBase;
namespace TestDataBases
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmTest : System.Windows.Forms.Form
	{

        private System.Windows.Forms.Button button1;
        private TreeView tvwChilds;
        private Button button2;
        private Label lblTablesTimeToLoad;
        private Label label1;
        private Button button3;
        private Fwk.DataBase.CustomControls.TreeViewTables treeViewTables1;
        private Button btnCargarTablasEnTtreeViewTables;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Fwk.DataBase.CustomControls.TreeViewStoreProcedures treeViewStoreProcedures1;
        private Label label2;
        private Label lblSPTimeToLoad;
        private TreeView treeView1;
        private Button btnCargarSPs;
        private Fwk.DataBase.CustomControls.CnnDataBaseForm cnnDataBaseForm1;
        private BindingSource treeViewStoreProceduresBindingSource;
        private RichTextBox richTextBox1;
        private Button button4;
        private Button button5;
        private Fwk.DataBase.CustomControls.ConnictionFormComponent connictionFormComponent1;
        private IContainer components;

		public frmTest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.tvwChilds = new System.Windows.Forms.TreeView();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTablesTimeToLoad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCargarTablasEnTtreeViewTables = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeViewTables1 = new Fwk.DataBase.CustomControls.TreeViewTables();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnCargarSPs = new System.Windows.Forms.Button();
            this.lblSPTimeToLoad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeViewStoreProcedures1 = new Fwk.DataBase.CustomControls.TreeViewStoreProcedures();
            this.button4 = new System.Windows.Forms.Button();
            this.cnnDataBaseForm1 = new Fwk.DataBase.CustomControls.CnnDataBaseForm();
            this.treeViewStoreProceduresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.connictionFormComponent1 = new Fwk.DataBase.CustomControls.ConnictionFormComponent(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewStoreProceduresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cargar Tablas";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tvwChilds
            // 
            this.tvwChilds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwChilds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwChilds.CheckBoxes = true;
            this.tvwChilds.FullRowSelect = true;
            this.tvwChilds.Location = new System.Drawing.Point(6, 48);
            this.tvwChilds.Name = "tvwChilds";
            this.tvwChilds.Size = new System.Drawing.Size(193, 305);
            this.tvwChilds.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 22);
            this.button2.TabIndex = 19;
            this.button2.Text = "Cargar Conecction";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTablesTimeToLoad
            // 
            this.lblTablesTimeToLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTablesTimeToLoad.AutoSize = true;
            this.lblTablesTimeToLoad.BackColor = System.Drawing.Color.Yellow;
            this.lblTablesTimeToLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTablesTimeToLoad.Location = new System.Drawing.Point(151, 32);
            this.lblTablesTimeToLoad.Name = "lblTablesTimeToLoad";
            this.lblTablesTimeToLoad.Size = new System.Drawing.Size(22, 13);
            this.lblTablesTimeToLoad.TabIndex = 20;
            this.lblTablesTimeToLoad.Text = "     ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tiempo de carga: (seconds)";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "Cargar SPs";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCargarTablasEnTtreeViewTables
            // 
            this.btnCargarTablasEnTtreeViewTables.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCargarTablasEnTtreeViewTables.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCargarTablasEnTtreeViewTables.Location = new System.Drawing.Point(202, 6);
            this.btnCargarTablasEnTtreeViewTables.Name = "btnCargarTablasEnTtreeViewTables";
            this.btnCargarTablasEnTtreeViewTables.Size = new System.Drawing.Size(109, 23);
            this.btnCargarTablasEnTtreeViewTables.TabIndex = 24;
            this.btnCargarTablasEnTtreeViewTables.Text = "Cargar Tablas";
            this.btnCargarTablasEnTtreeViewTables.UseVisualStyleBackColor = false;
            this.btnCargarTablasEnTtreeViewTables.Click += new System.EventHandler(this.btnCargarTablasEnTtreeViewTables_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(341, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 500);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnCargarTablasEnTtreeViewTables);
            this.tabPage1.Controls.Add(this.lblTablesTimeToLoad);
            this.tabPage1.Controls.Add(this.tvwChilds);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.treeViewTables1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tablas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeViewTables1
            // 
            this.treeViewTables1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeViewTables1.Location = new System.Drawing.Point(202, 35);
            this.treeViewTables1.Name = "treeViewTables1";
            this.treeViewTables1.SelectedTable = null;
            this.treeViewTables1.SelectedTableName = "";
            this.treeViewTables1.Size = new System.Drawing.Size(310, 415);
            this.treeViewTables1.TabIndex = 23;
            this.treeViewTables1.Tablas = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Controls.Add(this.btnCargarSPs);
            this.tabPage2.Controls.Add(this.lblSPTimeToLoad);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.treeViewStoreProcedures1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stores";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(419, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(148, 420);
            this.richTextBox1.TabIndex = 28;
            this.richTextBox1.Text = "j";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.CheckBoxes = true;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(3, 35);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(170, 295);
            this.treeView1.TabIndex = 27;
            // 
            // btnCargarSPs
            // 
            this.btnCargarSPs.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCargarSPs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCargarSPs.Location = new System.Drawing.Point(179, 6);
            this.btnCargarSPs.Name = "btnCargarSPs";
            this.btnCargarSPs.Size = new System.Drawing.Size(109, 23);
            this.btnCargarSPs.TabIndex = 26;
            this.btnCargarSPs.Text = "Cargar SP ";
            this.btnCargarSPs.UseVisualStyleBackColor = false;
            this.btnCargarSPs.Click += new System.EventHandler(this.btnCargarSPs_Click);
            // 
            // lblSPTimeToLoad
            // 
            this.lblSPTimeToLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSPTimeToLoad.AutoSize = true;
            this.lblSPTimeToLoad.BackColor = System.Drawing.Color.Yellow;
            this.lblSPTimeToLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSPTimeToLoad.Location = new System.Drawing.Point(151, 58);
            this.lblSPTimeToLoad.Name = "lblSPTimeToLoad";
            this.lblSPTimeToLoad.Size = new System.Drawing.Size(22, 13);
            this.lblSPTimeToLoad.TabIndex = 25;
            this.lblSPTimeToLoad.Text = "     ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tiempo de carga: (seconds)";
            // 
            // treeViewStoreProcedures1
            // 
            this.treeViewStoreProcedures1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewStoreProcedures1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeViewStoreProcedures1.Location = new System.Drawing.Point(179, 35);
            this.treeViewStoreProcedures1.Name = "treeViewStoreProcedures1";
            this.treeViewStoreProcedures1.SelectedStoreProcedure = null;
            this.treeViewStoreProcedures1.SelectedStoreProcedureName = "";
            this.treeViewStoreProcedures1.Size = new System.Drawing.Size(234, 420);
            this.treeViewStoreProcedures1.StoreProcedures = null;
            this.treeViewStoreProcedures1.TabIndex = 23;
            this.treeViewStoreProcedures1.SelectObjectEvent += new Fwk.DataBase.CustomControls.SelectObjectHandler(this.treeViewStoreProcedures1_SelectObjectEvent);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(23, 296);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(215, 22);
            this.button4.TabIndex = 27;
            this.button4.Text = "DataBaseConection Save Test";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cnnDataBaseForm1
            // 
            this.cnnDataBaseForm1.ButtonsBackColor = System.Drawing.Color.SlateGray;
            this.cnnDataBaseForm1.ButtonsFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cnnDataBaseForm1.ButtonsFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnnDataBaseForm1.ButtonsForeColor = System.Drawing.SystemColors.Info;
            this.cnnDataBaseForm1.LabelsForeColor = System.Drawing.Color.SteelBlue;
            this.cnnDataBaseForm1.Location = new System.Drawing.Point(10, 12);
            this.cnnDataBaseForm1.Name = "cnnDataBaseForm1";
            this.cnnDataBaseForm1.Size = new System.Drawing.Size(329, 217);
            this.cnnDataBaseForm1.TabIndex = 26;
            this.cnnDataBaseForm1.TestBottonVisible = true;
            // 
            // treeViewStoreProceduresBindingSource
            // 
            this.treeViewStoreProceduresBindingSource.DataSource = typeof(Fwk.DataBase.CustomControls.TreeViewStoreProcedures);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(36, 384);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(215, 22);
            this.button5.TabIndex = 28;
            this.button5.Text = "DataBaseConection Clear";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmTest
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(956, 524);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cnnDataBaseForm1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Name = "frmTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewStoreProceduresBindingSource)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmTest());
		}

		private void connectionFornt1_Load(object sender, System.EventArgs e)
		{
			 
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			
		}

        private void button1_Click(object sender, System.EventArgs e)
        {
            DateTime inicio = DateTime.Now;

            Fwk.DataBase.Metadata Metadata = new Metadata();
            Metadata.LoadTables();
            Tables t = Metadata.Tables;

            //TreeNode wTreeNode = new TreeNode(cboTable.SelectedValue.ToString());
            TreeNode wTreeNode = new TreeNode("Tables");
            wTreeNode.Checked = true;
            tvwChilds.Nodes.Add(wTreeNode);

            GenerateChildNodes(wTreeNode, ref t);


            DateTime final = DateTime.Now;
            TimeSpan duracion = final - inicio;
            lblTablesTimeToLoad.Text = duracion.TotalSeconds.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnnDataBaseForm1.InitialiceControl();
        }

        /// <summary>
        /// Genera nodos a partir de la navegaci�n de claves foraneas que referencian a la tabla.
        /// </summary>
        /// <param name="pParentNode">Nodo padre.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>moviedo</author>
        private void GenerateChildNodes(TreeNode pParentNode, ref Tables pTablas)
        {
            string wTableName = string.Empty;
        
            FieldRelationList wRelatedFields;
            try
            {
                if (pParentNode.Nodes.Count == 0)
                {
                 

                    foreach (Table wTabla in pTablas)
                        
                    {
                        TreeNode wTreeNodeTable = AddChildNode(pParentNode, wTabla.Name);

                         wRelatedFields = new FieldRelationList();

                         foreach (Column wColumn in wTabla.Columns)
                        {
                            if (wColumn.IsIdentity)
                            {
                                FieldRelation wRelation = new FieldRelation();

                                wRelation.FieldName = wColumn.Name;
                                wRelation.ParentFieldName = wColumn.Name; 
                                wRelatedFields.Add(wRelation);

                                AddChildNode(wTreeNodeTable, wColumn.Name, wRelatedFields);
                            }
                            else { AddChildNode(wTreeNodeTable, wColumn.Name); }
                           
                        }

                       

                    }

                    pParentNode.Expand();

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// Genera nodos a partir de la navegaci�n de claves foraneas que referencian a la tabla.
        /// </summary>
        /// <param name="pParentNode">Nodo padre.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>moviedo</author>
        private void GenerateChildNodes(TreeNode pParentNode, ref StoreProcedures pStoreProcedures)
        {
            string wSpName = string.Empty;

            FieldRelationList wRelatedFields;
            try
            {
                if (pParentNode.Nodes.Count == 0)
                {


                    foreach (StoreProcedure wStoreProcedure in pStoreProcedures)
                    {
                        TreeNode wTreeNodeStoreProcedure = AddChildNode(pParentNode, wStoreProcedure.Name);

                        wRelatedFields = new FieldRelationList();

                        foreach (SPParameter wParameter in wStoreProcedure.Parameters)
                        {
                             AddChildNode(wTreeNodeStoreProcedure, wParameter.Name); 

                        }



                    }

                    pParentNode.Expand();

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Agrega un nodo a un nodo padre con informaci�n sobre una tabla relacionada a la que �ste representa.
        /// </summary>
        /// <param name="pParentNode">Nodo padre.</param>
        /// <param name="pText">Texto a mostrar.</param>
        /// <param name="pRelatedFields">Lista de relaciones entre campos.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>moviedo</author>
        private TreeNode AddChildNode(TreeNode pParentNode, string pText, FieldRelationList pRelatedFields)
        {
            TreeNode wTreeNode = new TreeNode(pText);

            wTreeNode.Checked   = true;
            wTreeNode.Tag       = pRelatedFields;
            pParentNode.Nodes.Add(wTreeNode);

            return wTreeNode;
        }

        /// <summary>
        /// Agrega un nodo a un nodo padre con informaci�n sobre una tabla relacionada a la que �ste representa.
        /// </summary>
        /// <param name="pParentNode">Nodo padre.</param>
        /// <param name="pText">Texto a mostrar.</param>
        /// <param name="pRelatedFields">Lista de relaciones entre campos.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>moviedo</author>
        private TreeNode AddChildNode(TreeNode pParentNode, string pText)
        {
            TreeNode wTreeNode = new TreeNode(pText);

            wTreeNode.Checked = true;
            wTreeNode.Tag = pText;
            pParentNode.Nodes.Add(wTreeNode);

            return wTreeNode;
        }
        /// <summary>
        /// Destilda los nodos hijos de un nodo padre.
        /// </summary>
        /// <param name="pNode">Nodo padre.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>moviedo</author>
        private void UncheckChildNodes(TreeNode pNode)
        {
            foreach (TreeNode wNode in pNode.Nodes)
            {
                wNode.Checked = false;
                UncheckChildNodes(wNode);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime inicio = DateTime.Now;

            Fwk.DataBase.Metadata Metadata = new Metadata();
            Metadata.LoadStoreProcedures();
            StoreProcedures t = Metadata.StoreProcedures;

            //TreeNode wTreeNode = new TreeNode(cboTable.SelectedValue.ToString());
            TreeNode wTreeNode = new TreeNode("StoreProcedures");
            wTreeNode.Checked = true;
            treeView1.Nodes.Add(wTreeNode);

            GenerateChildNodes(wTreeNode, ref t);


            DateTime final = DateTime.Now;
            TimeSpan duracion = final - inicio;
            //double segundosTotales = duracion.TotalSeconds;
            lblSPTimeToLoad.Text = duracion.Seconds.ToString();

            
        }

        private void btnCargarTablasEnTtreeViewTables_Click(object sender, EventArgs e)
        {
            DateTime inicio = DateTime.Now;

            if (cnnDataBaseForm1.CnnStringChange)
            {
                Metadata m = new Metadata();
                m.LoadTables();
                treeViewTables1.Tablas = m.Tables;
            }
            treeViewTables1.LoadTreeView();
            

            

            
            DateTime final = DateTime.Now;
            TimeSpan duracion = final - inicio;
            lblTablesTimeToLoad.Text = duracion.TotalSeconds.ToString();
        }

        private void btnCargarSPs_Click(object sender, EventArgs e)
        {
            DateTime inicio = DateTime.Now;

            if (cnnDataBaseForm1.CnnStringChange)
            {
                Metadata m = new Metadata();
                m.LoadStoreProcedures();
                treeViewStoreProcedures1.StoreProcedures = m.StoreProcedures;
            }
            treeViewStoreProcedures1.LoadTreeView();

            DateTime final = DateTime.Now;
            TimeSpan duracion = final - inicio;
            lblSPTimeToLoad.Text = duracion.TotalSeconds.ToString();
        }

        private void treeViewStoreProcedures1_SelectObjectEvent()
        {
       richTextBox1 .Text =     treeViewStoreProcedures1.SelectedStoreProcedure.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataBaseConnections _DataBaseConnections = new DataBaseConnections();
            CnnString X1 = new CnnString();
            X1.DataSource = "dddd";
            X1.InitialCatalog = "dddd";
            X1.User = "dddd";
            _DataBaseConnections.Connections.Add(X1);

            _DataBaseConnections.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataBaseConnections _DataBaseConnections = new DataBaseConnections();
            _DataBaseConnections.Clear();
        }

	}
}
