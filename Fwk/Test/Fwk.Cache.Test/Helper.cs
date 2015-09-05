using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Fwk.Cache.Test
{
    class Helper
    {

        internal static ClienteCollectionBE GetClienteCollection()
        {
            ClienteCollectionBE wClienteCollectionBE = new ClienteCollectionBE();

            #region crear objetos
            ClienteBE wClienteBE = new ClienteBE();
            Random rnd = new Random();
            wClienteBE.IdCliente = rnd.Next(100000);
            wClienteBE.Nombre = "Marcelo";
            wClienteBE.Apellido = "Oviedo";
            wClienteBE.Edad = 32;
            wClienteBE.FechaNacimiento = System.DateTime.Now;
            wClienteCollectionBE.Add(wClienteBE);

            //wClienteBE = new ClienteBE();

            //wClienteBE.IdCliente = rnd.Next(100000);
            //wClienteBE.Nombre = "Javier";
            //wClienteBE.Apellido = "Oviedo";
            //wClienteBE.Edad = 30;
            //wClienteBE.FechaNacimiento = Convert.ToDateTime("1976-10-18T00:00:00");
            //wClienteCollectionBE.Add(wClienteBE);
            #endregion
            return wClienteCollectionBE;
        }
    }
}
