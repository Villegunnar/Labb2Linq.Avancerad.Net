using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Labb2Linq.Models
{
    public class Metoder
    {
        public static void StartProgram()
        {
            DBContextSchool Context = new DBContextSchool();
            bool runMenu = true;
            while (runMenu)
            {
                Console.WriteLine("1. Alla lärare som undervisar i Matematik\n" +
                                  "2. Hämta alla elever med sina lärare\n" +
                                  "3. Sök efter kursnamn\n" +
                                  "4. Ändra namn på en kurs\n" +
                                  "5. Ändra namnet på en lärare");

                var keyInfo = Console.ReadKey(intercept: true);
                ConsoleKey menuChoice = keyInfo.Key;
                switch (menuChoice)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        matchTeachers(Context);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        studentsTeachersCourses(Context);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        checkCourse(Context);
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        courseNameChange(Context);
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        changeTeachersName(Context);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
        static void matchTeachers(DBContextSchool Context)
        {
            ClearWriteLine("-----------Alla lärare som undervisar i Matematik:----------\n");
            var matchTeachers = from e in Context.Kurser
                                join d in Context.Lärare
                                on e.Lärarna.Id equals d.Id
                                where e.KursNamn == "Matematik"
                                select new
                                {
                                    KursNamn = e.KursNamn,
                                    LärarFnamn = d.FirstName,
                                    LärareEnamn = d.LastName
                                };

            foreach (var item in matchTeachers)
            {
                Console.WriteLine($"{item.LärarFnamn} {item.LärareEnamn} undervisar {item.KursNamn}");
            }

            Done();
        }
        static void studentsTeachersCourses(DBContextSchool Context)
        {
            ClearWriteLine("-----------Hämta alla elever med sina lärare----------\n");
            var studentsTeachers = (from a in Context.Elever
                                    join b in Context.Klasser on a.Klasser.Id equals b.Id
                                    join e in Context.Kurser on b.Id equals e.Klasser.Id
                                    join d in Context.Lärare on e.Lärarna.Id equals d.Id
                                    orderby a.FirstName ascending

                                    select new
                                    {
                                        elevFnamn = a.FirstName,
                                        elevEnamn = a.LastName,
                                        lärarförnamn = d.FirstName,
                                        lärareEnamn = d.LastName,
                                        kurs = e.KursNamn,
                                    }).Distinct();

            int i = 2;
            foreach (var item in studentsTeachers)
            {
                Console.Write($"Elever: {item.elevFnamn} {item.elevEnamn}");

                Console.SetCursorPosition(30, i);
                Console.Write($"Lärare: { item.lärarförnamn} { item.lärareEnamn}");
                Console.SetCursorPosition(60, i++);
                Console.WriteLine($" Kurs: {item.kurs}");


            }
            Done();
        }
        static void checkCourse(DBContextSchool Context)
        {
            ClearWriteLine("------------Sök efter kursnamn---------------\n");
            Console.Write("Vilken kurs vill du söka efter: ");
            string courseSearch = Console.ReadLine();

            if (Context.Kurser.Select(s => s.KursNamn).ToList().Contains(courseSearch))
            {
                Console.WriteLine($"{courseSearch} finns i databasen");
            }
            else
            {
                Console.WriteLine($"{courseSearch}finns inte i databasen");

            }

            Done();
        }
        static void courseNameChange(DBContextSchool Context)
        {
            bool runLoop = true;
            while (runLoop)
            {
                ClearWriteLine("------Ändra namn på en kurs-------\n\nVilken kurs vill du ändra namn på?\n");


                string courseName = Console.ReadLine();
                if (Context.Kurser.Select(s => s.KursNamn).ToList().Contains(courseName))
                {
                    Console.WriteLine("Vad ska kursen heta istället?");

                    string courseName2 = Console.ReadLine();
                    var changeCourse = Context.Kurser.Where(s => s.KursNamn == courseName).FirstOrDefault();
                    changeCourse.KursNamn = courseName2;
                    Context.SaveChanges();
                    runLoop = false;

                }
                else
                {
                    Console.WriteLine("Det finns ingen kurs med det namnet i database.\nförsök igen...");
                    Thread.Sleep(2500);
                }

            }
            Done();

        }
        static void changeTeachersName(DBContextSchool Context)
        {
            ClearWriteLine("------Ändra namn på en Lärare-------\n\nAnas och Reidar har nu bytt plats");

                if (Context.Kurser.Select(s => s.Lärarna.FirstName).ToList().Contains("Anas"))
                {
                    var changeTeacher = Context.Lärare.Where(s => s.FirstName == "Reidar" && s.LastName == "Gustavsson").FirstOrDefault();
                    changeTeacher.FirstName = "Anas";
                    changeTeacher.LastName = "Qlok";

                    var changeTeacher2 = Context.Lärare.Where(s => s.FirstName == "Anas" && s.LastName == "Qlok").FirstOrDefault();
                    changeTeacher2.FirstName = "Reidar";
                    changeTeacher2.LastName = "Gustavsson";

                    Context.SaveChanges();             
                }
            Done();
        }
        public static void ClearWriteLine(string text = "")
        {
            Console.Clear();
            Console.WriteLine(text);
        }
        public static void Done()
        {
            Console.WriteLine("\nKlart! Tyck enter för att gå tillbaka till huvudmenyn.");
            Console.ReadLine();
            Console.Clear();
        }
        static void AddedObjects()
        {
            Klass sut20 = new Klass() { KlassNamn = "SUT20" };
            Klass sut21 = new Klass() { KlassNamn = "SUT21" };
            Klass sut22 = new Klass() { KlassNamn = "SUT22" };

            //DB.Add(sut20);
            //DB.Add(sut21);
            //DB.Add(sut22);


            Lärare anas = new Lärare() { FirstName = "Anas", LastName = "Qlok" };
            Lärare tobias = new Lärare() { FirstName = "Tobias", LastName = "Svensson" };
            Lärare reidar = new Lärare() { FirstName = "Reidar", LastName = "Gustavsson" };

            //DB.Add(anas);
            //DB.Add(tobias);
            //DB.Add(reidar);

            Elev viktor = new Elev { FirstName = "Viktor", LastName = "Gunnarsson", Klasser = sut20 };
            Elev erik = new Elev { FirstName = "Erik", LastName = "Norell", Klasser = sut20 };
            Elev lukas = new Elev { FirstName = "Lukas", LastName = "Rose", Klasser = sut21 };
            Elev Pelle = new Elev { FirstName = "Pelle", LastName = "Svensson", Klasser = sut21 };

            //DB.Add(viktor);
            //DB.Add(erik);
            //DB.Add(lukas);
            //DB.Add(Pelle);


            Kurs Prog1 = new Kurs { KursNamn = "Programmering 1", Lärarna = anas, Klasser = sut20 };
            Kurs Agil = new Kurs { KursNamn = "Agila metoder", Lärarna = tobias, Klasser = sut20 };
            Kurs matte = new Kurs { KursNamn = "Matematik", Lärarna = reidar, Klasser = sut21 };
            Kurs svenska = new Kurs { KursNamn = "Svenska", Lärarna = tobias, Klasser = sut20 };
            Kurs Kemi = new Kurs { KursNamn = "Matematik", Lärarna = reidar, Klasser = sut21 };

            //DB.Add(Prog1);
            //DB.Add(Agil);
            //DB.Add(matte);
            //DB.Add(svenska);
            //DB.Add(Kemi);

            //DB.SaveChanges();
        }
    }
}
