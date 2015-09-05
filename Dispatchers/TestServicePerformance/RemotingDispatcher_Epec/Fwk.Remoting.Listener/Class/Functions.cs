using System.Diagnostics;

namespace Fwk.Remoting.Listener
{
    public class RemotingHelper
	{
		public static void WriteLog(string pLog, EventLogEntryType pType)
		{
			EventLog.WriteEntry("Fwk.RemotingListenerService", pLog, pType);
		}
	}
}
