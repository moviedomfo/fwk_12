using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Security.Common;

namespace Fwk.Security
{
    /// <summary>
    /// 
    /// </summary>
    public  static class FwkMembershipScripts
    {
        static string _RuleInCategory_i;
        static string _Category_d = "DELETE FROM aspnet_RulesCategory WHERE  aspnet_RulesCategory.CategoryId = [CategoryId]";
        static string _RulesInCategory_d = "DELETE FROM aspnet_RulesInCategory WHERE  aspnet_RulesInCategory.CategoryId = [CategoryId]";
        static string _User_u = "UPDATE aspnet_Users SET  UserName = '[newUserName]',  LoweredUserName = '[loweredNewUserName]'  WHERE (UserName = '[userName]')";
        /// <summary>
        /// 
        /// </summary>
        public static string User_u
        {
            get { return FwkMembershipScripts._User_u; }
            set { FwkMembershipScripts._User_u = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string RuleInCategory_i
        {
            get
            {
                SetRuleInCategory_i();
                return FwkMembershipScripts._RuleInCategory_i;
            }

        }
        static string _Rule_i;
        /// <summary>
        /// 
        /// </summary>
        public static string Rule_i
        {
            get
            {
                SetRule_i(); 
                return FwkMembershipScripts._Rule_i;
            }

        }
        static string _Rule_u;
        /// <summary>
        /// 
        /// </summary>
        public static string Rule_u
        {
            get
            {
                SetRule_u();
                return FwkMembershipScripts._Rule_u;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public static string RulesInCategory_d
        {
            get
            {
                return FwkMembershipScripts._RulesInCategory_d;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public static string Category_d
        {
            get
            {
                return FwkMembershipScripts._Category_d;
            }

        }


        static string _ApplicationId_s;
        /// <summary>
        /// 
        /// </summary>
        public static string ApplicationId_s
        {
            get
            {
                SetApplicationId();
                return FwkMembershipScripts._ApplicationId_s;
            }

        }
        static string _Category_i;
        /// <summary>
        /// 
        /// </summary>
        public static string Category_i
        {
            get
            {
                SetCategory_i();
                return _Category_i;
            }

        }
        static void SetRuleInCategory_i()
        {

            if (string.IsNullOrEmpty(_RuleInCategory_i))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);

                sb.Append(@"	INSERT INTO aspnet_RulesInCategory");
                sb.Append(@"		(CategoryId");
                sb.Append(@"		,RuleId");
                sb.Append(@"		,ApplicationId)");
        

                sb.Append(@"	VALUES (");
                sb.Append(@"		[CategoryId],");
                sb.Append(@"		'[RuleId]',");
          
                sb.Append(@"		CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]')) ");


                _RuleInCategory_i = sb.ToString();
            }


        }
        static void SetCategory_i()
        {

            if (string.IsNullOrEmpty(_Category_i))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);

                sb.Append(@"	INSERT INTO aspnet_RulesCategory");
                sb.Append(@"		(ParentCategoryId");
                sb.Append(@"		,[Name]");
                sb.Append(@"		,ApplicationId)");
   
                sb.Append(@"	VALUES (");
                sb.Append(@"		[ParentCategoryId],");
                sb.Append(@"		'[CategoryName]',");
                sb.Append(@"		CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]')) select @@IDENTITY");


                _Category_i = sb.ToString();
            }


        }

        static void SetApplicationId()
        {
            if (string.IsNullOrEmpty(_ApplicationId_s))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
                sb.Append(@"DECLARE @ApplicationId uniqueidentifier ");
                sb.Append(@"    SELECT  @ApplicationId = NULL ");
                sb.Append(@"    SELECT  @ApplicationId = ApplicationId  ");
                sb.Append(@"    FROM aspnet_Applications WHERE LOWER('[ApplicationName]') = LoweredApplicationName ");
                //sb.Append(@"    IF (@ApplicationId IS NULL) ");
                //sb.Append(@"        RETURN(0) ");
                _ApplicationId_s = sb.ToString();
            }

        }


        static void SetRule_i()
        {

            if (string.IsNullOrEmpty(_Rule_i))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(4000);


                sb.Append(@"	INSERT INTO dbo.aspnet_Rules");
                sb.Append(@"		(expression ");
                sb.Append(@"		,[name]");
                sb.Append(@"		,[Description]");
                sb.Append(@"		,ApplicationId)");
                
                sb.Append(@"	VALUES (");
                sb.Append(@"		'[expression]',");
                sb.Append(@"		'[rulename]',");
                sb.Append(@"		'[description]',");
                sb.Append(@"		 CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]')) ");


                _Rule_i = sb.ToString();
            }

        }
        static void SetRule_u()
        {

            if (string.IsNullOrEmpty(_Rule_u))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);


                sb.Append(@"	UPDATE dbo.aspnet_Rules");
                sb.Append(@"	SET	expression = '[expression]'");
                sb.Append(@"		,[name]= '[rulename]'");
                sb.Append(@"	WHERE [name]= '[rulename]' and ApplicationId = CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]')");
   

                _Rule_u = sb.ToString();
            }

        }

    


    }
}

