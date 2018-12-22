using System.Collections.Generic;

namespace CodeGeneratorFunc
{
    public class ClassCode
    {
        private List<MethodCode> _methods;

        public ClassCode()
        {
            this._methods = new List<MethodCode>();
        }
        public string ClassName { get; set; }
        public string ClassBody { get; set; }

        public List<MethodCode> Methods { get => _methods; set => _methods = value; }

    }
}