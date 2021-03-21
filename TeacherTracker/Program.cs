using System;
using System.IO;

namespace TeacherTracker
{
    class Program
    {
        static readonly string textFile = "C:/Users/saamaja_naraharisett/TeachersList.txt";
        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.WriteLine("********************************************************\nEnter number from menu: \n 1. Enter new record \n 2. Update existing record \n 3. View teachers \n 4. Exit\n********************************************************");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter new record");
                        int ID;
                        string Name, ClassSection;
                        Console.WriteLine("Write into a file");
                        Console.WriteLine("Enter ID");
                        ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name");
                        Name = Console.ReadLine();
                        Console.WriteLine("Enter Class and Section");
                        ClassSection = Console.ReadLine();
                        string NewTeacher = "" + ID + " " + Name + " " + ClassSection;

                        if (File.Exists(textFile))
                        {
                            using (StreamWriter writer = File.AppendText(textFile))
                            {

                                writer.WriteLine(NewTeacher);
                            }
                        }
                        Console.WriteLine("*****Record Added*****");
                        break;
                    case 2:
                        Console.WriteLine("Update existing record");
                        Console.WriteLine("Updating record \n ");
                        Console.WriteLine("Enter ID of record you want to update");
                        string IDtoUpdate = Console.ReadLine();
                        string NametoUpdate, ClassSectiontoUpdate;
                        Console.WriteLine("Enter Name");
                        NametoUpdate = Console.ReadLine();
                        Console.WriteLine("Enter Class and Section");
                        ClassSectiontoUpdate = Console.ReadLine();

                        string text = System.IO.File.ReadAllText(textFile);
                        string[] words = text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        int i;
                        int flag = 0;
                        for (i = 0; i < words.Length; i += 3)
                        {
                            if (words[i] == IDtoUpdate)
                            {
                                flag = 1;
                                words[i + 1] = NametoUpdate;
                                words[i + 2] = ClassSectiontoUpdate;
                                break;
                            }
                        }
                        if(flag==0)
                        { Console.WriteLine("Record not found");
                            break;
                        }
                        File.WriteAllText(textFile, String.Empty);
                        for (i = 0; i < words.Length; i += 3)
                        {
                            string Record = words[i] + " " + words[i + 1] + " " + words[i + 2];
                            using (StreamWriter writer = File.AppendText(textFile))
                            {
                                writer.WriteLine(Record);
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine("Teachers:");
                        if (File.Exists(textFile))
                        {
                            using (StreamReader file = new StreamReader(textFile))
                            {
                                int counter = 0;
                                string ln;

                                while ((ln = file.ReadLine()) != null)
                                {
                                    Console.WriteLine(ln);
                                    counter++;
                                }
                                file.Close();
                                Console.WriteLine("File has " + counter + " teachers.");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        Environment.Exit(-1);
                        break;

                    default:
                        Console.WriteLine("Enter valid number from menu");
                        break;
                }
            } while (option != 4);
            Console.ReadKey();
        }
    }
}