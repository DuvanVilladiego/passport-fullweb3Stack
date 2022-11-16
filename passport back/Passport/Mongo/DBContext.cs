using MongoDB.Driver;
using Passport.Models;

namespace Passport.Mongo
{
    public class DBContext
    {

        public void insert(Person newPerson)
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("passport");

            var collection = database.GetCollection<Person>("person");

            List<Person> persons = collection.Find(status => true).ToList();

            Person p;

            if (persons.Count > 0)
            {
                Console.WriteLine(persons[persons.Count - 1].Id);
                p = persons[persons.Count-1];
                newPerson.Id = p.Id + 1;
                newPerson.Status = true;

            }

            collection.InsertOne(newPerson);
        }

        public Person get()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");

                var database = client.GetDatabase("passport");

                var collection = database.GetCollection<Person>("person");

                var filterDefinition = Builders<Person>.Filter.Eq(a => a.Status, true);

                List<Person> persons = collection.Find(filterDefinition).ToList();

                return persons[0];

            } catch (Exception e)
            {
                Console.WriteLine(e);
                Person person = new Person();
                person.Id = 0;
                return person;
            }
        }

        public String confirm(int _id)
        {
            try
            {
                Person p = get();

                var client = new MongoClient("mongodb://localhost:27017");

                var database = client.GetDatabase("passport");

                var collection = database.GetCollection<Person>("person");

                var findOneAndUpdateOptions = new FindOneAndUpdateOptions<Person> { ReturnDocument = ReturnDocument.Before };

                var filterDefinition = Builders<Person>.Filter.Eq(a => a.Id, p.Id);

                var updateDefinition = Builders<Person>.Update
                    .Set(a=> a.Status,false);

                collection.FindOneAndUpdate(filterDefinition, updateDefinition, findOneAndUpdateOptions);

                return "Success";

            } catch
            {
                return "User not exist";
            }
        }

    }
}
