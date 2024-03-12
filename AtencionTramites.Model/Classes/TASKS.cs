using System;

namespace AtencionTramites.Model.Classes
{
	public class TASKS
	{
		public string PROCESSNAME { get; set; }

		public int INCIDENT { get; set; }

		public string STEPLABEL { get; set; }

		public int STATUS { get; set; }

		public DateTime STARTTIME { get; set; }

		public DateTime ENDTIME { get; set; }

		public string TASKID { get; set; }
	}
}
