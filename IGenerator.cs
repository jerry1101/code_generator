using System;

public interface IGenerator
{
    //private delegate int ProducePersistenceClass(int one, int two);
    string GetPersistenceClass(string entitiName);
}
