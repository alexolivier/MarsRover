using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Models
{
    //Location data structure to hold X,Y and Orientation

    public enum Orientation
    {
        North,
        South,
        East,
        West
    };

    public class Location
    {
        private int _x;
        private int _y;
        private Orientation _o;

        public Location()
        {
            _x = 0;
            _y = 0;
            _o = Orientation.North;
        }

        public Location(int X, int Y, Orientation O)
        {
            _x = X;
            _y = Y;
            _o = O;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Orientation Orientation
        {
            get { return _o; }
            set { _o = value; }
        }

    }
}
