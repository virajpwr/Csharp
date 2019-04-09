using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPEXAM
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManagement d = new DataManagement();
            //Console.Write(d.fillDataBase());
            var allCitizens = d.getAllCitizens();
            CitizensRecord<Person> r = new CitizensRecord<Person>(allCitizens.Count);

            StringBuilder builder = new StringBuilder();

            Console.WriteLine("Getting Persons...");
            foreach (Person p in allCitizens)
            {
                r.AddElement(p);
                builder.Append(p.ToString() + "\n");
            }

            Console.WriteLine(builder.ToString());
            Console.WriteLine("type a caracter");
            char c = Console.ReadLine()[0];
            do
            {


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("People by age");
                Console.WriteLine("Type min age:");
                int minAge = int.Parse(Console.ReadLine());
                Console.WriteLine("Type max age:");
                int maxAge = int.Parse(Console.ReadLine());
                var findByAge = r.FindByAge(minAge, maxAge);
                foreach (Person p in findByAge)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine("number of persons found by age " + minAge + ".." + maxAge + ": " + findByAge.Count);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("People by civil state");
                Console.WriteLine("type a civil state:\nOne of the Following: Married\nSingle\nWidowed\nDivorced\nComplicated");
                Enum.TryParse(Console.ReadLine(), out CivilState cs);
                var findByCivilState = r.FindByCivilState(cs);
                foreach (Person p in findByCivilState)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine("number of persons found by civil state " + cs.ToString() + ": " + findByCivilState.Count);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("People by Gender");
                Console.WriteLine("type a Gender:\nOne of the Following: Male\nFemale\nUnspecified");
                Enum.TryParse(Console.ReadLine(), out Gender g);
                var findByGender = r.FindByGender(g);
                foreach (Person p in findByGender)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine("number of persons found by Gender " + g.ToString() + ": " + findByGender.Count);

                Console.WriteLine("type r to keep working, any other caracter to quit");
                c = Console.ReadLine()[0];
            } while (c == 'r');
        }
    }
}