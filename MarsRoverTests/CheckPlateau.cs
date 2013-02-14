using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Models;

namespace MarsRoverTests
{
    [TestClass]
    public class CheckPlateau
    {
        [TestMethod]
        public void Plateau_Testing_Inside()
        {
            int test_x = 5;
            int test_y = 5;
            Plateau p = new Plateau();
            p.setSize(test_x, test_y);



            Assert.IsTrue(p.checkInside(0, 0));
            Assert.IsFalse(p.checkInside(-1, 0));
            Assert.IsFalse(p.checkInside(0, -1));
            Assert.IsFalse(p.checkInside(-1, -1));

            Assert.IsTrue(p.checkInside(1, 1));
            Assert.IsTrue(p.checkInside(5, 5));

            Assert.IsFalse(p.checkInside(6, 5));
            Assert.IsFalse(p.checkInside(5, 6));
            Assert.IsFalse(p.checkInside(6, 6));

        }
    }
}
