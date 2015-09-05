using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace Fwk.Configuration.ConfigurationProvider
{
	[RunInstaller(true)]
	public partial class ConfigurationProviderInstaller : Installer
	{
		public ConfigurationProviderInstaller()
		{
			InitializeComponent();
		}
     }
}