using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.RecipeFramework;

namespace Fwk.GuidPk.ValueProviders
{
   
    public class DeveloperValueProvider : ValueProvider
    {
        public override bool OnBeginRecipe(object currentValue, out object newValue)
        {
            if (currentValue != null)
            {
                // Do not assign a new value, and return false to flag that 
                // we don't want the current value to be changed.
                newValue = null;
                return false;
            }
            newValue = Environment.UserName;
            return true;
        }
    }
    public class DateValueProvider : ValueProvider
    {
        public override bool OnBeginRecipe(object currentValue, out object newValue)
        {
            if (currentValue != null)
            {
                // Do not assign a new value, and return false to flag that 
                // we don't want the current value to be changed.
                newValue = null;
                return false;
            }
            newValue = DateTime.Now.ToShortDateString();
            return true;
        }
    }

    /// <summary>
    /// Elimina palabras claves del namespase
    /// </summary>
    public class RootNamespaseProvider : ValueProvider
    {
        public override bool OnBeginRecipe(object currentValue, out object newValue)
        {
            if (currentValue != null)
            {

                newValue = null;
                return false;
            }

                newValue = new object();
            string nms = newValue.ToString();
            nms = nms.Replace(".Backend", String.Empty);
            nms = nms.Replace(".Contract", String.Empty);
            nms = nms.Replace(".backend", String.Empty);
            nms = nms.Replace(".common", String.Empty);
            newValue = nms;
            return true;
        }

        public override bool OnBeforeActions(object currentValue, out object newValue)
        {
            return base.OnBeforeActions(currentValue, out newValue);
        }
    }
}
