using CodeGeneratorFunc;
using System;
using System.Collections.Generic;

public class Generator : IGenerator
{
    private string _entityName;
	public Generator()
	{
	}

    public string EntityName { get => _entityName; set => _entityName = value; }

    public IEnumerable<ClassCode> GetCodes(Func<string, IEnumerable<ClassCode>> f)
    {
        return f(_entityName);
    }
}
