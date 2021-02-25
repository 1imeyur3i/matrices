using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace lab_collections
{
    class Matrix
    {
        private double[,] arr = null;

        private Matrix W;

        // constructor
        public Matrix(double a, double b, double c, double d)
        {
            this.arr = new double[,] { { a, b }, { c, d } };
        }
//---------------------------------------------------------
        // двойной индексатор
        public double this[int i, int j]
        {
            set
            {
                arr[i, j] = value;
            }

            get
            {
                return arr[i, j];
            }
        }
//---------------------------------------------------------
        // определитель
        public static double det(Matrix Q)
        {
            return Q.arr[0, 0] * Q.arr[1, 1] - Q.arr[1, 0] * Q.arr[0, 1];
        }
//---------------------------------------------------------
        // умножение матрицы на число
        public static Matrix mult_const(Matrix Q, double c)
        {
            Matrix W = Q;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    W.arr[i, j] *= c;
            return W;
        }

        // умножение матриц
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix C = B;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    for (int k = 0; k < 2; k++)
                        C.arr[i, j] += A.arr[i, k] * B.arr[k, j];
            return C;
        }

        // сложение матриц
        public static Matrix operator +(Matrix A, Matrix B)
        {
            A.arr[0, 0] += B.arr[0, 0];
            A.arr[0, 1] += B.arr[0, 1];
            A.arr[1, 0] += B.arr[1, 0];
            A.arr[1, 1] += B.arr[1, 1];
            return A;
        }
//--------------------------------------------------------
        // обратная матрица
        public Matrix invMatrix(Matrix Q)
        {
            try
            {
                if (det(Q)==0)
                {
                    throw new Exception("Обратной матрицы не существует, данная матрица вырожденная.");
                }
                W = new Matrix(Q.arr[1,1],-Q.arr[0,1],-Q.arr[1,0],Q.arr[0,0]);
                W = mult_const(W, 1 / det(Q));
                
            }
            catch(Exception e)
            {
                Debug.WriteLine("\nError!");
                Debug.WriteLine("Method: {0}", e.TargetSite);
                Debug.WriteLine(e.Message);
            }
            return W;
        }
//----------------------------------------------------------
        // сравнение матриц по определителю
        public static bool operator >(Matrix A, Matrix B)
        {
            return det(A) > det(B);
        }
        public static bool operator <(Matrix A, Matrix B)
        {
            return det(A) < det(B);
        }
        public static bool operator ==(Matrix A, Matrix B)
        {
            return det(A) == det(B);
        }
        public static bool operator !=(Matrix A, Matrix B)
        {
            return det(A) != det(B);
        }
//--------------------------------------------------------------
        // переопределение ToString
        public override string ToString()
        {
            return arr[0, 0].ToString() + ' ' + arr[0, 1].ToString() + ' ' + arr[1, 0].ToString() + ' ' + arr[1, 1].ToString() + ' ';
        }
//---------------------------------------------------------------
        //переводит строку в матрицу, если формат не подходит, исключение
        public static Matrix Parse(string str)
        {
            try
            {
                var array = new List<double>();
                foreach (var s in str.Split(',',';'))
                {
                    array.Add(Convert.ToDouble(s));
                }
                if (array.Count == 4)
                {
                    return new Matrix(array[0], array[1], array[2], array[3]);
                }
                else
                {
                    throw new Exception("Формат строки неверный, введите четыре значения через , или ;");
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("\nError!");
                Debug.WriteLine("Method: {0}", e.TargetSite);
                Debug.WriteLine(e.Message);
            }
            return null;
        }
//---------------------------------------------------------
    // пробует перевести строку в матрицу
    public static bool TryParse(string str, out Matrix Q)
        {
            try
            {
                var array = new List<double>();
                foreach (var s in str.Split(',', ';'))
                {
                    array.Add(Convert.ToDouble(s));
                }
                if (array.Count == 4)
                {
                    Q = new Matrix(array[0], array[1], array[2], array[3]);
                    return true;
                }
                else
                {
                    Q = null;
                    return false;
                }
            }
            catch (Exception e)
            {
                Q = null;
                return false;
            }
        }

    }
}
