using System;

namespace Question1
{
    abstract class Person
    {
        public int idBook { get; set; }
        public byte course { get; set; }
        public string surname { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Person person = (Person)obj;
            return (this.idBook == person.idBook);
        }

        public abstract void Print();
    }

    class Student : Person
    {
        Person[] data;

        public Student()
        {
            data = new Person[100];
        }

        public Person this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public override int GetHashCode()
        {
            return course.GetHashCode();
        }

        public override void Print()
        {
            Console.WriteLine($"Surname: { surname }, Course: { course.ToString() }, ID card: { idBook.ToString() }, HashCodeCourse: { GetHashCode() }");
        }
    }

    class Aspirant : Person
    {
        public string desertation { get; set; }

        Person[] data;

        public Aspirant()
        {
            data = new Person[100];
        }

        public Person this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public override void Print()
        {
            Console.WriteLine($"Surname: { surname }, Course: { course }, ID book: { idBook }, Diplom work: { desertation }");
        }
    }

    class Program
    {
        public static bool checkerName = true;

        public static string NameForCompare;

        public static void Menu()
        {
            Console.WriteLine("1) Add student");
            Console.WriteLine("2) Add aspirant");
            Console.WriteLine("3) How many student");
            Console.WriteLine("4) How many aspirant");
            Console.WriteLine("5) Student list");
            Console.WriteLine("6) Aspirant list");
            Console.WriteLine("7) Enter index of student");
            Console.WriteLine("8) Enter index of aspirant");
            Console.WriteLine("9) Delete index of student ");
            Console.WriteLine("10) Delete index of aspirant");
            Console.WriteLine("11) Exit");
            Console.Write("Your select: ");
        }

        public static void Read()
        {
            Console.Write("\nPress any button...");
            Console.ReadKey();
            Console.WriteLine("\n\n\n");
        }

        public static string CheckerSurname()
        {
            do
            {
                string personName = Convert.ToString(Console.ReadLine());

                for (int i = 0; i < personName.Length; i++)
                {
                    char element = personName[i];

                    if (!Char.IsLetter(element))
                    {
                        checkerName = false;
                        Console.Write("Incorrect name type, please enter correct name: ");
                        break;
                    }
                    else
                    {
                        checkerName = true;
                    }
                }

                NameForCompare = personName;

                if (NameForCompare.Length < 3)
                {
                    Console.Write("Name cannot be less than 2 letters or empty result\nEnter surname: ");
                    checkerName = false;
                }
            }
            while (checkerName == false);

            return NameForCompare;
        }

        public static int NumberCheckerForId()
        {
            int number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Int32.TryParse(numberInString, out number))
                {
                    if (numberInString.Length == 5)
                    {
                        return number;
                    }
                    else
                    {
                        Console.Write("Incorrect, id card can be 5 digit number: ");
                    }
                }

                else
                {
                    Console.Write("Incorrect number, please enter again: ");
                }
            }
        }

        public static int NumberCheckerForInt()
        {
            int number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Int32.TryParse(numberInString, out number))
                {
                    return number;
                }
                else
                {
                    Console.Write("Incorrect number, please enter again: ");
                }
            }
        }

        public static byte NumberCheckerForCourse()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    if (number > 6 || number == 0)
                    {
                        Console.Write("Incorrect course, course can be only from 1 till 6 please enter again: ");
                    }
                    else
                    {
                        return number;
                    }
                }

                else
                {
                    Console.Write("Incorrect course, course can be only from 1 till 6 please enter again: ");
                }
            }
        }

        public static byte NumberCheckerForSwitch()
        {
            byte number;

            for (; ; )
            {
                string numberInString = Console.ReadLine();

                if (Byte.TryParse(numberInString, out number))
                {
                    return number;
                }

                else
                {
                    Console.Write("You enter not a number, please try again: ");
                }
            }
        }

        static void Main(string[] args)
        {
            Student student = new Student();
            Aspirant aspirant = new Aspirant();
            int delete;
            int studentsCounter = 0;
            int aspirantsCounter = 0;
            bool selectionForAll = false;
            bool selectionForSwitch = false;

            do
            {
                Menu();
                do
                {
                    byte choice = NumberCheckerForSwitch();
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Write("Enter surname: ");
                                string studentSurname = CheckerSurname();

                                Console.Write("Enter course: ");
                                byte studentCourse = NumberCheckerForCourse();

                                bool sameChecker = true;
                                do
                                {
                                    Console.Write("Enter ID card: ");
                                    int studentIDBook = NumberCheckerForId();
                                    
                                    if (studentsCounter >= 1)
                                    {
                                        for (int i = 0; i < studentsCounter; i++)
                                        {
                                            if (student[0].idBook == studentIDBook)
                                            {
                                                Console.WriteLine($"Hash-{student[0].idBook.GetHashCode()}\n0-{student[0].idBook}\nHash-{student[i].idBook.GetHashCode()}\ni-{student[i].idBook}");
                                                Console.WriteLine("ID card can't be same, please enter again: ");
                                                sameChecker = false;
                                            }
                                            else
                                            {
                                                studentsCounter++;
                                                student[studentsCounter] = new Student { surname = studentSurname, course = studentCourse, idBook = studentIDBook };
                                               
                                                selectionForSwitch = true;
                                                sameChecker = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        student[studentsCounter] = new Student { surname = studentSurname, course = studentCourse, idBook = studentIDBook };
                                        studentsCounter++;
                                        selectionForSwitch = true;
                                        sameChecker = true;
                                    }
                                } while (sameChecker == false);

                                Read();
                                break;
                            }
                        case 2:
                            {
                                Console.Write("Enter surname: ");
                                string aspirantSurname = CheckerSurname();

                                Console.Write("Enter course: ");
                                byte aspirantCourse = NumberCheckerForCourse();

                                Console.Write("Enter diplom work: ");
                                string diplom = Console.ReadLine();

                                bool sameChecker = true;
                                do
                                {
                                    Console.Write("Enter ID card: ");
                                    int aspirantIDBook = NumberCheckerForId();

                                    if (aspirantsCounter > 0)
                                    {
                                        for (int i = -1; i < aspirantsCounter; i++)
                                        {
                                            if (aspirant[i].idBook == aspirantIDBook)
                                            {
                                                Console.WriteLine("ID card can't be same.");
                                                sameChecker = false;
                                            }
                                            else
                                            {
                                                aspirantsCounter++;
                                                aspirant[aspirantsCounter] = new Aspirant { surname = aspirantSurname, course = aspirantCourse, idBook = aspirantIDBook, desertation = diplom };

                                                selectionForSwitch = true;
                                                sameChecker = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        aspirant[aspirantsCounter] = new Aspirant { surname = aspirantSurname, course = aspirantCourse, idBook = aspirantIDBook, desertation = diplom };
                                        aspirantsCounter++;
                                        selectionForSwitch = true;
                                        sameChecker = true;
                                    }
                                } while (sameChecker == false);

                                Read();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine($"\nTotal students: { studentsCounter }");

                                Read();
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine($"\nTotal aspirants: { aspirantsCounter }");

                                Read();
                                break;
                            }
                        case 5:
                            {
                                if (studentsCounter == 0)
                                {
                                    Console.WriteLine("\nThis sheet empty");
                                }
                                else
                                {
                                    Console.WriteLine("\nStudent list");
                                    for (int i = 0; i <= studentsCounter; i++)
                                    {
                                        if (student[i] == null)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Student studentList = (Student)student[i];
                                            studentList.Print();
                                        }
                                    }
                                }

                                Read();
                                break;
                            }
                        case 6:
                            {
                                if (aspirantsCounter == 0)
                                {
                                    Console.WriteLine("\nThis sheet empty");
                                }
                                else
                                {
                                    Console.WriteLine("\nAspirant list");
                                    for (int i = 0; i <= aspirantsCounter; i++)
                                    {
                                        if (aspirant[i] == null)
                                        {
                                            continue;
                                        }
                                        Aspirant aspirantList = (Aspirant)aspirant[i];
                                        aspirantList.Print();
                                    }
                                }

                                Read();
                                break;
                            }
                        case 7:
                            {
                                bool checkerForCase7 = true;

                                do
                                {
                                    Console.Write("\nEnter student index: ");
                                    int indexStudent = NumberCheckerForInt();
                                    if (indexStudent > studentsCounter)
                                    {
                                        Console.Write($"Out of array we have index from 0 till { studentsCounter - 1 }");
                                        checkerForCase7 = false;
                                    }
                                    else
                                    {
                                        Student choiceStudent = (Student)student[indexStudent];
                                        Console.WriteLine($"\nSurname: { choiceStudent.surname }, Course: { choiceStudent.course }, ID card: { choiceStudent.idBook }");
                                        checkerForCase7 = true;
                                    }
                                } while (checkerForCase7 == false);

                                Read();
                                break;
                            }
                        case 8:
                            {
                                bool checkerForCase8 = true;

                                do
                                {
                                    Console.Write("\nEnter aspirant index: ");
                                    int indexAspirant = NumberCheckerForInt();
                                    if (indexAspirant > aspirantsCounter)
                                    {
                                        Console.WriteLine($"Out of array we have index from 0 till { aspirantsCounter - 1 }");
                                        checkerForCase8 = false;
                                    }
                                    else
                                    {
                                        Aspirant choiceAspirant = (Aspirant)aspirant[indexAspirant];
                                        Console.WriteLine($"\nSurname: { choiceAspirant.surname }, Course: { choiceAspirant.course }, ID card: { choiceAspirant.idBook }, Diplom work: { choiceAspirant.desertation }");
                                        checkerForCase8 = true;
                                    }

                                } while (checkerForCase8 == false); ;

                                Read();
                                break;
                            }
                        case 9:
                            {
                                Console.Write("\nEnter index student which you want delete: ");
                                delete = NumberCheckerForInt();
                                Student deleteStudent = (Student)student[delete];
                                Console.WriteLine($"\nStudent { deleteStudent.surname } deleted.");
                                student[delete] = null;
                                studentsCounter--;

                                Read();
                                break;
                            }
                        case 10:
                            {
                                Console.Write("Enter index aspirant which you want delete: ");
                                delete = NumberCheckerForInt();
                                Aspirant deleteAspirant = (Aspirant)aspirant[delete];
                                Console.WriteLine($"Aspirant { deleteAspirant.surname } deleted.");
                                aspirant[delete] = null;
                                aspirantsCounter--;

                                Read();
                                break;
                            }
                        case 11:
                            {
                                Console.WriteLine("Have a good day :)");
                                selectionForAll = true;
                                selectionForSwitch = true;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("You enter incorrect number, please enter from 1 till 11");
                                Menu();
                                selectionForSwitch = false;
                                continue;
                            }
                    }
                } while (selectionForSwitch == false);
            } while (selectionForAll == false);
            Console.ReadKey();
        }
    }
}