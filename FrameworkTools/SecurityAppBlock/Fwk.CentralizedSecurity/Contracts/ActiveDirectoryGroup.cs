using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.Security.ActiveDirectory;

namespace Fwk.CentralizedSecurity.Contracts
{
    [Serializable]
    public class ActiveDirectoryGroup
    {

        /// <summary>
        /// Nombre del domijio al que pertenece el grupo
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ejemplos:
        /// CN=GS_Comite_comunicacion_RW,OU=Seguridad,DC=actionlinecba,DC=org
        /// CN=GS_CalidadTP_R,OU=Avanzados,OU=Analistas,OU=Seguridad,DC=actionlinecba,DC=org
        /// </summary>
        public string DistinguishedName { get; set; }
        /// <summary>
        /// Defines the Active Directory Schema category. For example, objectCategory = Person
        /// Ej: CN=Group,CN=Schema,CN=Configuration,DC=actionlinecba,DC=org
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        ///Common Name
        /// </summary>
        public string CN { get; set; }

        /// <summary>
        /// Reprecenta la lista de unidades organizacionales del dominio
        /// OU = Organizational Unit 
        /// </summary>
        public string[] OU { get; set; }


        public ActiveDirectoryGroup()
        {
        }
        public ActiveDirectoryGroup(ADGroup aDGroup)
        {

            this.Category = aDGroup.Category;
            this.CN = aDGroup.CN;
            this.Description = aDGroup.Description;
            this.DistinguishedName = aDGroup.DistinguishedName;
            this.Domain = aDGroup.Domain;
            this.FirstName = aDGroup.FirstName;
            this.OU = aDGroup.OU.ToArray();
        }

    }
}
