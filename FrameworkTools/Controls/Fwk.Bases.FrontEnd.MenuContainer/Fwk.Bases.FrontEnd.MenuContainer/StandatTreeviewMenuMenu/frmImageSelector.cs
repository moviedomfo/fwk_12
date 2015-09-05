using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using System.Drawing.Imaging;

namespace Fwk.Bases.FrontEnd.MenuContainer
{
    public partial class frmImageSelector : Form
    {
        PictureBox m_PictureBoxImageOnPanel =null;
        const string ImageFilter = "(*.gif;*.jpej)|*.gif;*.jpej";
        string m_Image_Extension;
        MenuImageList _MenuImageList = null;

        Image _SelectedImage;
        [Browsable(false)]
        public Image SelectedImage
        {
            get { return _SelectedImage; }
            set { _SelectedImage = value; }
        }
        int _SelectedImageIndex;
        [Browsable(false)]
        public int SelectedImageIndex
        {
            get { return _SelectedImageIndex; }
            set { _SelectedImageIndex = value; }
        }


        public frmImageSelector()
        {
            InitializeComponent();
        }

        private void btnSearchImage_Click(object sender, EventArgs e)
        {

            string imgFile = Helper.OpenFile(ImageFilter);
            if (String.IsNullOrEmpty(imgFile)) return;
            //this.pictureBoxImage.Image = Image.FromFile(imgFile);
            addPicture(imgFile);


            m_Image_Extension = System.IO.Path.GetExtension(imgFile);

           

        }

        public void Populate(MenuImageList pMenuImageList)
        {
            _MenuImageList = pMenuImageList;

            foreach (MenuImage wMenuImage in pMenuImageList)
            {

            }

        }
      

        void addPicture(string imgFile)
        {
          
            m_PictureBoxImageOnPanel = new PictureBox();
            m_PictureBoxImageOnPanel.Click += new EventHandler(pictureBoxImage_Click);

            m_PictureBoxImageOnPanel.Image = new Bitmap(imgFile);

            flowLayoutPanel1.Controls.Add(m_PictureBoxImageOnPanel);

            MenuImage wMenuImage = new MenuImage();
            wMenuImage.Index = _MenuImageList.Count + 1;
            wMenuImage.Image = Helper.LoadImage(m_PictureBoxImageOnPanel.Image, m_Image_Extension);
            _MenuImageList.Add(wMenuImage);


        }

        void pictureBoxImage_Click(object sender, EventArgs e)
        {
            if (m_PictureBoxImageOnPanel != null)
                m_PictureBoxImageOnPanel.BorderStyle = BorderStyle.FixedSingle;
            PictureBox wPictureBox = (PictureBox)sender;
            wPictureBox.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBoxImageSelected.Image = wPictureBox.Image;

            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
