using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_collections
{
    public class ListOfMatrix
    {
        private List<Matrix> mlist;


        public ListOfMatrix(params Matrix[] mtrx)
        {
            mlist = new List<Matrix>();
            for (int i = 0; i < mtrx.Length; i++)
            {
                mlist.Add(mtrx[i]);
            }
        }
//----------------------------------------------
        // индексатор
        public Matrix this[int i]
        {
            get
            {
                return mlist[i];
            }   
        }
 //---------------------------------------
        //сортировка
        public void matr_sort()
        {
            mlist.Sort();
        }
 //-----------------------------------------
        //первый элемент
        public Matrix First_elem()
        {
            return mlist[0];
        }
//-----------------------------------------
        //последний элемент
        public Matrix Last_elem()
        {
            return mlist[mlist.Count()-1];
        }

        public int mCount()
        {
            return mlist.Count();
        }

        public void add_elem(Matrix Q)
        {
            mlist.Add(Q);
        }

        public Matrix min_elem()
        {
            double minD = Matrix.det(mlist[0]);
            int k = 0;
            for (int i = 0; i < mlist.Count; i++)
            {
                if (Matrix.det(mlist[i]) < minD)
                {
                    minD = Matrix.det(mlist[i]);
                    k = i;
                }
            }
            return mlist[k];
        }

        public Matrix max_elem()
        {
            double maxD = Matrix.det(mlist[0]);
            int k = 0;
            for (int i = 0; i < mlist.Count; i++)
            {
                if (Matrix.det(mlist[i]) > maxD)
                {
                    maxD = Matrix.det(mlist[i]);
                    k = i;
                }
            }
            return mlist[k];
        }

        public Matrix[] ToArray()
        {
            return mlist.ToArray();
        }
        public void PrintList(ListOfMatrix mlist)
        {
            for (int k = 0; k < mlist.mCount(); k++)
            {
                mlist[k].PrintMatrix();
                Console.WriteLine(' ');
            }
        }

        public string[] ToStrArr()
        {
            string[] Result = new string[mlist.Count()];
            int k = 0;
            foreach (Matrix matrix in mlist)
            {
                Result[k] = matrix.ToString();
                k++;
            }
            return Result;
        }
    }
}
