using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Security.ActiveDirectory;
using Fwk.Security.Properties;
using Fwk.Exceptions;

namespace Fwk.Security
{
    internal static class StaticsValues
    {
        private static List<DomainUrlInfo> _DomainUrlList;
        private static Dictionary<string ,ADWrapper> _ADHelperDictionary ;
        static StaticsValues()
        {
            _ADHelperDictionary = new   Dictionary<string,ADWrapper>();
        }

        /// <summary>
        /// Intenta buscar un objeto <see cref="DomainUrlInfo"/>
        /// Si no lo encuenta lanza una TechnicalException con ErrorId = 4001 
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        internal static DomainUrlInfo Find_DomainUrlInfo(string domainName)
        {
            if (_DomainUrlList == null)
            {
                _DomainUrlList = Fwk.Security.ActiveDirectory.ADWrapper.DomainsUrl_GetList(string.Empty);
            }

            DomainUrlInfo wDomainUrlInfo = _DomainUrlList.Find(p => p.DomainName.Equals(domainName, StringComparison.InvariantCultureIgnoreCase));
            if (wDomainUrlInfo == null)
            {

                TechnicalException te = new TechnicalException(string.Format(Resource.AD_NotExistDomainsURL, domainName));
                te.ErrorId = "4001";
                te.Source = "FwkMembership block";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

            return wDomainUrlInfo;

        }

        /// <summary>
        /// Busca un objeto <see cref="ADWrapper"/> si no lo encuentra intenta crearlo e insertarlo al diccionario.-
        /// La creacion del diccionario se hace para no instanciar cientos de veses la clase ADHelper. ya que esta tarea requiere ,mas uso de CPU que el costo de mantener en memoria 
        /// un diccionario con porcos ADHelper. 
        /// En el mundo reali no existiran gran cantidad de clases ADHelper, pero si muchas quisa cientos de ejecuciones del metodos de autenticacio, q son los que 
        /// crearian instancias de ADHelper.-
        /// </summary>
        /// <param name="domainName">Nombre del dominio</param>
        /// <returns></returns>
        internal static ADWrapper Find_ADHelper(string domainName)
        {
            // Si ADHelper no esta en el diccionario lo intenta agregar
            if(_ADHelperDictionary.ContainsKey(domainName) == false)
            {
                DomainUrlInfo di = StaticsValues.Find_DomainUrlInfo(domainName);
                ADWrapper ad = new Fwk.Security.ActiveDirectory.ADWrapper(di.LDAPPath,di.Usr,di.Pwd);
                _ADHelperDictionary.Add(domainName,ad);
                return ad;
            }

            //Si el codigo pasa por aqui es por que existe
            return _ADHelperDictionary[domainName];
            
          
        }
    }
}
