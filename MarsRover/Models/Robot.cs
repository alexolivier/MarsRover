using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Models
{
    //enum to restrict rotation options (new rotations would be added here)
    public enum Rotation
    {
        Left,
        Right
    }

    //robot class holds its location information and the logic for the possible actions
    public class Robot
    {
        private Location _location =  new Location();
        private Plateau _plateau;
        private List<string> _history = new List<string>();

        //robot is constructed with the plateau it is working on
        public Robot(Plateau p)
        {
            _plateau = p;
        }

        //also  allow for location values to be passed in aswell
        public Robot(int X, int Y, Orientation o, Plateau p)
        {
            _plateau = p;
            setLocation(X, Y, o);
        }

        //return the robots current location
        public Location getLocation()
        {
            return _location;
        }

        //update the location
        public void setLocation(int X, int Y, Orientation o)
        {
            if (_plateau.checkInside(X, Y))
            {
                _location.X = X;
                _location.Y = Y;
                _location.Orientation = o;
            }
            else
            {
                throw new Exception("New location is outside the plateau");
            }
        }

        //if a history of moves needs to be recalled - this will do it
        public List<string> getHistory()
        {
            return _history;
        }

        //do rotate
        public void rotate(Rotation r) {
            _location.Orientation = calcNewOrientation(r);
            _history.Add(r.ToString().Substring(0,1));
        }

        //do move
        public void move()
        {
            Tuple<int, int> newLocation = calcNewLocation();
            _location.X = newLocation.Item1;
            _location.Y = newLocation.Item2;
            _history.Add("M");
        }

        //calculate what the new location would be when a move is performed and return the new location if it is valid
        private Tuple<int,int> calcNewLocation() 
        {
            Tuple<int, int> newLocation;
            
            //switching logic for new location based on current orientation
            if (_location.Orientation == Orientation.North)
            {
                newLocation =  new Tuple<int, int>(_location.X, _location.Y+1);
            } 
            else if (_location.Orientation == Orientation.South)
            {
                newLocation = new Tuple<int, int>(_location.X, _location.Y-1);
            } 
            else if (_location.Orientation == Orientation.East)
            {
                newLocation = new Tuple<int, int>(_location.X+1, _location.Y);
            }
            else if (_location.Orientation == Orientation.West)
            {
                newLocation = new Tuple<int, int>(_location.X-1, _location.Y);
            }
            else
            {
                throw new Exception("Orientation not set");
            }

            //check if the new location would be within the plateau
            if (_plateau.checkInside(newLocation.Item1, newLocation.Item2))
            {
                return newLocation;
            }
            else
            {
                throw new Exception("Movement would result in being outside the plateau");
            }

        }

        //switching logic to determine new orientation based on current and turning direction
        private Orientation calcNewOrientation(Rotation rotation) {
            Orientation newOrientation;
            if (rotation == Rotation.Left)
            {
                switch (_location.Orientation)
                {
                    case Orientation.North:
                        newOrientation = Orientation.West;
                        break;
                    case Orientation.South:
                        newOrientation = Orientation.East;
                        break;
                    case Orientation.East:
                        newOrientation = Orientation.North;
                        break;
                    case Orientation.West:
                        newOrientation = Orientation.South;
                        break;
                    default:
                        throw new Exception("Not a valid rotation");
                }
                return newOrientation;
            }
            else
            {
                switch (_location.Orientation)
                {
                    case Orientation.North:
                        newOrientation = Orientation.East;
                        break;
                    case Orientation.South:
                        newOrientation = Orientation.West;
                        break;
                    case Orientation.East:
                        newOrientation = Orientation.South;
                        break;
                    case Orientation.West:
                        newOrientation = Orientation.North;
                        break;
                    default:
                        throw new Exception("Not a valid rotation");
                }
                return newOrientation;
            }

        }

    }
}
