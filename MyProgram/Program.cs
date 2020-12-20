using System;
using Generated;

namespace MyProgram
{
    [JsonSerializable]
    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [JsonSerializable]
    public class Thing
    {
        public string Name { get; set; }
        public float Weight { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializer serializer = new JsonSerializer();
            GeneratedSerializer generatedSerializer = new GeneratedSerializer();

            Person tony = new Person { Age = 100, FirstName = "Tony", LastName = "Dwire" };
            Thing table = new Thing { Name = "Table", Weight = 56 };

            Console.WriteLine("Reflection:");
            Console.WriteLine("\t" + serializer.Serialize(tony));
            Console.WriteLine("\t" + serializer.Serialize(table));

            Console.WriteLine("Generator:");
            Console.WriteLine("\t" + generatedSerializer.Serialize(tony));
            Console.WriteLine("\t" + generatedSerializer.Serialize(table));
        }
    }
}
