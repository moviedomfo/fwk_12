using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraNavBar;
using System.Windows.Forms;
using System.Security.Principal;


namespace Fwk.Security.Admin.Controls
{


    internal class ControlsFactory
    {



        internal static bool Authorize(IPrincipal principal, string context)
        {
            if (_SecurityRuleProviderList.Count == 0)
            {
                throw new Exception("Debe crear al menos un proiveedor ");
            }
            if (!_SecurityRuleProviderList.ContainsKey(frmAdmin.Provider.Name))
            {
                throw new Exception(string.Concat("ControlsFactory no contiene el ", frmAdmin.Provider.Name));
            }
            //return AuthorizationFactory.GetAuthorizationProvider(frmAdmin.Provider.Name).Authorize(principal, context);


            return _SecurityRuleProviderList[frmAdmin.Provider.Name].Authorize(principal, context);

        }


        static Dictionary<string, IAuthorizationProvider> _SecurityRuleProviderList = new Dictionary<string, IAuthorizationProvider>();

        internal static IAuthorizationProvider CreateAuthorizationProvider(string providerName)
        {
            FwkAuthorizationRuleProvider wSecurityProvider;
            if (_SecurityRuleProviderList.ContainsKey(providerName))
            {
                wSecurityProvider = (FwkAuthorizationRuleProvider)_SecurityRuleProviderList[providerName];
            }
            else
            {
                wSecurityProvider = new FwkAuthorizationRuleProvider(providerName);
                _SecurityRuleProviderList.Add(providerName, wSecurityProvider);

            }
            return wSecurityProvider;

        }



        static Dictionary<string, SecurityControlBase> _SecurityControlList = new Dictionary<string, SecurityControlBase>();




        internal static SecurityControlBase Get(NavBarItemLink pItem)
        {
            bool isNew;
            return Get(pItem.Item.Tag.ToString(), out isNew);
        }
        /// <summary>
        /// Obtiene el correspondiente mesh, si no existe lo crea
        /// </summary>
        /// <param name="meshId"></param>
        /// <param name="meshName"></param>
        /// <param name="node"></param>
        /// <param name="isNew">Parametro tipo out que determina si el Mesh existia o fue creado.-</param>
        /// <returns>Formulario Mesh</returns>
        internal static SecurityControlBase Get(string pName, out bool isNew)
        {


            isNew = false;

            SecurityControlBase wSecurityControl;
            if (_SecurityControlList.ContainsKey(pName))
            {
                wSecurityControl = (SecurityControlBase)_SecurityControlList[pName];
                isNew = false;
            }
            else
            {
                wSecurityControl = (SecurityControlBase)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(pName);
                _SecurityControlList.Add(pName, wSecurityControl);
                isNew = true;

            }
            return wSecurityControl;
        }

        internal static void RomoveAllControls()
        {

            _SecurityControlList.Clear();
        }

        internal static SecurityControlBase Show(NavBarItemLink pItem, Control pContainer)
        {
            SecurityControlBase wSecurityControl = Get(pItem);

            AddtoPanel(wSecurityControl, pContainer);
            try
            {
                wSecurityControl.Initialize();
            }
            catch (Exception ex)
            {
                pContainer.Controls.Clear();
                throw ex;


            }


            return wSecurityControl;
        }


        static void AddtoPanel(Control pControlToAdd, Control pContainerControl)
        {

            if (!pContainerControl.Contains(pControlToAdd))
            {
                pContainerControl.Controls.Add(pControlToAdd);
                pControlToAdd.Dock = DockStyle.Fill;
                //pContainerControl.Controls.Clear();

            }
            pControlToAdd.Dock = DockStyle.Fill;
            pControlToAdd.BringToFront();
        }
    }
}
