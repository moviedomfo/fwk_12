using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;

using Fwk.Exceptions;

namespace VivaldiSite
{
    internal static class Helper
    {

        //internal static Color SendedForeColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

        //BordoOscuro
        internal static Color ExpiredForeColorColor = System.Drawing.ColorTranslator.FromHtml("#B22400");
        //Verde loro
        internal static Color RefusedForeColorColor = System.Drawing.ColorTranslator.FromHtml("#006B6B");


        internal static string Get_ModulePath(string path)
        {
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(path);

            if (d.Name.Equals("modules", StringComparison.OrdinalIgnoreCase))
                return path;
            else
            {
                
                return Get_ModulePath(d.Parent.FullName);
                
            }
           
            
            
        }
        /// <summary>
        /// Returns the name of the virtual folder where our project lives
        /// </summary>
        internal static string VirtualFolder
        {
            get { return HttpContext.Current.Request.ApplicationPath; }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string BaseURL
        {
            get
            {
                try
                {
                    return string.Format("http://{0}{1}",
                                         HttpContext.Current.Request.ServerVariables["HTTP_HOST"],
                                         (VirtualFolder.Equals("/")) ? string.Empty : VirtualFolder);
                }
                catch
                {
                    // This is for design time
                    return null;
                }
            }
        }

        internal static void ProcessWebException(Exception ex)
        {
            HttpContext.Current.Session["Error"] = ex;
            HttpContext.Current.Response.Redirect("~/ErrorMessageViewer.aspx");
        }
        internal static void ProcessWebException(string msg)
        {
            
            TechnicalException te = new TechnicalException(msg);
            HttpContext.Current.Session["Error"] = te;
            HttpContext.Current.Response.Redirect("~/ErrorMessageViewer.aspx");
        }
        internal static void ProcessWebException_Security(string msg)
        {

            FunctionalException te = new FunctionalException(msg);
            HttpContext.Current.Session["Error"] = te;
            HttpContext.Current.Response.Redirect("~/ErrorMessageViewer.aspx");
        }
        //internal static void ProcessWebException(ServiceError error)
        //{
        //    HttpContext.Current.Session["Error"] = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(error);
        //    HttpContext.Current.Response.Redirect(@"~/Forms/ErrorMessageViewer.aspx");
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static string GetNewImageDiv(string id,string pclass)
        {
            return string.Format(WebUserControlsConstants.ImageDiv, id,pclass );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id del div q la contiene</param>
        /// <param name="applicationPath_ImgUrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="display"></param>
        /// <param name="title"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        internal static string GetNewImage(string id, string applicationPath_ImgUrl, string width, string height, string display, string title,string tag)
        {
           return  string.Format(WebUserControlsConstants.UrlImageTemplate,
                   title, applicationPath_ImgUrl.Replace("//", "/"),
                    tag, width,height,id);
        }
      

        /// <summary>
        /// Este código se encargará de longitud / anchura en el cambio de tamaño.
        /// </summary>
        /// <param name="originalFile"></param>
        /// <param name="reducedFile"></param>
        /// <param name="lnWidth"></param>
        /// <param name="lnHeight"></param>
        /// <returns></returns>
        internal static void CreateThumbnail(string originalFile, string reducedFile, int newWidth, int newHeight)
        {
            //System.Drawing.Bitmap bmpOut = null;

            using (Bitmap originalBMP = new Bitmap(originalFile))
            {
                ImageFormat originalFormat = originalBMP.RawFormat;
                //decimal lnRatio;
                int wNewWidth = newWidth;
                int wNewHeight = newHeight;
                if (originalBMP.Width <= newWidth && originalBMP.Height <= newHeight)
                {
                    originalBMP.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return;
                }

                //if (originalBMP.Width > originalBMP.Height)
                //{
                //    lnRatio = (decimal)newWidth / originalBMP.Width;
                //    lnNewWidth = newWidth;
                //    decimal lnTemp = originalBMP.Height * lnRatio;
                //    lnNewHeight = (int)lnTemp;
                //}
                //else
                //{
                //    lnRatio = (decimal)newHeight / originalBMP.Height;
                //    lnNewHeight = newHeight;
                //    decimal lnTemp = originalBMP.Width * lnRatio;
                //    lnNewWidth = (int)lnTemp;
                //}

                using (Bitmap bmpOut = new Bitmap(wNewWidth, wNewHeight))
                {
                    Graphics g = Graphics.FromImage(bmpOut);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.FillRectangle(Brushes.White, 0, 0, wNewWidth, wNewHeight);
                    g.DrawImage(originalBMP, 0, 0, wNewWidth, wNewHeight);
                    //loBMP.Dispose();



                    bmpOut.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }



     
    }
    

    internal class WebUserControlsConstants
    {

        public const string NavigateUrl_Admin_CreateRichNews = "~/Modules/Admin/Admin_CreateRichNews.aspx";
        public const string News_ItemList = "~/Modules/Noticias/News_ItemList_Link.ascx";
        public const string News_SimpleView = "~/Modules/Noticias/News_SimpleView.ascx";
        public const string NavigateUrl_NewsFullView = "~/Modules/Noticias/NewsFullView.aspx?id={0}";
        public const string NavigateUrl_RegistrationRequestFullView = "~/Modules/Admin/Admin_RegistrationReq_View.aspx?id={0}";

        public const string NavigateUrl_Admin_NewsUpdate = "~/Modules/Admin/Admin_NewsUpdate.aspx?id={0}";
        public const string NavigateUrl_Home = "~/Index.aspx";
        public const string NavigateUrl_News = "~/Modules/Noticias/News.aspx?t={0}";

        public const string NotAuthorizedUser_Redirect = @"~/modules/Security/NotAuthorizedUser.aspx?id={0}";
        public const string Login_Redirect = @"~/modules/Security/Login.aspx?id={0}";
        public const string CaptchaPageUrl_News = "~/Modules/Security/SecCapt.aspx?t={0}";

        public const string ImgPath = "/store/news";

        public const int ImgWidth_Small = 210;
        public const int ImgHeight_Small = 190;
        public const int ImgWidth_Medium = 450;
        public const int ImgHeight_Medium = 350;



        /// <summary>
        /// {4} id de la imagen coincide c0on el id del div q la contiene
        /// </summary>
        public const string UrlImageTemplate = "<p><img style=\"cursor:pointer;\" width=\"{3}\" height =\"{4}\" onclick=\"javascript:amply(this,'{5}')\" title=\"{0}\" src=\"{1}\" alt=\"{2}\" border=\"0\" /></p>";

        /// <summary>
        /// Obtiene 
        /// </summary>
        public const string ImageDiv = "<div id =\"{0}\" class=\"news_img {1}\">";

        /// <summary>
        /// facebook button Like
        /// {url}
        /// </summary>
        public const string fb_like = "  <fb:like href=\"{0}\" send=\"true\" width=\"450\" show_faces=\"true\" font=\"verdana\"></fb:like>";

        public const string history_line = "<hr class=\"bill_barr\" style =\"width:{0}px\" />";
    }
}
