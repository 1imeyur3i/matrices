using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace lab_collections
{
    public static class MatrixInOut
    {
        // чтение с консоли
        public static void mReadFromConsole(out ListOfMatrix mlist)
        {
            Console.WriteLine("     Добавление матриц в список.");

            ListOfMatrix ML = new ListOfMatrix();
            Matrix M = new Matrix();
            List<string> Text = new List<string>();
            while(true)
            {
                Console.WriteLine("Добавить матрицу? y/n");
                string choice = Console.ReadLine();                
                if (choice == "y")
                {
                    Console.Write("Введите элементы через запятую или точку с запятой: ");
                    if (Matrix.TryParse(Console.ReadLine(), out M))
                    {
                        ML.add_elem(M);
                        Console.WriteLine("Матрица добавлена");
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат, попробуйте еще раз.");
                    }

                }
                else if (choice == "n")
                {
                    break;
                }
            }
            mlist = ML;
            Console.WriteLine("Список успешно создан.");
        }
//------------------------------------------------------------
        // чтение из файла
        public static ListOfMatrix mReadFromFile(string Path)
        {
            ListOfMatrix ML = new ListOfMatrix();
            Matrix M = new Matrix();
            List<string> Text = new List<string>();
            try
            {
                StreamReader f = new StreamReader(Path);
                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    Text.Add(s);
                }
                f.Close();
            }
            catch(Exception e)
            {
                Debug.WriteLine("\nError!");
                Debug.WriteLine("Method: {0}", e.TargetSite);
                Debug.WriteLine(e.Message);
            }
            
            foreach (string s in Text)
            {
                
                    if (Matrix.TryParse(s, out M))
                    {
                        ML.add_elem(M);
                    }
                    else
                    {
                        Console.WriteLine("В файле есть строка неверного формата:' " + s + " '. Она не будет добавлена.");
                        throw new Exception("Неверный формат!");
                    }
                
                //обработать формат искл
                // обычнеы обрабатывать в мейне
            }
            return ML;

        }
//---------------------------------------------------------------------
        //запись в файл
        public static void mWriteToFile(ListOfMatrix mlist, string fPath)
        {
            try
            {
                if (mlist == null)
                {
                    throw new Exception("Список матриц пустой, нечего записывать в файл.");
                }

                StreamWriter f = new StreamWriter(fPath);
                for(int i = 0; i < mlist.mCount(); i++)
                {
                    Matrix M = mlist[i];
                    string M2S = M.ToString();
                    f.WriteLine(M2S);
                }
                f.Close();
            }
            catch(Exception e)
            {
                Debug.WriteLine("\nError!");
                Debug.WriteLine("Method: {0}", e.TargetSite);
                Debug.WriteLine(e.Message);
            }
        }
    }
}
