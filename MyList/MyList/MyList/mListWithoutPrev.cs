using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class mListWithoutPrev : iMList
    {
        private int size=0;
        private mListWithoutPrev first;
        private mListWithoutPrev last;
        private int data;
        private mListWithoutPrev next;
        public mListWithoutPrev First
        {
            get { return first; }
            set { first = value; }
        }
        public mListWithoutPrev Last
        {
            get { return last; }
            set { last = value; }
        }
        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public mListWithoutPrev Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
        public mListWithoutPrev(int value)
        {
            data = value;
            next = null;
        }
        public mListWithoutPrev(int value, mListWithoutPrev res)
        {
            data = value;
            next = res;
        }
        public mListWithoutPrev()
        {
            data = 0;
            next = null;
        } 
        public int this [int index]
        {
            get { return this.GetValue(index); }
            set { SetValue(index, value); }
        }
        public int GetValue (int pos)
        {
            int counter = 0;
            mListWithoutPrev position = first;
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
            mListWithoutPrev position = first;
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
            mListWithoutPrev current = new mListWithoutPrev(value);
            if (first == null)
            {
                first = current;
                last = current;
            }
            else
            {
                last.Next = current;
                var temp = last;
                last = current;
            }
            size++;
        }
        public int Count()
        {
            int counter = 0;
            mListWithoutPrev position = first;
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
            mListWithoutPrev current = null;
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
                    size = size - 1;
                }
            }

         }
        public void Clear()
        {
            mListWithoutPrev temp = first;
            mListWithoutPrev current = null;

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
            mListWithoutPrev current = null;
            int k = 0;
            int counter = 0;
            while (temp != null)
            {
                if (position == 0 && k==0)
                {
                    this.DelFirst();
                    k++;
                }
                else if (position == size-1 && position==counter)
                {
                    last = current;
                    last.Next = null;
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
            mListWithoutPrev current = null;
            int counter = 0;
            int k=0;
            while (temp!=null)
            {
                if (position == 0 && k == 0)
                {
                    this.AddToStart(value);
                    k++;
                }
                else if (position==counter)
                {
                    mListWithoutPrev newElem = new mListWithoutPrev(value);
                    newElem.Next = temp;
                    current.Next = newElem;
                    size++;
                    break;
                }
                else if (counter == size-1  && position==size)
                {
                    current = new mListWithoutPrev(value);
                    current.Next = null;
                    temp.Next = current;
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
            mListWithoutPrev current = null;
            current = new mListWithoutPrev(value);
            current.Next = temp;
            first = current;
            temp = first;
            size++;
        }
        public void DelFirst()
        {
            first = first.Next;
            size = size - 1;
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
