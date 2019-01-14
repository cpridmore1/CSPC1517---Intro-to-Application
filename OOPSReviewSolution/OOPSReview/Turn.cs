using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSReview
{
    public class Turn
    {

        private int _PlayerOneRoll;

        public int PlayerOneRoll
        {
            get
            {
                return _PlayerOneRoll;
            }

            set
            {
                _PlayerOneRoll = value;
            }

        }

        public int PlayerTwoRoll { get; set; }

        public Turn()
        {


        }

        public Turn(int player1, int player2)
        {
            PlayerOneRoll = player1;
            PlayerTwoRoll = player2;

        }

        //methods
        //public string FindRollResults()
        //{
        //   return null;
        //}









    }
}
