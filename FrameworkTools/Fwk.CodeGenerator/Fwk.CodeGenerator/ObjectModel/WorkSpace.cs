using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Fwk.DataBase;


namespace Fwk.CodeGenerator
{
    public class WorkSpace
    {
        private Metadata _Metadata;
        private Dictionary<CodeGeneratorCommon.GeneratorsType, CodeGenerator.FrmBase> _GeneratorsList = new Dictionary<CodeGeneratorCommon.GeneratorsType, CodeGenerator.FrmBase>();

        internal void Add(CodeGenerator.FrmBase frm, CodeGeneratorCommon.GeneratorsType pGeneratorsType)
        {
            if (!_GeneratorsList.ContainsKey(pGeneratorsType))
            {
                _GeneratorsList.Add(pGeneratorsType, frm);
                if (_Metadata == null)
                    _Metadata = frm.Metadata;
                else
                    frm.Metadata = _Metadata;
            }
        }
        internal void Remove(CodeGeneratorCommon.GeneratorsType pGeneratorsType)
        {
            if (_GeneratorsList.ContainsKey(pGeneratorsType))
            {
                _GeneratorsList.Remove(pGeneratorsType);
            }
        }

        internal Boolean Contains(CodeGeneratorCommon.GeneratorsType pGeneratorsType)
        {
            return _GeneratorsList.ContainsKey(pGeneratorsType);
        }

    }
}
