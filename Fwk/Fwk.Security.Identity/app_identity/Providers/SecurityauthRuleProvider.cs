using Fwk.Security;
using Fwk.Security.Identity.ISVC.CheckAuthRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Security.Identity.Providers
{
    public class SecurityauthRuleProvider //: IAuthorizationProvider
    {
        SecurityRuleBEList authorizationRules;
        public SecurityauthRuleProvider(SecurityRuleBEList authorizationRules)
        {
            if (authorizationRules == null)
                throw new ArgumentNullException("authorizationRules");
            this.authorizationRules = authorizationRules;
        }
        public async Task<bool> AuthorizeAsync(IPrincipal principal, string ruleName)
        {


            if (principal == null) throw new ArgumentNullException("principal");
            if (ruleName == null || ruleName.Length == 0) throw new ArgumentNullException("ruleName");

            CheckAuthRuleReq req = new CheckAuthRuleReq();
            req.BusinessData.UserName  = principal.Identity.Name;
            req.BusinessData.ruleName = ruleName;
            CheckAuthRuleRes res = await req.ExecuteServiceAsync<CheckAuthRuleReq, CheckAuthRuleRes>(req);

            if (res.Error != null)
                Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData.IsAuthorized;
        }
        public async Task AuthorizeAsync(IPrincipal principal, RulesAtuorizacionDictionary rules)
        {


            if (principal == null) throw new ArgumentNullException("principal");
            

            CheckAuthRuleReq req = new CheckAuthRuleReq();
            req.BusinessData.rulesDictionary = rules;
            req.BusinessData.UserName = principal.Identity.Name; ;
            CheckAuthRuleRes res = await req.ExecuteServiceAsync<CheckAuthRuleReq, CheckAuthRuleRes>(req);


            if (res.Error != null)
                Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }


    }
}
