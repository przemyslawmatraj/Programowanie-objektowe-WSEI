using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab8 { 
    record Student(string Name, char Team, int Ects);
    class Program { 
        static void Main(string[] args) { 
            int[] ints = { 4, 6, 1, 4, 7, 8, 3, 4, 9 };
            Predicate<int> oddPredicate = n =>
            {
                Console.WriteLine("Obliczanie predykatu dla n " + n);
                return n % 2 == 1;
            };
            Console.WriteLine("Przed wykonaniem wiersza 1");
            IEnumerable<int> odds = from n in ints 
                                    where n % 2 == 1 
                                    select n; 
            
            
            Console.WriteLine("Przed wykonaniem wiersza 2");
            odds = from n in odds
                   where n > 5
                   select n;
            int limit = 5;
            odds = from n in ints 
                   where n % 2 == 1 && n > limit 
                   select n;
            Console.WriteLine(string.Join(", ", odds));
            string[] strings = { "aa", "bb", "ccc", "fff", "eee", "ggg" };
            Console.WriteLine(string.Join(", ", from s in strings
                                                orderby s descending
                                                select s));
            //zapisz wyrazenie ktore podniesie do kwadratu kazda liczbe z ints i posortuje wyniki malejaco
            Console.WriteLine(string.Join(", ", from i in ints
                                                orderby i*i
                                                select i*i));
            Student[] students =
            {
                new Student("Ewa", 'A', 345),
                new Student("Ewab", 'B', 344),
                new Student("Ewac", 'A', 343),
                new Student("Ewad", 'B', 340),
                new Student("Ewae", 'A', 343),
            };
            Console.WriteLine(string.Join(", ", from s in students
                                                group s by s.Team into team
                                                select (team.Key, team.Count())
                                                ));
            IEnumerable<IGrouping<char, Student>> teams = from s in students
                                                          group s by s.Team;
            foreach(var item in teams)
            {
                Console.WriteLine(item.Key + " " + string.Join("\n", item));
            }
            string sentence = "ala ma psa ala lubi psy tomek lubi koty";
            //wykonaj zestawie ile razy kazdy z wyrazow wystepuje w sentence
            string[] sentenceArr = sentence.Split(" ");
            Console.WriteLine(string.Join(", ", from word in sentenceArr
                                                group word by word into words
                                                select (words.Key, words.Count())
                                                ));
            IEnumerable<int> enumerable = ints
                .Where(n => n % 2 == 1)
                .OrderBy(x => x)
                .Select(y => y*y);
            Console.WriteLine(string.Join(", ", enumerable));
            students.GroupBy(student => student.Team).Select(gr => (gr.Key, gr.Count()));
            IOrderedEnumerable<Student> students1 = students.OrderBy(student => student.Name).ThenByDescending(student => student.Ects);
            Console.WriteLine(string.Join("\n", students1));

        }
    }
}