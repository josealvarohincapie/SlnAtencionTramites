using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AtencionTramites.Model.Classes;
using Ultimus.DataAccessLayer;

namespace AtencionTramites.Model.DAL
{
	public class UltimusDAL
	{
		public string ObtenerInitiateID(string PROCESSNAME)
		{
			string ret = null;
			if (new SqlServerDataAccess(new Variables().DbUltimus).GetDataTable("select * from INITIATE where PROCESSNAME = '" + PROCESSNAME + "' order by PROCESSVERSION desc", out var dt) && dt.Rows.Count > 0)
			{
				ret = Convert.ToString(dt.Rows[0]["INITIATEID"]);
			}
			return ret;
		}

		public List<TASKS> ObtenerEtapas(string PROCESSNAME, int INCIDENT)
		{
			List<TASKS> ret = new List<TASKS>();
			if (new SqlServerDataAccess(new Variables().DbUltimus).GetDataTable($"select STEPLABEL, STATUS, STARTTIME, ENDTIME from TASKS where PROCESSNAME = '{PROCESSNAME}' and INCIDENT = {INCIDENT} order by ENDTIME", out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new TASKS
					{
						STEPLABEL = Convert.ToString(dr["STEPLABEL"]).TrimEnd(),
						STATUS = Convert.ToInt32(dr["STATUS"]),
						STARTTIME = Convert.ToDateTime(dr["STARTTIME"]),
						ENDTIME = Convert.ToDateTime(dr["ENDTIME"])
					});
				}
			}
			return ret;
		}

		public List<TASKS> ObtenerIncidentesActivosXEtapa(string PROCESSNAME, string STEPLABEL, string ASSIGNEDTOUSER)
		{
			List<TASKS> ret = new List<TASKS>();
			if (new SqlServerDataAccess(new Variables().DbUltimus).GetDataTable("select INCIDENT, STARTTIME, TASKID from TASKS where PROCESSNAME = '" + PROCESSNAME + "' and STEPLABEL = '" + STEPLABEL + "' and STATUS = 1 " + (string.IsNullOrEmpty(ASSIGNEDTOUSER) ? "" : (" and ASSIGNEDTOUSER = '" + ASSIGNEDTOUSER + "'")), out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new TASKS
					{
						INCIDENT = Convert.ToInt32(dr["INCIDENT"]),
						STARTTIME = Convert.ToDateTime(dr["STARTTIME"]),
						TASKID = Convert.ToString(dr["TASKID"])
					});
				}
			}
			return ret;
		}

		public List<DEPARTMENTS> ObtenerDepartamentos()
		{
			List<DEPARTMENTS> ret = new List<DEPARTMENTS>();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable("select * from DEPARTMENTS where PARENTDEPT = 0 order by NAME", out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new DEPARTMENTS
					{
						ID = Convert.ToInt32(dr["ID"]),
						NAME = Convert.ToString(dr["NAME"]).TrimEnd()
					});
				}
			}
			return ret;
		}

		public DEPARTMENTS ObtenerDepartamento(int ID)
		{
			DEPARTMENTS ret = new DEPARTMENTS();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable($"select * from DEPARTMENTS where ID = {ID}", out var dt) && dt.Rows.Count > 0)
			{
				ret.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				ret.NAME = Convert.ToString(dt.Rows[0]["NAME"]).TrimEnd();
			}
			return ret;
		}

		public DEPARTMENTS ObtenerDepartamentoPorNombre(string NAME)
		{
			DEPARTMENTS ret = new DEPARTMENTS();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable("select * from DEPARTMENTS where NAME = '" + NAME + "'", out var dt) && dt.Rows.Count > 0)
			{
				ret.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				ret.NAME = Convert.ToString(dt.Rows[0]["NAME"]).TrimEnd();
				ret.PARENTDEPT = Convert.ToInt32(dt.Rows[0]["PARENTDEPT"]);
			}
			return ret;
		}

		public List<DEPARTMENTS> ObtenerSubDepartamentos(int PARENTDEPT)
		{
			List<DEPARTMENTS> ret = new List<DEPARTMENTS>();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable($"select * from DEPARTMENTS where PARENTDEPT = {PARENTDEPT} order by NAME", out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new DEPARTMENTS
					{
						ID = Convert.ToInt32(dr["ID"]),
						NAME = Convert.ToString(dr["NAME"]).TrimEnd()
					});
				}
			}
			return ret;
		}

		public DEPARTMENTS ObtenerEntidadUsuario(string NAME)
		{
			DEPARTMENTS ret = new DEPARTMENTS();
			SqlServerDataAccess sqlServerDataAccess = new SqlServerDataAccess(new Variables().DbUltimusOC);
			string query = "  select PARENT.ID, PARENT.NAME from JOBS, DEPARTMENTS, DEPARTMENTS as PARENT WHERE JOBS.DEPTID = DEPARTMENTS.ID AND PARENT.ID = DEPARTMENTS.PARENTDEPT AND JOBS.ISPRIMARY = 1 and JOBS.NAME = '" + NAME + "'";
			if (sqlServerDataAccess.GetDataTable(query, out var dt) && dt.Rows.Count > 0)
			{
				ret.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				ret.NAME = Convert.ToString(dt.Rows[0]["NAME"]).TrimEnd();
			}
			return ret;
		}

		public DEPARTMENTS ObtenerSecretariaUsuario(string NAME)
		{
			DEPARTMENTS ret = new DEPARTMENTS();
			SqlServerDataAccess sqlServerDataAccess = new SqlServerDataAccess(new Variables().DbUltimusOC);
			string query = "select DEPARTMENTS.ID, DEPARTMENTS.NAME from JOBS, DEPARTMENTS WHERE JOBS.DEPTID = DEPARTMENTS.ID AND DEPARTMENTS.PARENTDEPT != 0 AND JOBS.ISPRIMARY = 1 and JOBS.NAME = '" + NAME + "'";
			if (sqlServerDataAccess.GetDataTable(query, out var dt) && dt.Rows.Count > 0)
			{
				ret.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				ret.NAME = Convert.ToString(dt.Rows[0]["NAME"]).TrimEnd();
			}
			return ret;
		}

		public List<JOBS> ObtenerGrupos(int DEPTID)
		{
			List<JOBS> ret = new List<JOBS>();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable($"select * from JOBS where DEPTID = {DEPTID} AND JOBTYPE = 16 order by NAME", out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new JOBS
					{
						ID = Convert.ToInt32(dr["ID"]),
						JOBFUNCTION = Convert.ToString(dr["JOBFUNCTION"]).TrimEnd()
					});
				}
			}
			return ret;
		}

		public JOBS ObtenerUsuario(int ID)
		{
			JOBS ret = new JOBS();
			SqlServerDataAccess sqlServerDataAccess = new SqlServerDataAccess(new Variables().DbUltimusOC);
			string query = $"select * from JOBS where ID = {ID}";
			if (sqlServerDataAccess.GetDataTable(query, out var dt) && dt.Rows.Count > 0)
			{
				ret.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				ret.NAME = Convert.ToString(dt.Rows[0]["NAME"]).TrimEnd();
				ret.FULLNAME = Convert.ToString(dt.Rows[0]["FULLNAME"]).TrimEnd();
				ret.JOBFUNCTION = Convert.ToString(dt.Rows[0]["JOBFUNCTION"]).TrimEnd();
			}
			return ret;
		}

		public List<JOBS> ObtenerUsuarios(string NAME, int? ISPRIMARY)
		{
			List<JOBS> ret = new List<JOBS>();
			SqlServerDataAccess sqlServerDataAccess = new SqlServerDataAccess(new Variables().DbUltimusOC);
			string query = "select * from JOBS where NAME = '" + NAME + "'";
			if (ISPRIMARY.HasValue)
			{
				query += $" and ISPRIMARY = {ISPRIMARY.Value}";
			}
			if (sqlServerDataAccess.GetDataTable(query, out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new JOBS
					{
						ID = Convert.ToInt32(dr["ID"]),
						NAME = Convert.ToString(dr["NAME"]).TrimEnd(),
						FULLNAME = Convert.ToString(dr["FULLNAME"]).TrimEnd(),
						JOBFUNCTION = Convert.ToString(dr["JOBFUNCTION"]).TrimEnd()
					});
				}
			}
			return ret;
		}

		public List<JOBS> ObtenerUsuariosSubordinados(int SUPERVISORID)
		{
			List<JOBS> ret = new List<JOBS>();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable($"select * from JOBS where SUPERVISORID = {SUPERVISORID} order by FULLNAME", out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new JOBS
					{
						ID = Convert.ToInt32(dr["ID"]),
						NAME = Convert.ToString(dr["NAME"]).TrimEnd(),
						FULLNAME = Convert.ToString(dr["FULLNAME"]).TrimEnd(),
						JOBFUNCTION = Convert.ToString(dr["JOBFUNCTION"]).TrimEnd()
					});
				}
			}
			return ret;
		}

		public JOBS ObtenerUsuarioJF(int DEPTID, string JOBFUNCTION)
		{
			JOBS ret = new JOBS();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable($"select * from JOBS where DEPTID = {DEPTID} and JOBFUNCTION = '{JOBFUNCTION}' order by FULLNAME", out var dt) && dt.Rows.Count > 0)
			{
				ret.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				ret.NAME = Convert.ToString(dt.Rows[0]["NAME"]).TrimEnd();
				ret.FULLNAME = Convert.ToString(dt.Rows[0]["FULLNAME"]).TrimEnd();
				ret.JOBFUNCTION = Convert.ToString(dt.Rows[0]["JOBFUNCTION"]).TrimEnd();
			}
			return ret;
		}

		public List<JOBS> ObtenerUsuariosJFG(int DEPTID, string JOBFUNCTION)
		{
			List<JOBS> ret = new List<JOBS>();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable($"select * from JOBS where SUPERVISORID = (select ID from JOBS where DEPTID = {DEPTID} and JOBFUNCTION = '{JOBFUNCTION}') order by FULLNAME", out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new JOBS
					{
						ID = Convert.ToInt32(dr["ID"]),
						FULLNAME = Convert.ToString(dr["FULLNAME"]).TrimEnd()
					});
				}
			}
			return ret;
		}

		public List<JOBS> ObtenerUsuariosGrupo(string GNAME)
		{
			List<JOBS> ret = new List<JOBS>();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable("select m.MEMBERID, m.NAME, m.FULLNAME from GROUPS g, MEMBERS m where g.GID = m.GID and g.NAME = '" + GNAME + "' order by m.FULLNAME", out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new JOBS
					{
						ID = Convert.ToInt32(dr["MEMBERID"]),
						NAME = Convert.ToString(dr["NAME"]).TrimEnd(),
						FULLNAME = Convert.ToString(dr["FULLNAME"]).TrimEnd()
					});
				}
			}
			return ret;
		}

		public List<JOBS> ObtenerUsuarioGrupo(string GNAME, string NAME)
		{
			List<JOBS> ret = new List<JOBS>();
			if (new SqlServerDataAccess(new Variables().DbUltimusOC).GetDataTable("select m.MEMBERID, m.NAME, m.FULLNAME from GROUPS g, MEMBERS m where g.GID = m.GID and g.NAME = '" + GNAME + "' and m.NAME = '" + NAME + "'", out var dt) && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ret.Add(new JOBS
					{
						ID = Convert.ToInt32(dr["MEMBERID"]),
						NAME = Convert.ToString(dr["NAME"]).TrimEnd(),
						FULLNAME = Convert.ToString(dr["FULLNAME"]).TrimEnd()
					});
				}
			}
			return ret;
		}

		public void RemoverUsuario(int ID)
		{
			new SqlServerDataAccess(new Variables().DbUltimusOC).EjecutarQuerys(new List<string> { $"delete top(1) from JOBS where ID = {ID}" }, commit: true);
		}

		public void AgregarUsuario(int DEPTID, int JFGID, string JFGNAME, string NAME, string FULLNAME)
		{
			SqlServerDataAccess SqlServerDataAccess = new SqlServerDataAccess(new Variables().DbUltimusOC);
			List<int> SecuencialList = new List<int>();
			SecuencialList.Add(0);
			List<JOBS> JFGUsuarioList = ObtenerUsuariosSubordinados(JFGID);
			if (JFGUsuarioList != null && JFGUsuarioList.Any())
			{
				foreach (JOBS item in JFGUsuarioList)
				{
					int Secuencial = Convert.ToInt32(item.JOBFUNCTION.Split('-').Last());
					SecuencialList.Add(Secuencial);
				}
			}
			int MaxSecuencial = SecuencialList.Max() + 1;
			string JF = $"{JFGNAME}-{MaxSecuencial}";
			Random rnd = new Random();
			int ID = 0;
			bool GenerarID = true;
			while (GenerarID)
			{
				ID = rnd.Next(int.MinValue, int.MaxValue);
				SqlServerDataAccess.GetDataTable($"select * from JOBS where ID = {ID}", out var dt);
				GenerarID = dt != null && dt.Rows.Count > 0;
			}
			int ISPRIMARY = 1;
			if (ObtenerUsuarios(NAME, 1).FirstOrDefault() != null)
			{
				ISPRIMARY = 0;
			}
			SqlServerDataAccess.EjecutarQuerys(new List<string> { $"insert into JOBS (ID, JOBFUNCTION, NAME, DEPTID, SUPERVISORID, JOBTYPE, ISPRIMARY, FULLNAME) values ({ID}, '{JF}', '{NAME}', {DEPTID}, {JFGID}, 64, {ISPRIMARY}, '{FULLNAME}')" }, commit: true);
		}

		public void AgregarUsuarioGrupo(string GNAME, string NAME, string FULLNAME)
		{
			SqlServerDataAccess SqlServerDataAccess = new SqlServerDataAccess(new Variables().DbUltimusOC);
			if (SqlServerDataAccess.GetDataTable("select g.GID from GROUPS g where g.NAME = '" + GNAME + "'", out var dtG) && dtG.Rows.Count > 0)
			{
				int GID = Convert.ToInt32(dtG.Rows[0]["GID"]);
				Random rnd = new Random();
				int MEMBERID = 0;
				bool GenerarID = true;
				while (GenerarID)
				{
					MEMBERID = rnd.Next(int.MinValue, int.MaxValue);
					SqlServerDataAccess.GetDataTable($"select * from MEMBERS where MEMBERID = {MEMBERID}", out var dt);
					GenerarID = dt != null && dt.Rows.Count > 0;
				}
				SqlServerDataAccess.EjecutarQuerys(new List<string> { $"insert into MEMBERS (MEMBERID, MEMBERTYPE, NAME, FULLNAME, GID) values ({MEMBERID}, 5, '{NAME}', '{FULLNAME}', {GID})" }, commit: true);
			}
		}

		public void RemoverUsuarioGrupo(string GNAME, string NAME)
		{
			SqlServerDataAccess SqlServerDataAccess = new SqlServerDataAccess(new Variables().DbUltimusOC);
			if (SqlServerDataAccess.GetDataTable("select g.GID from GROUPS g where g.NAME = '" + GNAME + "'", out var dtG) && dtG.Rows.Count > 0)
			{
				int GID = Convert.ToInt32(dtG.Rows[0]["GID"]);
				SqlServerDataAccess.EjecutarQuerys(new List<string> { $"delete from MEMBERS where GID = {GID} and NAME = '{NAME}'" }, commit: true);
			}
		}
	}
}
