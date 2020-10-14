using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Core.Samples.WebApi
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _persons;

        public PersonService()
        {
            _persons = new List<Person>();

            Create(new Person
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Arezki",
                LastName = "Saba"
            });

            Create(new Person
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Sylvain",
                LastName = "Meier"
            });
        }

        public List<Person> GetAll()
        {
            return _persons;
        }

        public Person Get(string id)
        {
            return _persons.FirstOrDefault(_ => _.Id == _.Id);
        }

        public Person Create(Person obj)
        {
            obj.Id = Guid.NewGuid().ToString();
            _persons.Add(obj);
            return obj;
        }

        public Person Update(Person obj)
        {
            var personToUpdate = _persons.FirstOrDefault(_ => _.Id == obj.Id);
            personToUpdate.LastName = obj.LastName;
            personToUpdate.FirstName = obj.FirstName;
            return personToUpdate;
        }

        public void Delete(string id)
        {
            _persons.RemoveAll(_ => _.Id == id);
        }

        public void Clear()
        {
            _persons.Clear();
        }
    }
}
