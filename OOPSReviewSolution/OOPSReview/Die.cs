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
        private string _Colour;

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
                //optionally you may place validation on the incoming value.

                if (value >= 6 && value <= 20)
                {
                    _Size = value;
                }
                else
                {
                    throw new Exception("Die cannot be " + value.ToString() + " sides. Die must be between 6 and 20 sides.");
                }
                
            }
        }

        public string Colour
        {

            get
            {
                return _Colour;
            }

            set
            {

                // (value == null) this will fail for an enpty string
                // (value == "") this will fail for a null value
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Color has no value.");
                }
                else
                {
                    _Colour = value;
                }

            }
        }


        //===Auto-implemented property===
        //public
        //it has a data type 
        //it has a name
        //it does not have an internal data member that you can directly access
        //the system will create internally a data storage area of the aproriate data type and manage the area.
        //the only way to access the data of an auto-implemented property is via the proerty.
        //ushally use when there is no need for any internal validation or other proerty logic.

        public int FaceValue { get; set; }


        //===Constructors===

        //===Behaviours (methods)===



    }
}
