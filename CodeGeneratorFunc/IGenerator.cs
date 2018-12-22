using CodeGeneratorFunc;
using System;
using System.Collections.Generic;

public interface IGenerator
{
    IEnumerable<ClassCode> GetCodes(Func<string, IEnumerable<ClassCode>> f);
}
