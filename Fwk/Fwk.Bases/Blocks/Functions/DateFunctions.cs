using System;
using System.Data;
using System.Data.SqlTypes;

namespace Fwk.HelperFunctions
{

    /// <summary>
    /// Utilidades para fechas.
    /// </summary>
    public class DateFunctions
    {

        /// <summary>
        /// Valor constante que representa el separador una fecha = 01/01/0001
        /// </summary>
        public static  DateTime NullDateTime { get; set; }

        /// <summary>
        /// Indica el principio de los tiempos  = 01/01/1000
        /// </summary>
        public static  DateTime BeginningOfTimes { get; set; }

        /// <summary>
        /// Indica el fin de los tiempos = 01/01/9999
        /// </summary>
        public static  DateTime EndOfTimes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public enum TimeMeasuresEnum
        {
            /// <summary>
            /// 
            /// </summary>
            FromDays,
            /// <summary>
            /// 
            /// </summary>
            FromHours,
            /// <summary>
            /// 
            /// </summary>
            FromMinutes,
            /// <summary>
            /// 
            /// </summary>
            FromSeconds
        }


        static DateFunctions()
        {
            NullDateTime = new DateTime(1, 1, 1, 0, 0, 0);
            BeginningOfTimes = new DateTime(1000, 1, 1, 0, 0, 0);
            EndOfTimes = new DateTime(9999, 1, 1, 0, 0, 0);
        }
        /// <summary>
        /// Algoritmo que determina si hay o no InterSección entre dos rangos de fechas
        /// </summary>
        /// <param name="D1">Fecha Desde del primer rango</param>
        /// <param name="H1">Fecha Hasta del primer rango</param>
        /// <param name="D2">Fecha Desde del segundo rango</param>
        /// <param name="H2">Fecha Hasta del segundo rango</param>
        /// <returns>Retorna el rango de InterSección en una DataRow un bool que dice si hay o no interseccion</returns>
        /// <Date>29-03-2006</Date>
        /// <Author>moviedo</Author>
        public static DataTable Interseccion(DateTime D1, DateTime H1, DateTime D2, DateTime H2)
        {

            DateTime Dr;
            DateTime Hr;

            bool wInterseccion;

            if (D1 < D2)
            {
                //D1-----------H1
                // D2-------------H2
                if (D2 > H1)
                {
                    Dr = new DateTime(1899, 12, 31);
                    Hr = new DateTime(1899, 12, 31);
                    wInterseccion = false;
                }
                else
                {
                    //D1-----------H1
                    // D2-------------H2
                    if (H1 < H2)
                    {
                        Dr = D2;
                        Hr = H1;
                        wInterseccion = true;
                    }
                    else
                    {
                        //D1--------------------------H1
                        // D2-------------H2
                        Dr = D2;
                        Hr = H2;
                        wInterseccion = true;
                    }
                }
            }
            else
            { // D1-------------H1
                //D2-------------H2
                if (D1 > H2)
                {
                    Dr = new DateTime(1899, 12, 31);
                    Hr = new DateTime(1899, 12, 31);
                    wInterseccion = false;
                }
                else
                {
                    // D1-------------H1
                    //D2-------------H2
                    if (H2 < H1)
                    {
                        Dr = D1;
                        Hr = H2;
                        wInterseccion = true;
                    }
                    else
                    { //D1---------------------------------H1
                        // D2-------------H2
                        Dr = D1;
                        Hr = H1;
                        wInterseccion = true;
                    }
                }
            }
            DataTable wDtt = new DataTable();
            DataColumn wDC = new DataColumn();
            wDC.ColumnName = "Dr";
            wDtt.Columns.Add(wDC);
            wDC = new DataColumn();
            wDC.ColumnName = "Hr";
            wDtt.Columns.Add(wDC);
            wDC = new DataColumn();
            wDC.ColumnName = "Interseccion";
            wDtt.Columns.Add(wDC);
            DataRow wDtr = wDtt.NewRow();
            wDtr["Dr"] = Dr;
            wDtr["Hr"] = Hr;
            wDtr["Interseccion"] = wInterseccion;
            wDtt.Rows.Add(wDtr);
            return wDtt;
        }

        /// <summary>
        /// Retorna un string con el formato hh:mm:ss.-
        /// Por ejemplo si la acantidad de horas se superace en una unidad de 
        /// las 24 horas, el valor retornado es por ejemplo: 26:00:01
        /// </summary>
        /// <param name="pSeconds"></param>
        /// <returns>String con el formato hh:mm:ss</returns>
        /// <Date>18-01-2007</Date>
        /// <Author>moviedo</Author>
        public static string GetHH_MM_SS_FromInt32(Int32 pSeconds)
        {
            Int32 hours = pSeconds / 3600;
            Int32 minutes = (pSeconds - (hours * 3600)) / 60;
            pSeconds = pSeconds - (hours * 3600 + minutes * 60);
            return String.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, pSeconds);
        }

        /// <summary>
        /// Retorna una fecha con dia mes año actual mas el parceo pSeconds a hh:mm:ss
        /// </summary>
        /// <param name="pSeconds"></param>
        /// <returns></returns>
        /// <Date>18-03-2008</Date>
        /// <Author>moviedo</Author>
        public static DateTime GetDateTimeFromSeconds(int pSeconds)
        {
            Int32 hours = pSeconds / 3600;
            Int32 minutes = (pSeconds - (hours * 3600)) / 60;
            pSeconds = pSeconds - (hours * 3600 + minutes * 60);
            DateTime wDatetime = System.DateTime.Today;
            wDatetime.AddHours(hours);
            wDatetime.AddMinutes(minutes);
            wDatetime.AddSeconds(pSeconds);
            return wDatetime;
        }

        /// <summary>
        /// Retorna el 1° día del Mes. Por ejemplo: 01/08/1978 11:59:59
        /// </summary>
        /// <param name="pMonth">Mes del que se desea obtener el primer día</param>
        /// <param name="pYear">Año del que se desea obtener</param>
        /// <returns>DateTime del 1° dia del mes. Por Ej: 01/10/2008 11:59:59</returns>
        /// <Date>15-01-2009</Date>
        /// <Author>Andres Aguirre</Author>
        public static DateTime GetFirstDayOfMonth(Int16 pMonth, Int16 pYear)
        {
            return (new DateTime(pYear, pMonth, 1));
        }

        /// <summary>
        /// Retorna el último dia del Mes. Por Ejemplo: 31/08/2009 11:59:59
        /// </summary>
        /// <param name="pMonth">Mes del que se desea obtener el primer día</param>
        /// <param name="pYear">Año del que se desea obtener</param>
        /// <returns>DateTime del último dia del mes. Por Ej: 31/01/2008 11:59:59</returns>
        /// <Date>15-01-2009</Date>
        /// <Author>Andres Aguirre</Author>
        public static DateTime GetLastDayOfMonth(Int16 pMonth, Int16 pYear)
        {
            DateTime firstDayOfMonth = GetFirstDayOfMonth(pMonth, pYear);

            return firstDayOfMonth.AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Retorna un string con la fecha en formato ISO. Por Ejemplo: 2009-07-14T15:43:25.683
        /// </summary>
        /// <param name="pDateTime">Fecha</param>
        /// <returns>String en formato ISO del DateTime pasado. Por Ej: 2009-07-14T15:43:25.683</returns>
        /// <Date>23-07-2009</Date>
        /// <Author>Marcelo Oviedo</Author>
        public static string ToDateTimeISO(DateTime pDateTime)
        {
            return string.Format("{0:s}", pDateTime);
        }

        /// <summary>
        /// Retorna la fecha en formato YYYY[sep]MM[sep]dd
        /// EJ: 2010_11_02
        /// </summary>
        /// <param name="date"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Get_Year_Mont_Day_String(DateTime date, char separator)
        {
            return date.ToString("yyyy-MM-dd").Replace('-', separator);

        }

        /// <summary>
        /// Detecta si la fecha esta fuera de rango permitido para SQL Server
        /// La fecha debe estar entre 1/1/1753 12:00:00 AM y 12/31/9999 11:59:59 PM."}
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSqlDateTimeOutOverflow(DateTime date)
        {
            //date > MaxValue                                               o  date < MinValue
            return (DateTime.Compare(date, SqlDateTime.MaxValue.Value) > 0) || (DateTime.Compare(date, SqlDateTime.MinValue.Value) < 0);

        }
        /// <summary>
        /// Retorna la fecha en formato YYYY[sep]MM[sep]dd
        /// EJ: 2010_11_02_41_33_1
        /// </summary>
        /// <param name="date"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Get_Year_Mont_Day_Hour_Min_Sec_String(DateTime date, char separator)
        {
            return date.ToString("yyyy-MM-dd hh:mm:ss").Replace('-', separator).Replace(':', separator);

        }
        /// <summary>
        /// Convierte DateTime a UnixTimeStamp (Total acumulado en segundo desde 1-ENE-1970 hasta la fecha pasada por parametros)
        /// The unix time stamp is a way to track time as a running total of seconds. 
        /// This count starts at the Unix Epoch on January 1st, 1970. Therefore, the unix time stamp is merely the number of seconds between a particular date and the Unix Epoch. This is very useful to computer systems for tracking and sorting dated information in dynamic and distributed applications both online and client side.
        /// </summary>
        /// <param name="date">Fehca</param>
        /// <returns>Total acumulado en segundo desde o intervalo de tiempo en segundos  </returns>
        public static Int64 DateTimeToUnixTimeStamp(DateTime date)
        {
            TimeSpan wTimeSpan = date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return Convert.ToInt64(wTimeSpan.TotalSeconds);
        }


        /// <summary>
        /// Convierte UnixTimeStamp a DateTime Retorna la fecha correspondiente de un 
        /// acumulado en segundos desde desde 1-ENE-1970 a su fecha correspondiente
        /// </summary>
        /// <param name="unixTimeStamp">Total acumulado en segundo desde 1-ENE-1970 (intervalo en segundos)</param>
        /// <returns>Fecha</returns>
        public static DateTime UnixTimeStampToDateTime(Int64 unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeStamp);
        }


        /// <summary>
        /// Convierte una fecha long (generalmente proveninte de unix) a datetime
        /// </summary>
        /// <param name="unixDate">Fecha long de unix</param>
        /// <returns></returns>
        public static DateTime UnixLongTimeToDateTime(long unixDate)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(unixDate).ToLocalTime();
        }

        /// <summary>
        /// Converts a DateTime to the long representation which is the number of seconds since the unix epoch.
        /// Epoch (UNIX Epoch time) : It is the number of seconds that have elapsed since 00:00:00 Thursday, 1 January 1970,[2] Coordinated Universal Time (UTC), minus leap seconds. 
        /// </summary>
        /// <param name="dateTime">A DateTime to convert to epoch time.</param>
        /// <returns>The long number of seconds since the unix epoch.</returns>
        public static long ToEpoch(DateTime dateTime)
        {
            return (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
        }


        /// <summary>
        /// Converts a long representation of time since the unix epoch to a DateTime.
        /// </summary>
        /// <param name="epoch">The number of seconds since Jan 1, 1970.
        /// Epoch (UNIX Epoch time) : It is the number of seconds that have elapsed since 00:00:00 Thursday, 1 January 1970,[2] Coordinated Universal Time (UTC), minus leap seconds. </param>
        /// <returns>A DateTime representing the time since the epoch.</returns>
        public static DateTime FromEpoch(long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddSeconds(epoch);
        }


        /// <summary>
        /// Obtiene la edad
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="ageInYears"></param>
        /// <param name="ageInMonths"></param>
        /// <param name="ageInDays"></param>
        /// <returns>Years,Months and Days</returns>
        public static void Get_Age(DateTime birthDate, out int ageInYears, out int ageInMonths, out int ageInDays)
        {
            DateTime dateOfBirth = birthDate;
            DateTime currentDate = DateTime.Now;
            ageInYears = 0;
            ageInMonths = 0;
            ageInDays = 0;
            ageInDays = currentDate.Day - dateOfBirth.Day;
            ageInMonths = currentDate.Month - dateOfBirth.Month;
            ageInYears = currentDate.Year - dateOfBirth.Year;
            if (ageInDays < 0)
            {
                ageInDays += DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                ageInMonths = ageInMonths--;
                if (ageInMonths < 0)
                {
                    ageInMonths += 12;
                    ageInYears--;
                }
            }
            if (ageInMonths < 0)
            {
                ageInMonths += 12;
                ageInYears--;
            }
            //return String.Format("Años {0}, meses {1}, dias {2}", ageInYears, ageInMonths, ageInDays);
        }

        /// <summary>
        /// Retorna fecha con hh:mm:ss  00:00:00
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetStartDateTime(DateTime datetime)
        {
            //            startDate = DateTime.Parse(string.Format("{0} 00:00:00", startDate.ToShortDateString()), CultureInfo.GetCultureInfo("en-US"));
            //          endDate = DateTime.Parse(string.Format("{0} 11:59:59", endDate.ToShortDateString()), CultureInfo.GetCultureInfo("en-US"));

            return new DateTime(datetime.Year, datetime.Month, datetime.Day, 0, 0, 0);
        }

        /// <summary>
        /// Retorna la fecha con hh:mm:ss = 23:59:59
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetEndDateTime(DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day, 23, 59, 59,998);
        }
    }

}