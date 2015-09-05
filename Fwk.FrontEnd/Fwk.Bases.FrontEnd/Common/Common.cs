using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Fwk.AssemblyExplorer;
using System.ComponentModel;
using System.Windows.Forms;


namespace Fwk.Bases.FrontEnd.Controls
{
    public static class Common
    {
        internal static Image GetMessageBoxIcon(MessageBoxIcon _MessageBoxIcon, IconSize pIconSize)
        {
            
            Image imgIcon = null;
            switch (_MessageBoxIcon)
            {
                case MessageBoxIcon.Exclamation:
                case MessageBoxIcon.Warning:
                    {
                       
                        imgIcon = (Image)Fwk.Bases.FrontEnd.ImagesResource.ResourceManager.GetObject(string.Concat("Warning_", (int)pIconSize));
                        
           
                        break;
                    }
                case MessageBoxIcon.Question:
                    {
                  
                        imgIcon = (Image)Fwk.Bases.FrontEnd.ImagesResource.ResourceManager.GetObject(string.Concat("help_", (int)pIconSize));
                       
                        break;
                    }
                case MessageBoxIcon.Error://MessageBoxIcon.Stop --MessageBoxIcon.Hand:
                    {
                       
                        imgIcon = (Image)Fwk.Bases.FrontEnd.ImagesResource.ResourceManager.GetObject(string.Concat("close_", (int)pIconSize));
                        break;
                    }
                case MessageBoxIcon.Information:
                    {
                   
                        imgIcon = (Image)Fwk.Bases.FrontEnd.ImagesResource.ResourceManager.GetObject(string.Concat("sinfo_", (int)pIconSize));
                  
                        break;

                    }
            }
           
            return imgIcon;
        }
       

        
    }
 

    #region--[Enums]--
    public enum ValidationStyle
    {
        NumericInt, NumericDouble, Email, Date
    }
    public enum TextBoxTypeEnum
    {
        Nothing = 0,
        AlphaNumericNotAllowSimbols = 1,
        Numeric = 2,
        NumericDecimal = 3,
        NumericDecimalWhitchPoint = 4,
        Email = 5
    }
    public class ControlChars
    {
        public const string CrLf = "\r\n";
        public const string NewLine = "\r\n";
        public const char Cr = (char)13;
        public const char Lf = (char)10;
        public const char Back = (char)8;
        public const char FormFeed = (char)12;
        public const char Tab = (char)9;
        public const char VerticalTab = (char)11;
        public const char NullChar = (char)0;
        public const char Quote = (char)34;
    }

    public enum GridStyleEnum
    {
        MaroonFlat = 0,
        GreenFlat = 1,
        LightBlueFlat = 2, Custom =3
    }
    
    public enum MessageBoxIcon
    {
        // Summary:
        //     The message box contain no symbols.
        None = 0,
        //
        // Summary:
        //     The message box contains a symbol consisting of white X in a circle with
        //     a red background.
        Error = 16,


        //
        // Summary:
        //     The message box contains a symbol consisting of a question mark in a circle.
        //     The question-mark message icon is no longer recommended because it does not
        //     clearly represent a specific type of message and because the phrasing of
        //     a message as a question could apply to any message type. In addition, users
        //     can confuse the message symbol question mark with Help information. Therefore,
        //     do not use this question mark message symbol in your message boxes. The system
        //     continues to support its inclusion only for backward compatibility.
        Question = 32,
        //
        // Summary:
        //     The message box contains a symbol consisting of an exclamation point in a
        //     triangle with a yellow background.
        Exclamation = 48,
        //
        // Summary:
        //     The message box contains a symbol consisting of an exclamation point in a
        //     triangle with a yellow background.
        Warning = 49,
        //
        // Summary:
        //     The message box contains a symbol consisting of a lowercase letter i in a
        //     circle.
        Information = 64

    }

    public enum IconSize
    {

        /// <summary>
        /// 16x16 pixeles
        /// </summary>
        Small = 16,


        /// <summary>
        ///   24x24 pixeles
        /// </summary>
        Medium = 24,


        /// <summary>
        /// 32x32 pixeles
        /// </summary>
        Large = 32


    }

    
    #endregion
}
