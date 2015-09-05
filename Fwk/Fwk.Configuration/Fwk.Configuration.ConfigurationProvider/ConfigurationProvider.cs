using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace Fwk.ConfigurationProvider
{
	partial class ConfigurationProvider : ServiceBase
	{
		public ConfigurationProvider()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			RemotingConfiguration.Configure(@AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
		}

		protected override void OnStop()
		{
			foreach (IChannel wChannel in ChannelServices.RegisteredChannels)
			{
				ChannelServices.UnregisterChannel(wChannel);
			}
		}
	}
}
