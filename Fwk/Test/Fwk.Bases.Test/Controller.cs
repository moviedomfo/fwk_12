using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Bases.Test
{
    internal class Controller
    {
            
        public static ClienteCollectionBE SearchCleintes()
        {
            
            ClienteCollectionBE list = new ClienteCollectionBE();
            ClienteBE client = new ClienteBE();
            client.EntityState = EntityState.Changed;
            client.IdCliente = 100;
            client.Nombre = "Catalina F ";
            client.Apellido = "Oviedo";
            client.Edad = 23;
            client.FechaNacimiento = Convert.ToDateTime("2006-10-18T00:00:00"); //new DateTime(2006,12,18);
            list.Add(client);
            client = new ClienteBE();
            client.EntityState = EntityState.Changed;
            client.IdCliente = 101;
            client.Nombre = "Cleant";
            client.Apellido = "Socrates";
            client.Edad = 32;
            client.FechaNacimiento = new DateTime(1998,12,18);
            list.Add(client);

            client = new ClienteBE();
            client.EntityState = EntityState.Changed;
            client.IdCliente = 102;
            client.Nombre = "Ramon";
            client.Apellido = "sosa";
            client.Edad = 32;
            client.FechaNacimiento = new DateTime(1998, 12, 18);
            list.Add(client);

            return list;
        }
    }
}
