using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;


namespace ConfigurationApp.Common
{
    public class WorkSpace
    {

        private Dictionary<ConfigurationType, UserControl> _GeneratorsList = new Dictionary<ConfigurationType, UserControl>();

        internal void Add(UserControl frm, ConfigurationType pGeneratorsType)
        {
            if (!_GeneratorsList.ContainsKey(pGeneratorsType))
            {
                _GeneratorsList.Add(pGeneratorsType, frm);

            }
        }
        internal void Remove(ConfigurationType pConfigurationType)
        {
            if (_GeneratorsList.ContainsKey(pConfigurationType))
            {
                _GeneratorsList.Remove(pConfigurationType);
            }
        }

        internal Boolean Contains(ConfigurationType pConfigurationType)
        {
            return _GeneratorsList.ContainsKey(pConfigurationType);
        }

    }
}
