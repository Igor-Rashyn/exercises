using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_TTT
{
    class Playroom
    {
        // {NotStarted=1, Started=2, Finished=3, Restart=4, , CanBeRemoved = 5}
        private Player _first;
        public Player First
        {
            get { return _first; }
            set { _first = value; }
        }
        private Player _second;
        public Player Second
        {
            get { return _second; }
            set { _second = value; }
        }

        private string _firstPlayerStep;
        public string FirstPlayerStep
        {
            get { return _firstPlayerStep; }
            set { _firstPlayerStep = value; }
        }


        private string _secondPlayerStep;
        public string SecondPlayerStep
        {
          get { return _secondPlayerStep; }
          set { _secondPlayerStep = value; }
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        // {Continue =1, Rejected=2}
        private int _continueFirst;
        public int ContinueFirst
        {
            get { return _continueFirst; }
            set { _continueFirst = value; }
        }
        private int _continueSecond;
        public int ContinueSecond
        {
            get { return _continueSecond; }
            set { _continueSecond = value; }
        }



        public Playroom()
        {
            this.FirstPlayerStep = "EMPTY";
            this.SecondPlayerStep = "EMPTY";
        }

    
    }
}
