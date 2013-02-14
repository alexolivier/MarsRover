using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Models;

namespace MarsRover
{
    //Parser subsystem takes in the string, validates it, setups up the  the plateau and robots and then runs the instructions on the robots
    public class Parser
    {
        
        //holds the instruction
        private string _originalInsturction;

        //Parse can be initialised with no input or with the instructions passed in 
        public Parser()
        {

        }

        public Parser(string value)
        {
            SetInstructions(value);
        }

        //Method to allow the instruction set to be updated
        public void SetInstructions(string value)
        {
            _originalInsturction = value;
        }

        //Bulk of the parsing and executing happens here
        public List<Robot> Parse()
        {
            //New list of robots
            List<Robot> robots = new List<Robot>();

            //explode the instrcutions into lines and put into a list (remove \r and then split by \n)
            List<string> entities = _originalInsturction.Replace("\r", "").Split('\n').Where<string>(s => !string.IsNullOrEmpty(s)).ToList<string>();

            //3 lines minimum - plateau dimensions, robot position and instructions
            if (entities.Count < 3)
                throw new Exception("You have declared a plateau but no robots - a platau size followed by inital location and orientation");


            //create pleateu object
            Tuple<int, int> plateauEdge = validatePlateau(entities[0]);
            Plateau plateau = new Plateau(plateauEdge.Item1, plateauEdge.Item2);
            
            //pop the first line off the stack/list so left with robots
            entities.RemoveAt(0);

            //there has to be 2 lines per robot here tha there is only an even number
            if (entities.Count % 2 != 0)
                throw new Exception("not a valid number of lines for instructions");

            //determine number of robots
            int robotCount = entities.Count / 2;
            
            //read robot lines (loop)
            for (int i = 0; i < robotCount; i++)
            {
                //get first position and orientation lines
                string robotInitial = entities[i * 2];
                string robotInstuctions = entities[(i * 2) + 1];

                //validate they are formatted correctly
                Tuple<int,int,Orientation> initialPosition = evalInitialPosition(robotInitial);
                List<string> instructions = evalInstuctions(robotInstuctions);

                //create the robot object
                Robot robot = new Robot(plateau);

                //pass in the values
                robot.setLocation(initialPosition.Item1, initialPosition.Item2, initialPosition.Item3);

                //do the moves (new moves would be added here)
                for (int z = 0; z < instructions.Count; z++)
                {
                    switch (instructions[z])
                    {
                        case "M":
                            robot.move();
                            break;
                        case "L":
                            robot.rotate(Rotation.Left);
                            break;
                        case "R":
                            robot.rotate(Rotation.Right);
                            break;
                        default:
                            throw new Exception("Not a valid instructions");

                    }
                }

                //add to robot collection
                robots.Insert(i, robot);

            }
            return robots;
          
        }

        //takes in the plateau information line as string and returns an (X,Y) tuple
        private Tuple<int,int> validatePlateau(string input) {
            string[] parts = input.Split(' ');
            if (parts.Length == 2)
            {
                int _x;
                int _y;
                try
                {
                    //do conversion to int32
                    _x = Convert.ToInt32(parts[0]);
                    _y = Convert.ToInt32(parts[1]);
                    return new Tuple<int,int>(_x,_y);
                }
                catch (FormatException e)
                {
                    throw new Exception("Input string is not a sequence of digits.");
                }
                catch (OverflowException e)
                {
                    throw new Exception("The number cannot fit in an Int32.");
                }
            }
            else
            {
                throw new Exception("Plateau definition must be two integers seperated by a single space");
            }
        }

        //takes in the initial position string line outputs (X,Y,Orinetation) tuple
        private Tuple<int,int,Orientation> evalInitialPosition(string input)
        {
            string[] parts = input.Split(' ');
            if (parts.Length == 3)
            {
                int _x;
                int _y;
                Orientation _o;

                try
                {
                    //do conversion to int32
                    _x = Convert.ToInt32(parts[0]);
                    _y = Convert.ToInt32(parts[1]);
                }
                catch (Exception e)
                {
                    throw new Exception("Location value is not a single digit or sequence of digits.");
                }
 
                if (parts[2].Length != 1)
                    throw new Exception("Robot initial orientation must be a single character denoting N, S, E or W");
                

                //Determine Orientation value
                switch (parts[2].ToUpper())
                {
                    case "N":
                        _o = Orientation.North;
                        break;
                    case "S":
                        _o = Orientation.South;
                        break;
                    case "E":
                        _o = Orientation.East;
                        break;
                    case "W":
                        _o = Orientation.West;
                        break;
                    default:
                        throw new Exception("Robot initial orientation must be N, S, E or W");
                }
                                   

                return new Tuple<int,int,Orientation>(_x,_y,_o);
            }
            else
            {
                throw new Exception("Robot initial location must be defined by 2 integers and a letter denoating orientation seperated by a single space");
            }


        }

        //takes in the instruction line as string and returns a list of instruction characters
        private List<string> evalInstuctions(string input)
        {
            List<string> instructions = new List<string>();
            input = input.ToUpper();
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                //validate input is a valid move value and if so add to the instruction list
                switch (current)
                {
                    case 'M':
                        instructions.Add("M");
                        break;
                    case 'L':
                        instructions.Add("L");
                        break;
                    case 'R':
                        instructions.Add("R");
                        break;
                    default:
                        throw new Exception("Not a valid instructions");
                }

            }

            return instructions;
        }
    }
}
