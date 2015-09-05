using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Fwk.HelperFunctions;
using System.IO;

namespace Fwk.Bases.FrontEnd.MenuContainer
{
    public partial class MenuItemEditor : FwkUserControlBase
    {
        //const string ImageFilter = "(*.gif;*.jpej)|*.gif;*.jpej";
        //string m_Image_Sel_Extension;
        //string m_Image_Extension;
        private MenuImageList m_MenuImageList;

        [Browsable(false)]
        public MenuImageList MenuImageList
        {
            get { return m_MenuImageList; }
            set { m_MenuImageList = value; }
        }
        /// <summary>
        /// Almacena la acción a realizar por el formulario
        /// </summary>
        Action _ShowAction = Action.Query;

        /// <summary>
        /// Almacena la acción a realizar por el formulario
        /// </summary>
        public Action ShowAction
        {
            get { return _ShowAction; }
            set
            {
                _ShowAction = value;
                String wTitle = String.Empty;
                switch (_ShowAction)
                {
                    case Action.Edit:
                        {
                            wTitle = "Menu updating";
                            EnableControls(true);
                            break;
                        }
                    case Action.New:
                        {
                            wTitle = "Menu creating";
                            EnableControls(true);
                            break;
                        }
                    case Action.Query:
                        {
                            wTitle = "Menu consulting";
                            EnableControls(false);
                            break;
                        }
                }

                lblTitle.Text = wTitle;
                this.Text = wTitle;
            }
        }

        MenuItem _MenuItemSelected;


        public MenuItemEditor()
        {
            InitializeComponent();
        }

       

        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            if (_MenuItemSelected == null) return;
            using (frmImageSelector frm = new frmImageSelector())
            {
                frm.Populate(m_MenuImageList);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBoxImage.Image = frm.SelectedImage;
                    _MenuItemSelected.NodeSelectedImageIndex = frm.SelectedImageIndex;
                }
            }
        //    string imgFile = Helper.OpenFile(ImageFilter);
        //    if (String.IsNullOrEmpty(imgFile)) return;
        //    this.pictureBoxImage.Image = Image.FromFile(imgFile);
        //    m_Image_Extension = System.IO.Path.GetExtension(imgFile);
        }

        private void btnselectedImage_Click(object sender, EventArgs e)
        {
            if (_MenuItemSelected == null) return;
            using (frmImageSelector frm = new frmImageSelector())
            {
                frm.Populate(m_MenuImageList);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBoxImageSelected.Image = frm.SelectedImage;
                    _MenuItemSelected.NodeImageIndex = frm.SelectedImageIndex;
                }
            }
            //string imgFile = Helper.OpenFile(ImageFilter);
            //if (String.IsNullOrEmpty(imgFile)) return;
            //this.pictureBoxImageSelected.Image = Image.FromFile(imgFile);
            // m_Image_Sel_Extension = System.IO.Path.GetExtension(imgFile);
        }

        private void btnAssemblyinfo_Click(object sender, EventArgs e)
        {
            using (frmAssemblyExplorer frm = new frmAssemblyExplorer())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtAssembly.Text = frm.SelectedForm.AssemblyInfo;
                    txtFormName.Text = frm.SelectedForm.FormName;
                }
            }
        }

        /// <summary>
        /// Rellena el Menu item actual .-
        /// </summary>
        public void FillMenuItem()
        {
            if (this.pictureBoxImage.Image != null)
                //_MenuItemSelected.Image = LoadImage(this.pictureBoxImage.Image, m_Image_Extension);
               
            if (this.pictureBoxImageSelected.Image != null)
                //_MenuItemSelected.SelectedImage = LoadImage(this.pictureBoxImageSelected.Image, m_Image_Sel_Extension);
                


            _MenuItemSelected.AssemblyInfo = this.txtAssembly.Text;
            _MenuItemSelected.DisplayName = this.txtDisplayName.Text;
            _MenuItemSelected.FormName = txtFormName.Text;
            _MenuItemSelected.ToolTipInfo = txtToolTipInfo.Text;
            _MenuItemSelected.Enabled = this.checkBoxEnabled.Enabled;

            this.EntityResult = _MenuItemSelected;
        }
        

       

        /// <summary>
        /// Habilita y deshabilita los controles
        /// </summary>
        /// <param name="pEnable"></param>
        void EnableControls(Boolean pEnable)
        {
            txtAssembly.Enabled = pEnable;
            txtDisplayName.Enabled = pEnable;
            txtFormName.Enabled = pEnable;
            txtToolTipInfo.Enabled = pEnable;
            checkBoxEnabled.Enabled = pEnable;
            btnSearchImage.Enabled = pEnable;
            btnSelectedImage.Enabled = pEnable;
            btnAssemblyinfo.Enabled = pEnable;
        }

        /// <summary>
        /// limpia todos los controles
        /// </summary>
        public void ClearControls()
        {
            txtAssembly.Text = String.Empty;
            txtDisplayName.Text = String.Empty;
            txtFormName.Text = String.Empty; 
            txtToolTipInfo.Text = String.Empty; 
            checkBoxEnabled.Enabled = false;
            pictureBoxImageSelected.Image = null;
            pictureBoxImage.Image = null;
            

        }

        /// <summary>
        /// Rellena los valores del menu    
        /// </summary>
        public void Populate()
        {
            if (this.EntityParam == null) return;
            _MenuItemSelected = (MenuItem)this.EntityParam;
           
            this.txtDisplayName.Text = _MenuItemSelected.DisplayName;


            this.txtAssembly.Text = _MenuItemSelected.AssemblyInfo;
            this.txtFormName.Text = _MenuItemSelected.FormName;
            this.txtToolTipInfo.Text = _MenuItemSelected.ToolTipInfo;
            this.checkBoxEnabled.Checked = _MenuItemSelected.Enabled;




            if (_MenuItemSelected.NodeSelectedImage != null)
                this.pictureBoxImageSelected.Image = TypeFunctions.ConvertByteArrayToImage(_MenuItemSelected.NodeSelectedImage);
            else
                pictureBoxImageSelected.Image = null;

            if (_MenuItemSelected.NodeImage != null)
                this.pictureBoxImage.Image = TypeFunctions.ConvertByteArrayToImage(_MenuItemSelected.NodeImage);
            else
                pictureBoxImage.Image = null;
        }

        
    }
}
