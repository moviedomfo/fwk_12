using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;

namespace Fwk.Bases.FrontEnd.MenuContainer.EncuestaMenu
{
    public partial class MenuItemEditorEncuesta : UserControl
    {
        string m_Image_Sel_Extension;
        string m_Image_Extension;
        string m_ImageType_Extension;
        const string ImageFilter = "(*.gif;*.jpg;*.jpeg;*.bmp)|*.gif;*.jpg;*.jpeg;*.bmp";
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

        MenuItemEncuesta _MenuItemSelected;
        [Browsable(false)]
        public MenuItemEncuesta MenuItemSelected
        {
            get { return _MenuItemSelected; }
            set { _MenuItemSelected = value; }
        }

        public MenuItemEditorEncuesta()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Rellena el Menu item actual .-
        /// </summary>
        public void FillMenuItem()
        {
            if (this.pictureBoxImage.Image != null && m_Image_Extension != null)
                _MenuItemSelected.NodeImage = Helper.LoadImage(this.pictureBoxImage.Image, m_Image_Extension);

            if (this.pictureBoxImageSelected.Image != null && m_Image_Sel_Extension != null)
                _MenuItemSelected.NodeSelectedImage = Helper.LoadImage(this.pictureBoxImageSelected.Image, m_Image_Sel_Extension);

            if (this.pictureBoxTypeImage.Image != null && m_ImageType_Extension !=null)
                _MenuItemSelected.TypeImage = Helper.LoadImage(this.pictureBoxTypeImage.Image, m_ImageType_Extension);

            _MenuItemSelected.AssemblyInfo = this.txtAssembly.Text;
            _MenuItemSelected.DisplayName = this.txtDisplayName.Text;
            _MenuItemSelected.FormName = txtFormName.Text;
            _MenuItemSelected.ToolTipInfo = txtToolTipInfo.Text;
            _MenuItemSelected.Enabled = this.checkBoxEnabled.Enabled;
        }


    
        /// <summary>
        /// Rellena los valores del menu    
        /// </summary>
        public void Populate()
        {

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



            if (_MenuItemSelected.TypeImage != null)
                this.pictureBoxTypeImage.Image = TypeFunctions.ConvertByteArrayToImage(_MenuItemSelected.TypeImage);
            else
                pictureBoxTypeImage.Image = null;
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

        private void btnSelImageType_Click(object sender, EventArgs e)
        {
            SelImage(this.pictureBoxTypeImage,ref m_ImageType_Extension);

        }
        private void btnSelectedImage_Click(object sender, EventArgs e)
        {
            SelImage(this.pictureBoxImageSelected, ref m_Image_Extension);
        }
        private void btnImage_Click(object sender, EventArgs e)
        {
            SelImage(this.pictureBoxImage, ref m_Image_Extension);
        }
       
        private void SelImage(PictureBox pPictureBox, ref string pImage_Extension)
        {

            if (_MenuItemSelected == null) return ;
            string imgFile = Helper.OpenFile(ImageFilter);
            if (String.IsNullOrEmpty(imgFile)) return ; 



            pPictureBox.Image = new Bitmap(imgFile);
            pImage_Extension  = System.IO.Path.GetExtension(imgFile);
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
            btnImage.Enabled = pEnable;
            btnSelectedImage.Enabled = pEnable;
            btnAssemblyinfo.Enabled = pEnable;

            btnSelImageType.Enabled = pEnable;
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
            pictureBoxTypeImage.Image = null;

        }

        

      
    }
}
