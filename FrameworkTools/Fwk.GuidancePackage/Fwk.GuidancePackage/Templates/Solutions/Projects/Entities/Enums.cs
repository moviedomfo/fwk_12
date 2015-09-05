using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace $safeprojectname$.BE.Enums
{


    public enum MonthsShortName_ES
    {
        ENE = 1,
        FEB = 2,
        MAR = 3,
        ABR = 4,
        MAY = 5,
        JUN = 6,
        JUL = 7,
        AGO = 8,
        SET = 9,
        OCT = 10,
        NOV = 11,
        DIC = 12

    }




    public enum MonthsNames_ES
    {
        Enero = 1,
        Febrero = 2,
        Marzo = 3, Abril = 4, Mayo = 5, Junio = 6, Julio = 7, Agosto = 8,
        Septiembre = 9,
        Octubre = 10,
        Noviembre = 11,
        Diciembre = 12

    }

    /// <summary>
    /// El orden esta asociado al orden que maneja DxExpress para ubicar el correspondiente valor en base 2
    /// SAB	VIE	JUE	MIE	MAR	LUN	DOM
    /// 0   0   0   0   1   0   0
    /// 0   0   0   0   0   0   1
    /// </summary>
    [Serializable]
    [ComVisible(true)]
    public enum DayNamesIndex_ES
    {
        //SAB	VIE	JUE	MIE	MAR	LUN	DOM
        Sabado = 0,
        Viernes = 1,
        Jueves = 2,
        Miercoles = 3,
        Martes = 4,
        Lunes = 5,
        Domingo = 6
    }



    //}
    // Summary:
    //     Lists days and groups of days for recurrence patterns.
    [Serializable]
    [Flags]
    public enum WeekDays_EN
    {
        // Summary:
        //     Specifies Sunday.
        Sunday = 1,
        //
        // Summary:
        //     Specifies Monday.
        Monday = 2,
        //
        // Summary:
        //     Specifies Tuesday.
        Tuesday = 4,
        //
        // Summary:
        //     Specifies Wednesday.
        Wednesday = 8,
        //
        // Summary:
        //     Specifies Thursday.
        Thursday = 16,
        //
        // Summary:
        //     Specifies Friday.
        Friday = 32,
        //
        // Summary:
        //     Specifies work days (Monday, Tuesday, Wednesday, Thursday and Friday).
        WorkDays = 62,
        //
        // Summary:
        //     Specifies Saturday.
        Saturday = 64,
        //
        // Summary:
        //     Specifies Saturday and Sunday.
        WeekendDays = 65,
        //
        // Summary:
        //     Specifies every day of the week.
        EveryDay = 127,
    }


    public enum CommonValuesEnum
    {
        TodosComboBoxValue = -1000,
        VariosComboBoxValue = -2000,
        SeleccioneUnaOpcion = -3000,
        Ninguno = -4000
    }


}
