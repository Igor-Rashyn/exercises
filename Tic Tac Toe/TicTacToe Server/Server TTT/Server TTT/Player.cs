using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_TTT
{
    class Player
    {
       

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private bool _playing;
        public bool Playing
        {
            get { return _playing; }
            set { _playing = value; }
        }

        private DateTime _dateOfLastVisit;
        public DateTime DateOfLastVisit
        {
            get { return _dateOfLastVisit; }
            set { _dateOfLastVisit = value; }
        }


        public Player(string name)
        {
            this.Name = name;
        }
        public string WriteToHtml(Player per)
        {

            return "<td onclick=\"challengePlayer(this)\">" + per.Name + "</td>";
        }





    }
}
