using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TZ_3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashArray table = new HashArray();


            table.Add("Максимов Александр Александрович", 34552854);
            table.Add("Мельникова Ксения Витальевна", 25465835);
            table.Add("Белюга Татьяна Сергеевна", 84521545);
            table.Add("Безуглова Анастасия Александровна", 125479852);


            table.Find("Безуглова Анастасия Александровна");

            table.Delete("Мельникова Ксения Витальевна");
            table.Delete("Максимов Александр Александрович");

            table.Edit("Мельникова Ксения Витальевна", 321654877);

            Console.ReadKey();

        }
    }

    struct Person
    {
        public string name;
        public int number;

        public Person(string name, int number)
        {
            this.name = name;
            this.number = number;
        }
    }

    class HashArray
    {
        public Dictionary<int, List<Person>> items;

        public HashArray()
        {
            items = new Dictionary<int, List<Person>>();
        }

        public void Add(string key, int value)
        {
            int hash = getHash(key);
            Person person = new Person(key, value);

            if (!items.ContainsKey(hash))
            {
                items[hash] = new List<Person>() { person };
            }
            else
            {
                items[hash].Add(person);
            }
        }

        public void Find(string key)
        {
            int hash = getHash(key);

            if (items.ContainsKey(hash))
            {
                foreach(Person person in items[hash])
                {
                    if (key == person.name)
                        Console.WriteLine(person.name+" - "+person.number);
                }
            }
        }

        public void Delete(string key)
        {
            int hash = getHash(key);

            if (items.ContainsKey(hash))
            {
                if(items[hash].Count>0)
                {
                    var itemToRemove = items[hash].First(n => n.name == key);
                    items[hash].Remove(itemToRemove);
                }

                if (items[hash].Count == 0)
                {
                    items.Remove(hash);
                }
            }

        }

        public void Edit(string key, int number)
        {
            int hash = getHash(key);

            if (items.ContainsKey(hash))
            {
                int index = items[hash].IndexOf(items[hash].First(n => n.name == key));
                Person person = new Person(key, number);
                items[hash][index] = person;
            }
        }

        int getHash(string str)
        {
            int hash = 0;
            for (int i = 0; i < str.Length; i++)
                hash += char.ConvertToUtf32(str, i);

            return hash;
        }

    }
}
