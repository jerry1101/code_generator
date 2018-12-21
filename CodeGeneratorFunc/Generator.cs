using System;

public class Generator : IGenerator
{
    private string _entityName;
	public Generator()
	{
	}

    public string EntityName { get => _entityName; set => _entityName = value; }

    public string GetPersistenceClass(Func<string, string> f)
    {
        return f(_entityName);
    }
}
