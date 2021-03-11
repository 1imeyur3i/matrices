using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            void MenuText()
            {
                Console.WriteLine("Работа со списком матриц.\n" +
                              "1. Ввод списка матриц через консоль.\n" +
                              "2. Ввод списка матриц через файл.\n" +
                              "3. Вывод списка на консоль.\n" +
                              "4. Вывод информации о списке\n" +
                              "5. Вывод элемента списка под номером\n"+
                              "0. Выход\n"+
                              "=======================================\n"+
                              "Расчеты проводятся для последней введенной матрицы.");
            }

            void microMenuText()
            {
                Console.WriteLine("Информация о списке.\n"+
                                    "a. Первый элемент\n"+
                                    "b. Последний элемент\n"+
                                    "c. Вывод всех матриц, определитель которых меньше введенного числа.\n"+
                                    "0. Выход\n");
            }

            void microMenu(ListOfMatrix ML)
            {
                Console.WriteLine("         Ваш выбор: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "a":
                        if (ML != null)
                        {
                            Console.Write("Первый элемент списка:");
                            Console.WriteLine(ML.First_elem().ToString());
                        }
                        else
                            Console.WriteLine("К сожалению, список пуст.");
                        microMenu(ML);
                        break;                        
                    case "b":
                        if (ML != null)
                        {
                            Console.Write("Последний элемент списка:");
                            Console.WriteLine(ML.Last_elem().ToString());
                        }
                        else
                            Console.WriteLine("К сожалению, список пуст.");
                        microMenu(ML);
                        break;
                        //сортировка, которую еще предстоит сделать
                    /*case "c":
                        if (ML != null)
                        {
                            Console.WriteLine("Отсортированный список:");
                            ML.matr_sort();
                            for (int i = 0; i < ML.mCount(); i++)
                            {
                                Matrix matrix = ML[i];
                                Console.WriteLine(matrix.ToString());
                            }
                        }
                        else
                            Console.WriteLine("К сожалению, список пуст.");
                        microMenu(ML);
                        break;*/
                    case "c":
                        if (ML != null)
                        {
                            int k = 0;
                            Console.Write("Введите число:");
                            double compareDet;
                            compareDet = Convert.ToDouble(Console.ReadLine());
                            
                            for (int i = 0; i < ML.mCount(); i++)
                            {
                                if(Matrix.det(ML[i])< compareDet)
                                {
                                    Matrix matrix = ML[i];
                                    Console.WriteLine(matrix.ToString());
                                    k++;
                                }
                                
                            }
                            if (k == 0)
                                Console.WriteLine("Не нашлось таких матриц");
                        }
                        else
                            Console.WriteLine("К сожалению, список пуст.");
                        microMenu(ML);
                        break;
                    case "0":
                        MenuText();
                        Menu(ML);
                        break;
                    default:
                        Console.WriteLine("Выберите букву соответствующего пункта меню.");
                        break;
                }
                
            }

            ListOfMatrix FirstOpt()
            {
                ListOfMatrix NewMList = new ListOfMatrix();
                MatrixInOut.mReadFromConsole(out NewMList);                
                return NewMList;
            }            

            void Menu(ListOfMatrix ML)
            {
                ListOfMatrix NewMList = new ListOfMatrix();
                Console.WriteLine("     Ваш выбор: ");
                string C;
                C = Console.ReadLine();
                switch (C)
                {
                    case "1":
                        NewMList = FirstOpt();                       
                        Menu(NewMList);
                        break;
                    case "2":
                        string fileP;
                        Console.WriteLine("Введите путь к файлу: ");
                        fileP = Console.ReadLine();
                        NewMList = MatrixInOut.mReadFromFile(fileP);
                        Menu(NewMList);
                        break;
                    case "3":
                        if (ML != null)
                        {
                            Console.WriteLine("Добавленный список:");
                            for (int i = 0; i < ML.mCount(); i++)
                            {
                                Matrix matrix = ML[i];
                                Console.WriteLine(matrix.ToString());
                            }
                        }
                        else
                            Console.WriteLine("К сожалению, список пуст.");
                        NewMList = ML;
                        Menu(NewMList);
                        break;
                    case "4":
                        microMenuText();
                        microMenu(ML);                       
                        break;
                    case "5":
                        int n;
                        Console.WriteLine("Введите номер матрицы: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            Console.WriteLine(ML[n].ToString());
                        }
                        catch(IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Такого элемента не существует.");
                        }
                        Menu(ML);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Выберите число от 1 до 5.");
                        break;
                }
               
            }

            ListOfMatrix MList = new ListOfMatrix();
            MList = null;
            MenuText();
            Menu(MList);
            Console.ReadKey();
            
        }
    }
}
