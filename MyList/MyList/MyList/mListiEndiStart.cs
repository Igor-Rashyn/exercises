using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class mListiEndiStart : iMList
    {
        private int[] list = new int[50];
        private int count = 0;
        private int iStart = 24;
        private int iEnd = 24;
        public int this[int index]
        {
            get { return list[iStart+index]; }
            set { list[iStart + index] = value; }
        }

        public void Add(int value)
        {
            if (list.Length == iEnd+count)
            {
                Array.Resize(ref list, list.Length + 1);
            }
            list[iStart+count] = value;
            iEnd++;
            count++;
        }
        public void Remove(int value)
        {
            int[] newList = new int[list.Length];
            int j = 0;
            int del = 0;
            int k = 0;

            for (int i = 0; i < list.Length-iStart; i++)
            {
                if (list[iStart + i] == value && k == 0)
                {
                    del = iStart + i;
                    k++;
                }

                if (iStart + i != del)
                {
                    newList[j] = list[iStart+i];
                    j++;
                }
            }

            for (int i = 0; i < list.Length - iStart; i++)
            {
                list[iStart + i] = newList[i];
            }

            iEnd = iEnd - 1;
            count = count - 1;
        }
        public void Clear()
        {
            for (int i = 0; i < list.Length-iStart; i++)
            {
                list[iStart+i] = 0;
            }
            count = 0;
            iEnd = 24;
            iStart = 24;
        }
        public int Count()
        {
            return count;
        }
        public void Delete(int index)
        {
            int[] newList = new int[list.Length];
            int j = 0;

            for (int i = 0; i < list.Length-iStart; i++)
            {
                if (iStart + i != index + iStart)
                {
                    newList[j] = list[iStart + i];
                    j++;
                }
            }
            for (int i = 0; i < list.Length - iStart; i++)
            {
                list[iStart + i] = newList[i];
            }
            iEnd = iEnd - 1;
            count = count - 1;
        }
        public void AddToStart(int value)
        {
            count++;
            if (iStart - 1 > 0)
            {
                list[iStart - 1] = value;
                iStart = iStart - 1;
            }
            else 
            {
                // расширяем массив
                Array.Resize(ref list, list.Length + list.Length);
                int previStart = iStart;
                iStart = (int)Math.Ceiling((double)list.Length / 2);

                int[] newList = new int[list.Length];
                
                for (int i = 0; i < list.Length; i++)
                {
                    newList[i+1] = list[previStart + i];
                }

                newList[0] = value;

                for (int i = 0; i < list.Length; i++)
                {
                    list[iStart+i] = newList[i];
                }

            }            
        }
        public void Insert(int index, int value)
        {
            if (list.Length == iStart+count)
            {
                Array.Resize(ref list, list.Length + 1);
            }

            int[] newList = new int[list.Length];
            int j = 0;

            for (int i = 0; i < list.Length-iStart; i++)
            {
                if (iStart + i != index + iStart)
                {
                    newList[i] = list[iStart + j];
                    j++;
                }
                else
                {
                    newList[i] = value;
                    count++;
                    iEnd++;
                }
            }

            for (int i = 0; i < list.Length-iStart; i++)
            {
                list[iStart + i] = newList[i];
            }
        }
        public void Sort()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[iStart + j] < list[iStart + i])
                    {
                        var temp = list[iStart + i];
                        list[iStart + i] = list[iStart + j];
                        list[iStart + j] = temp;
                    }
                }
            }
        }
        public void Reverse()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[iStart + j] > list[iStart + i])
                    {
                        var temp = list[iStart + i];
                        list[iStart + i] = list[iStart + j];
                        list[iStart + j] = temp;
                    }
                }
            }
        }
        public void DelFirst()
        {
            count = count - 1;
            list[iStart] = 0;
            iStart = iStart + 1;
        }

    }
}
