using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSReview
{
    public class Die
    {

        //create a new instance of the math class Random
        //this instance (occurance, object) will be shared by each instance of teh class Die.
        //This instance will be created when the first instance is created. 

        private static Random _rnd = new Random();


        //this is the defintion of a object 
        //it is a conceptual view of the data that will be held by a physcial instance (object) of this class.

        //===Data Members===
        //is an internal private data storage item. Private data mambers cannot be reacheed directly by the user. Public data members can be reached directly by the user. 

        private int _Sides;
        private string _Colour;

        //===Properties===
        //a property is an external interface between the user and a single piece of data within the instance. A property has two abilities: the ability to assign a value to the internal data member and return a internal data member to the user.

        //Fully implemented Property

        public int Sides
        {
            get
            {
                //takes internal values and returns it to the user.

                return _Sides;
            }

            set
            {
                //takes the supplied user value and places it into the internal private data member. The incoming piece of data is placed into a special varriable that is called value. 
                //optionally you may place validation on the incoming value.

                if (value >= 6 && value <= 20)
                {
                    _Sides = value;

                    //consider placing this method within the property if the set is public and not private. If private then the method SetSides solves this problem. 
                    Roll();
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

        //another versions of Sides using a private set and auto implemented property
        //in this versioons you would need to code a method like SetSides()
        //public int Sides { get; private set; }


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
        //optional. if not supplied the system default constructor is used which will assign a system value to each data member/auto implemented property according to it's data type.
        //you can have any number of constructors within your class. As soon as you code a constructor your program is responcible for all constructors. 

        //syntax    public classname([list of parameters]) (....)

        //Typical constructors

        //Default constructor
        //this is similar to the system default constructor.

        public Die()
        {
            //you could leave this constructor empty and the system would acess the normal default value to your data members and auto implemented properties

            //you can direcly acess a private data member any place within your class.
            _Sides = 6;

            //you can acess any property any place within your class
            Colour = "White";

            //you could use a class method to generate a value for a data member/auto property
            Roll();
        }

        //Greedy Constructor
        //typically has a parameter for each data member and auto implemented property withn your class. Parameter order is not inportant. 
        //this constructor allows the outside user to create and assign their own values to the data members/auto properties at the time of instance creation. 

        public Die(int sides, string colour)
        {
            //since this data is coming from an outside source, it is best to use your property to save the values; especially if the property has validation.

            Sides = sides;
            Colour = colour;

            Roll();

        }


        //===Behaviours (methods)===
        //these are actions that the class can perform. the actions may or may not alter data members/auto properties values.
        //The actions could simply take a value(s) from the user and perfrom some logic opperations agains the values. 
        
        //can be public or private 
        //create a method that allows the user to change the number of sides on a die

        public void SetSides(int sides)
        {
            if (sides >= 6 && sides <= 20)
            {
                Sides = sides;
            }
            else
            {
                //optionally 
                //a) throw a new exception
                throw new Exception("Invalid value for sides");
                //b) set _Sides to a default value
                //Sides = 6;

            }

            Roll();

        }

        public void Roll()
        {
            //no parameters are required for this method since it will be using internal data values to complete its functions

            //randomly generate a value for the die depending on the maximun Sides

            FaceValue = _rnd.Next(1, Sides + 1);


        }

    }
}
