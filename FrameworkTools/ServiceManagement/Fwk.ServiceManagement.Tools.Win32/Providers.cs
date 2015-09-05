using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fwk.ConfigSection;

namespace Fwk.ServiceManagement.Tools.Win32
{
    public class Provider
    {
        private ServiceProviderElement p;

        public Provider(ServiceProviderElement p)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.ApplicationId = p.ApplicationId;
            this.Name = p.Name;
            this.ProviderType = p.ProviderType;
            this.SourceInfo = p.SourceInfo;

        }
        // Summary:
        //     Identificador de aplicacion para buscarlo en la base de datos

        public string ApplicationId { get; set; }
        //
        // Summary:
        //     Nombre de la regla. Es el identificador de una regla por lo tanto este nombre
        //     no debe repetirse.
        public string Name { get; set; }
        //
        // Summary:
        //     Determina el tipo de origen de la metadata de sercvicios

        public ServiceProviderType ProviderType { get; set; }
        //
        // Summary:
        //     Proveedor de seguridad de usuarios reglas y roles, con la que ocorreran los
        //     servicios
        public string SecurityProviderName { get; set; }
        //
        // Summary:
        //     Archivo contenedor de la configuracion
        public string SourceInfo { get; set; }



    }
}
