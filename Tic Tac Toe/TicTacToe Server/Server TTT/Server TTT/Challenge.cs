using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_TTT
{
    class Challenge
    {
        //{  Unprocessed =1, Accepted=2, Rejected=3, Processed=4, CanBeRemoved = 5 };


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
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }


    }
}
