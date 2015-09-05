using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Fwk.Security;
using System.Security.Principal;

namespace SecurityAppBlock.Use
{
    public partial class RuleProvider_NotFromNotConfigFile : Form
    {
        private IAuthorizationProvider ruleProvider;
        public RuleProvider_NotFromNotConfigFile()
        {
            InitializeComponent();
            Init();
        }

        internal void Init()
        {


            //NamedElementCollection<FwkAuthorizationRule> rules = FwkMembership.GetRules(Membership.Provider.Name);
            //IDictionary<string, IAuthorizationRule> authorizationRules = CreateRulesDictionary(rules);

            Fwk.Security.FwkAuthorizationRuleProvider wFwkAuthorizationRuleProvider = new Fwk.Security.FwkAuthorizationRuleProvider(Membership.Provider.Name);

            ruleProvider = wFwkAuthorizationRuleProvider;

            //Estas reglas podrian venir de un servicio
            rulesComboBox.DataSource = wFwkAuthorizationRuleProvider.GetAuthorizationRules();// FwkMembership.GetRulesList(frmAdmin.Provider.ApplicationName);

        }

        private static IDictionary<string, IAuthorizationRule> CreateRulesDictionary(
           IEnumerable<FwkAuthorizationRule> rulesCollection)
        {
            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();


            foreach (FwkAuthorizationRule ruleData in rulesCollection)
            {
                authorizationRules.Add(ruleData.Name, ruleData);
            }

            return authorizationRules;
        }

        private void authorizeUsingIdentityRoleRulesButton_Click(object sender, EventArgs e)
        {

            if (this.identityTextBox.Text.CompareTo(String.Empty) != 0 && this.rulesComboBox.SelectedIndex != -1)
            {
                string identity = this.identityTextBox.Text;
                string rule = ((IAuthorizationRule)
                    this.rulesComboBox.SelectedItem).Name;

                // Get the roles for the current user and create an IPrincipal
                
                string[] roles = FwkMembership.GetRolesForUser_StringArray(identity, "tesa");
                IPrincipal principal = new GenericPrincipal(new GenericIdentity(identity), roles);



                Cursor = System.Windows.Forms.Cursors.WaitCursor;


                if (this.ruleProvider != null)
                {

                    this.DisplayAuthorizationResults(string.Format(Properties.Resources.IdentityRoleMessage, identity, String.Join(",", roles)));
                    bool wAuthorized = false;
                    // Try to authorize using selected rule
                    try
                    {
                        wAuthorized = this.ruleProvider.Authorize(principal, rule);
                    }
                    catch (Exception ex)
                    {
                        fwkMessageViewInfo.Show(ex);
                    }

                    if (wAuthorized)
                    {

                        this.DisplayAuthorizationResults(string.Format(Properties.Resources.RuleResultTrueMessage, rule) + Environment.NewLine);
                    }
                    else
                    {
                        this.DisplayAuthorizationResults(string.Format(Properties.Resources.RuleResultFalseMessage, rule) + Environment.NewLine);
                    }


                }
                Cursor = System.Windows.Forms.Cursors.Arrow;
            }
        }

        void DisplayAuthorizationResults(string results)
        {
            this.authorizationResultsTextBox.Text += results + Environment.NewLine;

            this.authorizationResultsTextBox.SelectAll();
            this.authorizationResultsTextBox.ScrollToCaret();
        }

        
        
    }
}
