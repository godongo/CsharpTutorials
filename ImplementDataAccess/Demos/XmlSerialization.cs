using ImplementDataAccess.Entities;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace ImplementDataAccess.Demos
{
    class Serialization
    {
        internal static void XmlSerializeAndDeserialize()
        {
            // Serialize person object.
            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Person p = new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 42
                };

                serializer.Serialize(stringWriter, p);
                xml = stringWriter.ToString();
            }

            Console.WriteLine(xml);

            // Deserialize person object.
            using (StringReader stringReader = new StringReader(xml))
            {
                Person p = (Person)serializer.Deserialize(stringReader);

                Console.WriteLine($"{ p.FirstName} { p.LastName} is { p.Age} years old");
            }
        }
        
        internal static void BinarySerializeAndDeserialize()
        {
            Person p = new Person
            {
                FirstName = "John",
                Age = 22
            };

            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\data.bin";

            IFormatter formatter = new BinaryFormatter();

            // Serialize.
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }

            // Deserialize.
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                Person dp = (Person)formatter.Deserialize(stream);

                Console.WriteLine($"{ p.FirstName} is { p.Age} years old");
            }
        }

        internal static void WcfDataContractSerializeAndDeserialize()
        {
            PersonDataContract p = new PersonDataContract
            {
                Id = 1,
                Name = "John Doe"
            };

            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\data.xml";

            // Serialize.
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
                ser.WriteObject(stream, p);
            }


            // Serialize.
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
                PersonDataContract result = (PersonDataContract)ser.ReadObject(stream);
            }
        }

        internal static void JSONSerializeAndDeserialize()
        {
            PersonJson p = new PersonJson
            {
                Id = 1,
                Name = "John Doe"
            };

            using (MemoryStream stream = new MemoryStream())
            {
                // Serialize.
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PersonJson));
                ser.WriteObject(stream, p);

                stream.Position = 0;
                StreamReader streamReader = new StreamReader(stream);
                Console.WriteLine(streamReader.ReadToEnd());

                // Deserialize.
                stream.Position = 0;
                PersonJson result = (PersonJson)ser.ReadObject(stream);
                Console.WriteLine($" Id is {result.Id} and Naem is {result.Name}");
            }
        }
    }
}
