using System.Collections.Generic;

namespace Lib.Core.Samples.WebApi
{
    public interface IPersonService
    {
        List<Person> GetAll();

        Person Get(string id);

        Person Create(Person obj);

        Person Update(Person obj);

        void Delete(string id);

        void Clear();
    }
}