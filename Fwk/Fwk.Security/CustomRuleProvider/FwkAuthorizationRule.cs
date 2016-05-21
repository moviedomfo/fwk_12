using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Fwk.Bases;
using Fwk.Security.Common;
using System.Xml.Serialization;
using System.Security.Principal;

namespace Fwk.Security
{


    /// <summary>
    /// Represents the configuration data for a
    /// rule that is governed by an AuthorizationRuleData
    /// </summary>
    [Serializable]
    public class FwkAuthorizationRule :Entity,  IAuthorizationRule
    {
        private string _Expression;
        private System.Guid _ApplicationId;
        private System.String _ApplicationName;
        private System.String _Name;

        /// <summary>
        /// 
        /// </summary>
        public System.String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// </summary>
        public FwkAuthorizationRule()
        {
        }


        /// <summary>
        /// Initializes a new instance of the class with the specified name and expression.
        /// </summary>
        /// <param name="name">The name of the rule</param>
        /// <param name="expression">The expression to evaluate.</param>
        public FwkAuthorizationRule(string name, string expression)
           
        {
            _Expression = expression;

        }
        /// <summary>
        /// Initializes a new instance of the AuthorizationRuleData class with the specified name and expression.
        /// </summary>
        /// <param name="name">The name of the rule</param>
        /// <param name="expression">The expression to evaluate.</param>
        /// <param name="applicationId">Apliocacion  la que pertenece.</param>
        public FwkAuthorizationRule(string name, string expression, Guid applicationId)
            
        {
            _Expression = expression;
            _ApplicationId = applicationId;
            _Name = name;

        }
    
        /// <summary>
        /// Gets or sets the expression associated with
        /// this rule.
        /// </summary>
        [ConfigurationProperty("expression", IsRequired = false)]
        public string Expression
        {
            get
            {
                return _Expression;
            }
            set
            {
                _Expression = value;
            }
        }
        int _CategoryId;
        /// <summary>
        /// 
        /// </summary>
        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                _CategoryId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public System.Guid ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.String ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newExpresion"></param>
        public void SetExpression(string newExpresion)
        {
            _Expression = newExpresion;
        }

        int _Id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        string _Description;
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        

        


    }
    /// <summary>
    /// Lista de reglas de autorizacion
    /// </summary>
    [XmlRoot("FwkAuthorizationRuleList"), SerializableAttribute]
    public class FwkAuthorizationRuleList : Entities<FwkAuthorizationRule>
    {
      
    }

    /// <summary>
    /// Categorias de reglass
    /// </summary>
    [XmlInclude(typeof(FwkCategory)), Serializable]
    public class FwkCategory:Entity
    {
        int? _ParentCategoryId =0;

        /// <summary>
        /// 
        /// </summary>
        public int? ParentId
        {
            get { return _ParentCategoryId; }
            set { _ParentCategoryId = value; }
        }
        int _CategoryId;

        /// <summary>
        /// 
        /// </summary>
        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                _CategoryId = value;
            }
        }

        string _Name;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        FwkAuthorizationRuleList _FwkRulesInCategoryList = null;

        /// <summary>
        /// 
        /// </summary>
        public FwkAuthorizationRuleList FwkRulesInCategoryList
        {
            get { return _FwkRulesInCategoryList; }
            set { _FwkRulesInCategoryList = value; }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("FwkCategoryList"), SerializableAttribute]
    public class FwkCategoryList : Entities<FwkCategory>
    {
      
    }


    /// <summary>
    /// Esta clace es una auxiliar de FwkAuthorizationRule con la exepcion de que no  hereda de NamedConfigurationElement
    /// lo que la hace serializable .-
    /// </summary>
    //[XmlInclude(typeof(FwkAuthorizationRuleAux)), Serializable]
    //public class FwkAuthorizationRuleAux : Entity, IAuthorizationRule
    //{
    //    #region Properties
    //    private string _Expression;
    //    private System.Guid _ApplicationId;
    //    private System.String _ApplicationName;
    //    private System.String _Name;
    //    private int _CategoryId;

    //    public System.String Name
    //    {
    //        get { return _Name; }
    //        set { _Name = value; }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string Expression
    //    {
    //        get
    //        {
    //            return _Expression;
    //        }
    //        set
    //        {
    //            _Expression = value;
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public int CategoryId
    //    {
    //        get
    //        {
    //            return _CategoryId;
    //        }
    //        set
    //        {
    //            _CategoryId = value;
    //        }
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public System.Guid ApplicationId
    //    {
    //        get { return _ApplicationId; }
    //        set { _ApplicationId = value; }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public System.String ApplicationName
    //    {
    //        get { return _ApplicationName; }
    //        set { _ApplicationName = value; }
    //    }



    //    int _Id;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public int Id
    //    {
    //        get
    //        {
    //            return _Id;
    //        }
    //        set
    //        {
    //            _Id = value;
    //        }
    //    }
    //    string _Description;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string Description
    //    {
    //        get
    //        {
    //            return _Description;
    //        }
    //        set
    //        {
    //            _Description = value;
    //        }
    //    }
    //    #endregion 

    //    /// <summary>
    //    /// Initializes a new instance of the 
    //    /// <see cref="FwkAuthorizationRuleAux"/> class.
    //    /// </summary>
    //    public FwkAuthorizationRuleAux()
    //    {
    //    }


    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="FwkAuthorizationRuleAux"/> class with the specified name and expression.
    //    /// </summary>
    //    /// <param name="pFwkAuthorizationRule">Framework rule</param>
    //    public FwkAuthorizationRuleAux(FwkAuthorizationRule pFwkAuthorizationRule)
            
    //    {
    //        _ApplicationId = pFwkAuthorizationRule.ApplicationId;
    //        _ApplicationName = pFwkAuthorizationRule.ApplicationName;
    //        _CategoryId = pFwkAuthorizationRule.CategoryId;
    //        _Expression = pFwkAuthorizationRule.Expression;
    //        _Name = pFwkAuthorizationRule.Name;
    //        _Id = pFwkAuthorizationRule.Id;
    //        _Description = pFwkAuthorizationRule.Description;
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the AuthorizationRuleData class with the specified name and expression.
    //    /// </summary>
    //    /// <param name="name">The name of the rule</param>
    //    /// <param name="expression">The expression to evaluate.</param>
    //    public FwkAuthorizationRuleAux(string name, string expression)
            
    //    {
    //        _Expression = expression;
    //        _Name = name;

    //    }
    
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="newExpresion"></param>
    //    public void SetExpression(string newExpresion)
    //    {
    //        _Expression = newExpresion;
    //    }

    //}

    ///// <summary>
    ///// Esta clace es una auxiliar de FwkAuthorizationRuleList con la exepcion de que no  hereda de NamedConfigurationElement
    ///// lo que la hace serializable .-
    ///// </summary>
    //[XmlRoot("FwkAuthorizationRuleAuxList"), SerializableAttribute]
    //public class FwkAuthorizationRuleAuxList:Entities<FwkAuthorizationRuleAux>
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="pFwkAuthorizationRuleList"></param>
    //    public void Populate(FwkAuthorizationRuleList pFwkAuthorizationRuleList)
    //    {
    //        pFwkAuthorizationRuleList.ForEach(a=> this.Add(new  FwkAuthorizationRuleAux(a)));  
    //    }
       

      
    //}


    public interface IAuthorizationRule
    {
        string Expression { get; }
        string Name { get; }
    }
    /// <summary>
    /// Defines the basic functionality of an authorization provider.
    /// </summary>
    public interface IAuthorizationProvider
    {
        /// <summary>
        /// Evaluates the specified authority against the specified context.
        /// </summary>
        /// <param name="principal">Must be an <see cref="IPrincipal"/> object.</param>
        /// <param name="context">Name of the rule to evaluate.</param>
        /// <returns><strong>True</strong> if the expression evaluates to true,
        /// otherwise <strong>false</strong>.</returns>
        bool Authorize(IPrincipal principal, string context);
    }
}