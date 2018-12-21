using System;

public interface IGenerator
{
    string GetPersistenceClass(Func<string,string> f);
}
