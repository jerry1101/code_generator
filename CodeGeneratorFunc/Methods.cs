using System;
using System.Collections.Generic;

namespace CodeGeneratorFunc
{
    class Methods
    {
        static public IEnumerable<ClassCode> GetPersistLayerClasses(string entity)
        {

            var list = new List<ClassCode>();
            list.Add(new ClassCode() { ClassName = $"{entity}DA", ClassBody = "Add" });
            list.Add(new ClassCode() { ClassName = $"{entity}BL", ClassBody = "Add" });

            return list;
        }
    }
}
