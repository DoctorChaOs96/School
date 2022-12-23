namespace Collections
{
    internal class Person
    {
        public Person(string name, byte age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public byte Age { get; set; }
    }

    enum PersonRelationshipType
    {
        Friend = 1,
        Spouse = 2,
        Unknown = 3,
        Enemy = 4
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var relationsDictionary = new Dictionary<PersonRelationshipType, List<Person>>(new[]
            {
                new KeyValuePair<PersonRelationshipType, List<Person>>(PersonRelationshipType.Friend, new List<Person> { new Person("John", 30), new Person("Emily", 29)}),
                new KeyValuePair<PersonRelationshipType, List<Person>>(PersonRelationshipType.Enemy, new List<Person> { new Person("Julien", 35) }),
                new KeyValuePair<PersonRelationshipType, List<Person>>(PersonRelationshipType.Unknown, new List<Person> { new Person("David", 40)})
            });

            relationsDictionary.Remove(PersonRelationshipType.Unknown);
            relationsDictionary.Add(PersonRelationshipType.Unknown, new List<Person> { new Person("Jeremi", 31) });

            relationsDictionary[PersonRelationshipType.Unknown].Add(new Person("Jarwis", 21));

            Console.WriteLine("Please enter reletionship type:");

            var relType = (PersonRelationshipType)int.Parse(Console.ReadLine());

            if (relationsDictionary.TryGetValue(relType, out var persons) && persons != null && persons.Any()) 
            {
                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.Name} {person.Age} yo");
                }
            }
            else
            {
                Console.WriteLine("People with using of specified relationship type wasn't found.");
            }

            Console.ReadKey();
        }
    }
}