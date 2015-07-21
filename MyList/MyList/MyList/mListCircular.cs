using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
   public class mListCircular : iMList
    {
         private int size=0;
        private mListCircular first;
        private mListCircular last;
        private int data;
        private mListCircular next;
        public mListCircular First
        {
            get { return first; }
            set { first = value; }
        }
        public mListCircular Last
        {
            get { return last; }
            set { last = value; }
        }
        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public mListCircular Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
        public mListCircular(int value)
        {
            data = value;
            next = null;
            first = null;
        }
        public mListCircular(int value, mListCircular res)
        {
            data = value;
            next = res;
            first = res;
        }
        public mListCircular()
        {
            data = 0;
            next = null;
            first = null;
        } 
        public int this [int index]
        {
            get { return this.GetValue(index); }
            set { SetValue(index, value); }
        }
        public int GetValue (int pos)
        {
            int counter = 0;
            mListCircular position = first;
            int result = 0;
            while (position!=null)
            {
                if (counter==pos)
                {
                    result = position.Data;
                    break;
                }
                counter++;
                position = position.Next;
            }
            return result;
        }
        public void SetValue(int pos, int val)
        {
            int counter = 0;
            mListCircular position = first;
            while (position != null)
            {
                if (counter == pos)
                {
                    position.Data = val;
                    break;
                }
                counter++;
                position = position.Next;
            }
        }
        public void Add(int value)
        {
            mListCircular current = new mListCircular(value);
            if (first == null)
            {
                first = current;
                last = current;
            }
            else
            {
                last.Next = current;
                last.First = null;
                last = current;
                last.First = first;
            }
            size++;
        }
        public int Count()
        {
            int counter = 0;
            mListCircular position = first;
            while (position!=null)
            {
                counter++;
                position = position.Next;
            }
            return counter;
        }
        public void Remove(int value)
        {
            var temp = first;
            mListCircular current = null;
            int k = 0;
            while(temp!=null)
            {
                if (temp.Data == value && temp.Data != last.Data && temp.Data != first.Data&& k==0)
                {
                    current.Next = temp.Next;
                    temp = temp.Next;
                    size = size - 1;
                    k++;
                }
                else if(temp.Data==value && temp.Data==last.Data&& k==0)
                {
                    last = current;
                    last.Next = null;
                    last.First = first;
                    size = size - 1;
                    k++;
                    break;
                }
                current = temp;
                temp = temp.Next;
                if (first.Data == value&& k==0 )
                {
                    k++;
                    current = temp;
                    first = current;
                    temp = temp.Next;
                    last.First = first;
                    size = size - 1;
                    break;
                }
            }

         }
        public void Clear()
        {
            mListCircular temp = first;
            mListCircular current = null;

            while (temp!=null)
            {
                current = temp;
                temp = temp.Next;
                current = null;
            }
            last = null;
            first = null;
            size=0;
        }
        public void Delete(int position)
        {
            var temp = first;
            mListCircular current = null;
            int k = 0;
            int counter = 0;
            while (temp != null)
            {
                if (position == 0 && k==0)
                {
                    this.DelFirst();
                    k++;
                    break;
                }
                else if (position == size-1 && position==counter)
                {
                    last = current;
                    last.Next = null;
                    last.First = first;
                    size = size - 1;
                    k++;
                    break;
                }
                else if (position == counter)
                {
                    current.Next = temp.Next;
                    temp = temp.Next;
                    size = size - 1;
                }
                current = temp;
                temp = temp.Next;
                counter++;
            }
        }
        public void Insert (int position, int value)
        {
            var temp = first;
            mListCircular current = null;
            int counter = 0;
            int k=0;
            while (temp!=null)
            {
                if (position == 0 && k == 0)
                {
                    this.AddToStart(value);
                    k++;
                    break;
                }
                else if (position==counter)
                {
                    mListCircular newElem = new mListCircular(value);
                    newElem.Next = temp;
                    current.Next = newElem;
                    current.First = null;
                    size++;
                    break;
                }
                else if (counter == size-1  && position==size)
                {
                    current = new mListCircular(value);
                    current.Next = null;
                    current.First = first;
                    temp.Next = current;
                    temp.first = null;
                    last = current;
                    size++;
                    break;
                }
                current = temp;
                temp = temp.Next;
                counter++;
            }
        }
        public void AddToStart(int value)
        {
            var temp = first;
            mListCircular current = null;
            current = new mListCircular(value);
            current.Next = temp;
            first = current;
            last.First = first;
            size++;
        }
        public void DelFirst()
        {
            first = first.Next;
            size = size - 1;
            last.First = first;
        }
        public void Sort()
        {
           for (int i = 0; i < size; i++)
           {
               for (int j = i + 1; j < size; j++)
               {
                   if (this[j] < this[i])
                   {
                       var temp = this[i];
                       this[i] = this[j];
                       this[j] = temp;
                    }
                }
           }
        }
        public void Reverse()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (this[j] > this[i])
                    {
                        var temp = this[i];
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
            }
        }



    }
}
