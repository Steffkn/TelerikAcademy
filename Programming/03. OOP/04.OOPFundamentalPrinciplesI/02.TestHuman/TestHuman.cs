using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Students");
        List<Student> studenti = new List<Student>();
        studenti.Add(new Student("Stefan", "Goshkov", 5.0f));
        studenti.Add(new Student("Lychko", "Tanev", 3.50f));
        studenti.Add(new Student("Sasho", "Shipkov", 4.40f));
        studenti.Add(new Student("Luibko", "Iovkov", 2.20f));
        studenti.Add(new Student("Radost", "De Lorenc", 6.0f));
        studenti.Add(new Student("Radka", "Sokolova", 5.10f));
        studenti.Add(new Student("Vesko", "Veskov", 5.0f));
        studenti.Add(new Student("Koseto", "Lychezarnova", 6.0f));
        studenti.Add(new Student("Iskam", "Az", 5.0f));
        studenti.Add(new Student("Studentka", "Zabelejitelna", 6.00f));

        // sort by grade
        studenti = studenti
            .OrderBy(x => x.Grade)
            .ToList();

        foreach (Student student in studenti)
        {
            Console.WriteLine("Name: {0} \t Grade: {1}", student.FirstName, student.Grade);
        }
        Console.WriteLine();
        Console.WriteLine("Workers: ");
        List<Worker> workers = new List<Worker>();
        
        workers.Add(new Worker("Petyr","Draganov", 150, 8));
        workers.Add(new Worker("Stefko","Bychvarov", 120, 2));
        workers.Add(new Worker("Strybski","Legendi", 135, 4));
        workers.Add(new Worker("Clark","Kent", 1050, 24));
        workers.Add(new Worker("Lyiubo", "Supermenov", 150, 8));
        workers.Add(new Worker("Didi", "Didkova", 450, 6));
        workers.Add(new Worker("Krisi", "Simonova", 500, 4));
        workers.Add(new Worker("Georgi", "Trendafilov", 170, 12));
        workers.Add(new Worker("Qna", "Qnovska", 100, 4));
        workers.Add(new Worker("Poli", "Sotirova", 100, 4));

        // sort by grade
        workers = workers
            .OrderByDescending(x => x.MoneyPerHour())
            .ToList();


        foreach (Worker worker in workers)
        {
            Console.WriteLine("Name: {0} \t M/H: {1:0.00}", worker.FirstName, worker.MoneyPerHour());
        }

        Console.WriteLine();
        Console.WriteLine("Both sorded by names");
        List<Human> humans = new List<Human>();

        humans = workers
            .Concat<Human>(studenti)
            .OrderByDescending(x => x.FirstName)
            .ThenByDescending(y => y.LastName)
            .ToList();

        foreach (Human person in humans)
        {
            Console.WriteLine("{0, -15} {1}", person.FirstName, person.LastName);
        }
    }
}
