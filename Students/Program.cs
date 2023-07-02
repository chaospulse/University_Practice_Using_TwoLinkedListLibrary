using TwoLinkedListsLibrary;

namespace Practice
{
    class Program
    {
        public static StudentsList studentsList = new StudentsList();
        public static void Main(string[] args)
        {
            // демонстрація реалізації АТД
            Console.WriteLine("Do you want to add to list some random students for test? (y/n)");
            Console.Write("Your choice: ");
            if (Console.ReadLine() == "y")
            {
                Students student_1 = new Students(StudentsNames.Roman, 180, 65);
                Students student_2 = new Students(StudentsNames.Dima, 178, 69);
                Students student_3 = new Students(StudentsNames.Sasha, 185, 65);
                Students student_4 = new Students(StudentsNames.Daria, 150, 50);

                studentsList.AddStudent(student_1);
                studentsList.AddStudent(student_2);
                studentsList.AddStudent(student_3);
                studentsList.AddStudent(student_4);

                Console.WriteLine("Test students were added successfully.");
                Console.WriteLine();
            }

            bool Program_Launch = true;
            while (Program_Launch)
            {
                try
                {
                    Console.WriteLine("Choose action:");
                    Console.WriteLine("1. Add student");
                    Console.WriteLine("2. Delete student");
                    Console.WriteLine("3. Sort students (by height)");
                    Console.WriteLine("4. Students count");
                    Console.WriteLine("5. Change student by index(using indexator)");
                    Console.WriteLine("6. Find students with ideal weight");
                    Console.WriteLine("7. Output students in table view");
                    Console.WriteLine("8. Reverse output students in table view");
                    Console.WriteLine("9. Exit");

                    Console.WriteLine();
                    Console.Write("Your choice: ");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            // додавання елемента(студента) до списку
                            Console.WriteLine("Adding student info.");
                            Console.WriteLine("Choose name: ");
                            string[] names = Enum.GetNames(typeof(StudentsNames));
                            for (int i = 0; i < names.Length; i++)
                                Console.WriteLine($"{i + 1}. {names[i]}");

                            Console.Write("Choose name index: ");
                            int indexName = int.Parse(Console.ReadLine());
                            if (indexName < 1 || indexName > names.Length)
                                throw new Exception("Wrong index!");

                            Console.Write("Choose height: ");
                            double height = double.Parse(Console.ReadLine());
                            Console.Write("Choose weight: ");
                            double weight = double.Parse(Console.ReadLine());

                            Students student = new Students((StudentsNames)indexName, height, weight);

                            studentsList.AddStudent(student);
                            Console.WriteLine("Student added successfully!");
                            break;
                            
                        case 2:
                            // видалення елемента(студента) зі списку
                            Console.WriteLine("Delete student info:");
                            Console.Write("Choose index: ");
                            int index = int.Parse(Console.ReadLine());
                            studentsList.RemoveStudent(index);
                            Console.WriteLine("Student deleted successfully!");
                            break;
                            
                        case 3:
                            // сортування списку студентів за зрістом
                            studentsList.Sort();
                            Console.WriteLine("Students sorted successfully!");
                            break;
                            
                        case 4:
                            // довжина списку вузлів(студентів)
                            Console.WriteLine("Students count: " + studentsList.Length);
                            break;
                            
                        case 5:
                            // зміна даних за допомогою використання індексатора
                            Console.Write("Choose index: ");
                            int idx = int.Parse(Console.ReadLine());                            
                            ListNode<Students> Node = studentsList[idx];

                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Index\tName\tHeight\tWeight");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine($"{idx}\t{Node.Data.EnumNames}\t{Node.Data.Height}\t{Node.Data.Weight}");
                            Console.WriteLine("------------------------------");

                            Console.WriteLine("Choose new name: ");
                            string[] Names = Enum.GetNames(typeof(StudentsNames));
                            for (int i = 0; i < Names.Length; i++)
                                Console.WriteLine($"{i + 1}. {Names[i]}");

                            Console.Write("Choose name index: ");
                            int index2 = int.Parse(Console.ReadLine());
                            if (index2 < 1 || index2 > Names.Length)
                                throw new Exception("Wrong index!");

                            Console.Write("Choose new height: ");
                            double height1 = double.Parse(Console.ReadLine());

                            Console.Write("Choose new weight: ");
                            double weight1 = double.Parse(Console.ReadLine());

                            Node.Data.EnumNames = (StudentsNames)index2;
                            Node.Data.Height = height1;
                            Node.Data.Weight = weight1;
                            Console.WriteLine("Student changed successfully!");
                            break;
                            
                        case 6:
                            // Пошук студентів з ідеальною вагою та виведення їх на консоль
                            List<Students> studentsWithIdealWeight = studentsList.Find();
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Students with Ideal Weight: ");
                            if (studentsWithIdealWeight.Count != 0)
                            {
                                foreach (var students in studentsWithIdealWeight)
                                    Console.WriteLine($"{students.EnumNames}\t{students.Height}\t{students.Weight}");
                            }
                            else
                                Console.WriteLine("No students with ideal weight!");
                           
                            Console.WriteLine("---------------------------");
                            break;
                        case 7:
                            // вивід листа у табличному виді
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Index\tName\tHeight\tWeight");
                            Console.WriteLine("------------------------------");
                            if (studentsList.Length != 0)
                            {
                                for (int i = 0; i < studentsList.Length; i++)
                                {
                                    ListNode<Students> student2 = studentsList[i];
                                    Console.WriteLine($"{i}\t{student2.Data.EnumNames}\t{student2.Data.Height}\t{student2.Data.Weight}");
                                }
                            }
                            else
                                Console.WriteLine("\tList is empty.");
                            Console.WriteLine("------------------------------\n");
                            break;
                        case 8:
                            // вивід листа у зворотньому напрямку у табличному виді
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Index\tName\tHeight\tWeight");
                            Console.WriteLine("------------------------------");
                            if (studentsList.Length != 0)
                            {
                                int q = studentsList.Length-1;
                                foreach (var stud in studentsList.GetReversedEnumerator())
                                    Console.WriteLine($"{q--}\t{stud.EnumNames}\t{stud.Height}\t{stud.Weight}");
                            }
                            else
                                Console.WriteLine("\tList is empty.");
                            Console.WriteLine("------------------------------\n");
                            break;
                            
                        case 9:
                            //вихід з програми
                            Program_Launch = false;
                            break;
                            
                        default:
                            Console.WriteLine("Wrong input!");
                            break;
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}