using System;
using System.Collections.Generic;

namespace CodeGeneratorFunc
{
    class Methods
    {
        static public IEnumerable<ClassCode> GetPersistLayerClasses(string entity)
        {

            var list = new List<ClassCode>();
            var class1 = new ClassCode() { ClassName = $"{entity}DA", ClassBody = "Add" };
            class1.Methods.Add(new MethodCode() { MethodName = "Select", MethodBody = "select * from customer" });
            class1.Methods.Add(new MethodCode() { MethodName = "update", MethodBody = "select * from customer" });
            class1.Methods.Add(new MethodCode() { MethodName = "delete", MethodBody = "select * from customer" });
            var class2 = new ClassCode() { ClassName = $"{entity}BL", ClassBody = "Add" };

            list.Add(class1);
            list.Add(class2);

            return list;
        }
    }
}
