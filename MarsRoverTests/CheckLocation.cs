using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Models;

namespace MarsRoverTests
{
    [TestClass]
    public class CheckLocation
    {
        // Checking the default location elements are being set when created
        [TestMethod]
        public void Location_Setup_Empty()
        {
            Location l1 = new Location();
            Assert.AreEqual(l1.X, 0);
            Assert.AreEqual(l1.Y, 0);
            Assert.AreEqual(l1.Orientation, Orientation.North);
        }
        
        // Checking that the location elements are being set from the passed in parameters
        [TestMethod]
        public void Location_Setup_PassedIn()
        {
            int loc_x = 5;
            int loc_y = 5;
            Orientation loc_o = Orientation.South;
            Location l = new Location(loc_x, loc_y, loc_o);

            Assert.AreEqual(l.X, loc_x);
            Assert.AreEqual(l.Y, loc_y);
            Assert.AreEqual(l.Orientation, loc_o);
        }
    }
}
