using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Fwk.HelperFunctions;
using System.Drawing.Imaging;

namespace Fwk.Bases.FrontEnd.MenuContainer
{
    internal class Helper
    {

        public static Byte[] LoadImage(Image pImage, string pExtension)
        {
            Byte[] imgByte = null;
            switch (pExtension)
            {
                case "":
                case null:
                case ".jpeg":
                case ".jpg":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Jpeg);

                        break;
                    }
                case ".gif":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Gif);

                        break;
                    }

            }


            return imgByte;
        }
        //public Image GetImageFromFile(imgFile)
        //{


        //    m_PictureBoxImageOnPanel.Image = new Bitmap(imgFile);

        //    flowLayoutPanel1.Controls.Add(m_PictureBoxImageOnPanel);

        //    MenuImage wMenuImage = new MenuImage();
        //    wMenuImage.Index = _MenuImageList.Count + 1;
        //    wMenuImage.Image = LoadImage(m_PictureBoxImageOnPanel.Image, m_Image_Extension);
        //    _MenuImageList.Add(wMenuImage);
        //}
        /// <summary>
        /// Muestra dialog box para abrir el archivo de configuracion
        /// </summary>
        /// <returns>String con el nombre del archivo</returns>
        public  static String OpenFile(string filter)
        {
            using (OpenFileDialog wDialog = new OpenFileDialog())
            {
               // wDialog.DefaultExt = "config";
                wDialog.CheckFileExists = true;
                wDialog.Filter = wDialog.Filter = String.Format("Files {0}|All Files (*.*)|*.*", filter);
                if (wDialog.ShowDialog() == DialogResult.OK) return wDialog.FileName;
                else return String.Empty;
            }


        }
        /// <summary>
        /// Crea uhn nuevo archivo de menu
        /// </summary>
        /// <returns>FullFileName</returns>
        public static String NewFile(IEntity pMenu)
        {
            SaveFileDialog wDialog = new SaveFileDialog();

            wDialog.DefaultExt = "xml";
            wDialog.Filter = "Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (wDialog.ShowDialog() != DialogResult.OK)
                return String.Empty;

           
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(wDialog.FileName, pMenu.GetXml(), false);


            return wDialog.FileName;
        }

        public sealed class WaitCursorHelper : IDisposable
        {
            private Control owner;
            private Cursor previousCursor;

            public WaitCursorHelper(Control owner)
            {
                this.owner = owner;
                this.previousCursor = this.owner.Cursor;
                this.owner.Cursor = Cursors.WaitCursor;
            }

            void IDisposable.Dispose()
            {
                this.owner.Cursor = this.previousCursor;
            }
        }
    }


    /// <summary>
    /// Enumeración que define la accion a realizar por el formulario.
    /// </summary>
    /// <date>2007-07-13T00:00:00</date>
    /// <author>moviedo</author>
    public enum Action
    {

        /// <summary>
        /// Indica que se creará una nueva configuración de servicio.
        /// </summary>
        New,
        /// <summary>
        /// Indica que se editará una configuración de servicio existente.
        /// </summary>
        Edit,
        /// <summary>
        /// Modo consulta.
        /// </summary>
        Query
    }
}
