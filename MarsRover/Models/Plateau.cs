using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Author: Alex Olivier
// Task: ThoughtWorks coding assessment
// Module: Pateau Data Structure and tests

namespace MarsRover.Models
{
    //model for the plateau holding its dimensions
    public class Plateau
    {
        private int _maxX = 0;
        private int _maxY = 0;

        public Plateau()
        {

        }

        public Plateau(int X, int Y)
        {
            setSize(X, Y);
        }

        public void setSize(int X, int Y) 
        {
            _maxX = X;
            _maxY = Y;
        }

        //do a check to see if a dimension is inside the plateau or not
        public bool checkInside(int X, int Y)
        {
            if (X >= 0 && X <= _maxX && Y >= 0 && Y <= _maxY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        
    }
}
