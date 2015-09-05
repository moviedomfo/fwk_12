using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.Admin
{
    public class CategoryTreeList : Fwk.Bases.Entities<CategoryTree>
    {
        public static CategoryTreeList Retrive_CategoryTreeList(FwkCategoryList pFwkCategoryList)
        {
            CategoryTreeList list = new CategoryTreeList();
    
            var wCategoryTreeList = from p in pFwkCategoryList select new CategoryTree(p);


            foreach (CategoryTree category in wCategoryTreeList)
            {
            
                list.Add((CategoryTree)category.Clone());

                CategoryTree rule = null;
                foreach (FwkAuthorizationRule r in category.FwkCategory.FwkRulesInCategoryList)
                {
                    rule = new CategoryTree();
                    rule.Name = r.Name.Trim();
                    rule.IsCategory = false;
                    rule.ParentId = category.Id;
                    rule.Id = string.Concat(category.Id, "_", r.Name.Trim());
                    rule.FwkAuthorizationRule = r;
                    list.Add(rule);
                }
               
            }
            return list;
        }

        internal void RemoveItem(string pId)
        {
            var r = this.Where(p => p.Id.Equals(pId)).FirstOrDefault();
            this.Remove(r);
        }
    }
    public class CategoryTree : Fwk.Bases.Entity
    {
        public CategoryTree(FwkCategory pFwkCategory)
        {
            //Rules = new List<CategoryTree>();
            this.FwkCategory = pFwkCategory;
            this.Id = pFwkCategory.CategoryId.ToString();

            this.Name = pFwkCategory.Name;
            if (pFwkCategory.ParentId.HasValue)
                ParentId = pFwkCategory.ParentId.Value.ToString();
            else
                ParentId = "0";

            //if (pFwkCategory.FwkRulesInCategoryList != null)
            //{

            //    CategoryTree rule = null;
            //    foreach (FwkAuthorizationRule r in pFwkCategory.FwkRulesInCategoryList)
            //    {
            //        rule = new CategoryTree();
            //        rule.Name = r.Name.Trim();
            //        rule.ParentId = this.Id;
            //        rule.Id = string.Concat(this.Id, "_", r.Name.Trim());
            //        rule.IsCategory = false;
            //        this.Rules.Add(rule);
            //    }
            //}
        }
        public CategoryTree()
        {
            
        }

        public CategoryTree AddRule(FwkAuthorizationRule pFwkAuthorizationRule)
        {
            CategoryTree wCategoryTree = new CategoryTree();
            wCategoryTree.Name = pFwkAuthorizationRule.Name.Trim();
            wCategoryTree.ParentId = this.Id;
            wCategoryTree.Id = string.Concat(this.Id, "_", pFwkAuthorizationRule.Name.Trim());
            wCategoryTree.IsCategory = false;
            wCategoryTree.FwkAuthorizationRule = pFwkAuthorizationRule;
            FwkCategory.FwkRulesInCategoryList.Add(pFwkAuthorizationRule);
            return wCategoryTree;
        }

        public bool AnyRule(string ruleName)
        {
            if (this.FwkCategory.FwkRulesInCategoryList.Any<FwkAuthorizationRule>(p => p.Name.Trim().Equals(ruleName.Trim())))
                return true;
            else
                return false;
        }
        public FwkAuthorizationRule GetRule(string ruleName)
        {
            return this.FwkCategory.FwkRulesInCategoryList.Where<FwkAuthorizationRule>(p => p.Name.Trim().Equals(ruleName.Trim())).FirstOrDefault<FwkAuthorizationRule>();
                
            
            
        }
        public void RemoveRule(string rule_nanme)
        {
         
            var r1 = FwkCategory.FwkRulesInCategoryList.Where(p => p.Name.Trim().Equals(rule_nanme.Trim())).FirstOrDefault();
            FwkCategory.FwkRulesInCategoryList.Remove(r1);

          
        }

        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        bool _IsCategory = true;

        public bool IsCategory
        {
            get { return _IsCategory; }
            set { _IsCategory = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public FwkCategory FwkCategory { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public FwkAuthorizationRule FwkAuthorizationRule { get; set; }
    }
}
