

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;



namespace Fwk.Bases.FrontEnd.Controls.FwkCombo.Design
{
    // This UITypeEditor can be associated with Int32, Double and Single
    // properties to provide a design-mode angle selection interface.
    /// <summary>
    /// Expande las propiedades de la Fwk Grid View
    /// </summary>
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class FwkComboPropertiesEditor : System.Drawing.Design.UITypeEditor
    {
        public FwkComboPropertiesEditor()
        {
           
        }

        // Indicates whether the UITypeEditor provides a form-based (modal) dialog, 
        // drop down dialog, or no UI outside of the properties window.
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.None;
        }

        // Displays the UI for value selection. 
        // Para ver en un User control edSvc.DropDownControl(styleControl);
        // Para ver en un formulario edSvc.ShowDialog(styleForm);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {

            
            // Return the value if the value is not of type Int32, Double and Single.
            //if (value.GetType() != typeof(IFwkCellStyle))
            //    return value;

            // Uses the IWindowsFormsEditorService to display a 
            // drop-down UI in the Properties window.
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                // Display an angle selection control and retrieve the value.
                //StyleControl styleControl = new StyleControl((GridProperties)value);
                //edSvc.DropDownControl(styleControl);
              
                ComboProperties wComboProperties = (ComboProperties)value;

                return wComboProperties;

            }
            
            return value;

        }
      
        // Draws a representation of the property's value.
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {

            int normalX = (e.Bounds.Width / 2);
            int normalY = (e.Bounds.Height / 2);

            //// Fill background and ellipse and center point.
            e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            //e.Graphics.FillEllipse(new SolidBrush(Color.White), e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 3, e.Bounds.Height - 3);
            //e.Graphics.FillEllipse(new SolidBrush(Color.SlateGray), normalX + e.Bounds.X - 1, normalY + e.Bounds.Y - 1, 3, 3);

            //// Draw line along the current angle.
            //double radians = ((double)e.Value * Math.PI) / (double)180;
            //e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Red), 1), normalX + e.Bounds.X, normalY + e.Bounds.Y,
            //    e.Bounds.X + (normalX + (int)((double)normalX * Math.Cos(radians))),
            //    e.Bounds.Y + (normalY + (int)((double)normalY * Math.Sin(radians))));
            //((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            //e.Graphics.DrawImage(global::Fwk.Bases.FrontEnd.Controls.Design.Properties.Resources.sitebuild_icon, new Point());
            Image imgTools = global::Fwk.Bases.FrontEnd.Properties.Resources.tools_small;
            
            e.Graphics.DrawImageUnscaled(imgTools, new Point());
        }

        // Indicates whether the UITypeEditor supports painting a 
         //representation of a property's value.
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
    }

    

    
}