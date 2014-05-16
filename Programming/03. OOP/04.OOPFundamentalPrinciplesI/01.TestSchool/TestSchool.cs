//We are given a school. In the school there are classes of students. 
//Each class has a set of teachers. Each teacher teaches a set of disciplines. 
//Students have name and unique class number. Classes have unique text identifier. 
//Teachers have name. Disciplines have name, number of lectures and number of exercises. 
//Both teachers and students are people. Students, classes, teachers and disciplines 
//could have optional comments (free text block).

//Your task is to identify the classes (in terms of  OOP) and their attributes and operations, 
//encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.

class TestSchool
{
    static void Main()
    {
        School telerikSchool = new School("Telerik");

        // declare new class "A"
        Class aParalelka = new Class("A");

        // declare some teachers
        Teacher shishmanova = new Teacher("Shishmanova", new Discipline("PHP", 20, 10));
        Teacher petrova = new Teacher("Petrova", new Discipline("CSharp", 130, 120));
        Teacher spasova = new Teacher("Spasova", new Discipline("HTML", 65, 60));
        Teacher petrashkova = new Teacher("Petrashkova", new Discipline("CSS", 65, 60));

        // add the teachers to the class "A"
        aParalelka.Teachers.AddItem(shishmanova);
        aParalelka.Teachers.AddItem(petrova);
        aParalelka.Teachers.AddItem(spasova);
        aParalelka.Teachers.AddItem(petrashkova);

        // declare some students
        Student kapriz = new Student("Kapriz", 11);
        Student toshko = new Student("Toshko", 20);
        Student gancho = new Student("Gancho", 10);
        Student petyr = new Student("Petyr", 15);
        Student stoqn = new Student("Stoqn", 18);
        Student liubo = new Student("Liubo", 12);

        // add the students to the class "A"
        aParalelka.Students.AddItem(kapriz);
        aParalelka.Students.AddItem(toshko);
        aParalelka.Students.AddItem(gancho);
        aParalelka.Students.AddItem(petyr);
        aParalelka.Students.AddItem(stoqn);
        aParalelka.Students.AddItem(liubo);


        // declare a new class "B"
        Class bParalelka = new Class("B");

        // declare some new teachers for the class "B" // we can use the old ones too
        Teacher georgiev = new Teacher("Georgiev", new Discipline("PHP", 20, 10));
        Teacher atanasova = new Teacher("Atanasova", new Discipline("CSharp", 130, 120));
        Teacher liubomirova = new Teacher("Liubomirova", new Discipline("HTML", 65, 60));
        Teacher sotirova = new Teacher("Sotirova", new Discipline("CSS", 65, 60));

        // add these teachers to the class "B"
        bParalelka.Teachers.AddItem(shishmanova);
        bParalelka.Teachers.AddItem(petrova);
        bParalelka.Teachers.AddItem(spasova);
        bParalelka.Teachers.AddItem(petrashkova);

        // declare some new students for the class "B"
        Student stefan = new Student("Stefan", 21);
        Student anton = new Student("Anton", 1);
        Student gencho = new Student("Gencho", 3);
        Student venci = new Student("Venci", 24);
        Student krisi = new Student("Krisi", 10);
        Student simona = new Student("Simona", 20);

        // add the new students to the class "B"
        bParalelka.Students.AddItem(stefan);
        bParalelka.Students.AddItem(anton);
        bParalelka.Students.AddItem(gencho);
        bParalelka.Students.AddItem(venci);
        bParalelka.Students.AddItem(krisi);
        bParalelka.Students.AddItem(simona);

        // add the classes "A" and "B" to the school
        telerikSchool.AddItem(aParalelka);
        telerikSchool.AddItem(bParalelka);

        // print the content of the school
        telerikSchool.PrintItems();

        // if u wanna see the teachers in class "A" u can type
        //aParalelka.Teachers.PrintItems();

        // or the students
        //aParalelka.Students.PrintItems();

        // add new discipline to the teacher's list of disciplines
        shishmanova.Disciplines.AddItem(new Discipline("New PHP",20,20));
        System.Console.WriteLine("Uchitel: {0}",shishmanova.Name);
        System.Console.WriteLine("Disciplini:");
        shishmanova.Disciplines.PrintItems();
    }
}
