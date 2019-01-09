using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSReview
{
    public class Die
    {

        //this is the defintion of a object 
        //it is a conceptual view of the data that will be held by a physcial instance (object) of this class.

        //===Data Members===
        //is an internal private data storage item. Private data mambers cannot be reacheed directly by the user. Public data members can be reached directly by the user. 

        private int _Size;

        //===Properties===
        //a property is an external interface between the user and a single piece of data within the instance. A property has two abilities: the ability to assign a value to the internal data member and return a internal data member to the user.

        //Fully implemented Property

        public int Size
        {
            get
            {
                //takes internal values and returns it to the user.
                return _Size;
            }

            set
            {
                //takes the supplied user value and places it into the internal private data member. The incoming piece of data is placed into a special varriable that is called value. 
                _Size = value;
            }
        }


        //===Constructors===

        //===Behaviours (methods)===



    }
}
