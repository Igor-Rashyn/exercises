using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class mList : iMList
    {
       private int[] list = new int[50];
       private int count = 0;
      public int this[int index]
        {
            get { return list[index];}
            set { list[index] = value;}
        }

      public void Add (int value)
        {
            if (list.Length == count)
            {
                Array.Resize(ref list,list.Length+1);
            }
            list[count] = value;
            count++;
        }
      public void Remove (int value)
        {
            int[] newList = new int[list.Length];
            int j = 0;
            int del = 0;
            for (int i=0; i<list.Length;i++)
            {
                if (list[i] == value)
                {
                    list[i] = 0;
                    del = i;
                    break;
                }
            }
            for (int i = 0; i < list.Length; i++)
            {
                if (i != del)
                {
                    newList[j] = list[i];
                    j++;
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = newList[i];
            }
          count = count - 1;
        }
      public void Clear()
      {
          for (int i = 0; i < list.Length; i++)
          {
              list[i] = 0;
          }
          count = 0;
      }
      public int Count()
      {
          return count;
      }
      public void Delete(int index)
      {
          int[] newList = new int[list.Length];
          int j = 0;
          for (int i = 0; i < list.Length; i++)
          {
              if (i != index)
              {
                  newList[j] = list[i];
                  j++;
              }
          }

          for (int i = 0; i < list.Length; i++)
          {
              list[i] = newList[i];
          }
          count = count - 1;
      }
      public void AddToStart(int value)
      {
          count++;
          if (list.Length == count)
          {
              Array.Resize(ref list, list.Length + 1);
          }
          int[] newList = new int[list.Length];
          newList[0] = value;
          for (int i = 1; i < list.Length; i++)
          {
              newList[i] = list[i];
          }

          for (int i = 0; i < list.Length; i++)
          {
              list[i] = newList[i];
          }
      }
      public void Insert(int index, int value)
      {
          if (list.Length == count)
          {
              Array.Resize(ref list, list.Length + 1);
          }
          int[] newList = new int[list.Length];
          int j = 0;
          for (int i = 0; i < list.Length; i++)
          {
              if (i != index)
              {
                  newList[i] = list[j];
                  j++;
              }
              else
              {
                  newList[i] = value;
                  count++;
              }
          }

          for (int i = 0; i < list.Length; i++)
          {
              list[i] = newList[i];
          }
      }
      public void Sort ()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[i])
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
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
                    if (list[j] > list[i])
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
      public void DelFirst ()
      {
          count = count - 1;
          int[] newList = new int[list.Length];
          for (int i = 1; i < list.Length; i++)
          {
              newList[i-1] = list[i];
          }
          for (int i = 0; i < list.Length; i++)
          {
              list[i] = newList[i];
          }
      }

    }
}
