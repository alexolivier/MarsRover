using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Models;

namespace MarsRoverTests
{
    [TestClass]
    public class CheckRobot
    {
        Plateau p = new Plateau(5, 5);
        int X = 3;
        int Y = 2;
        Orientation O = Orientation.West;

        [TestMethod]
        public void Robot_Setup()
        {
            Robot r = new Robot(X,Y,O,p);
            Location l;
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, O);
        }

        [TestMethod]
        public void Robot_SetLocation()
        {
            Robot r = new Robot(X, Y, O, p);
            Location l;

            r.setLocation(5, 5, Orientation.South);

            l = r.getLocation();
            Assert.AreEqual(l.X, 5);
            Assert.AreEqual(l.Y, 5);
            Assert.AreEqual(l.Orientation, Orientation.South);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Robot_SetLocationOutside()
        {
            Robot r = new Robot(X, Y, O, p);
            r.setLocation(6, 6, Orientation.South);


        }

        [TestMethod]
        public void Robot_Move()
        {
            Robot r = new Robot(X, Y, O, p);
            Location l;

            //Moving West
            r.move();
            l = r.getLocation();
            Assert.AreEqual(l.X, X - 1);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, O);

            //Moving North
            r.setLocation(X, Y, Orientation.North);
            r.move();
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y + 1);
            Assert.AreEqual(l.Orientation, Orientation.North);

            //Moving East
            r.setLocation(X, Y, Orientation.East);
            r.move();
            l = r.getLocation();
            Assert.AreEqual(l.X, X + 1);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.East);

            //Moving South
            r.setLocation(X, Y, Orientation.South);
            r.move();
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y - 1);
            Assert.AreEqual(l.Orientation, Orientation.South);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Robot_Move_OOB_Top()
        {
            Robot r = new Robot(0,5,Orientation.North,p);
            r.move();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Robot_Move_OOB_Left()
        {
            Robot r = new Robot(0, 5, Orientation.West, p);
            r.move();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Robot_Move_OOB_Right()
        {
            Robot r = new Robot(5, 5, Orientation.East, p);
            r.move();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Robot_Move_OOB_Bottom()
        {
            Robot r = new Robot(0, 0, Orientation.South, p);
            r.move();
        }

        [TestMethod]
        public void Robot_Rotate()
        {
            Robot r = new Robot(X, Y, O, p);
            Location l;
            
            //
            //From North
            //
            r.setLocation(X, Y, Orientation.North);
            //Rotate Left
            r.rotate(Rotation.Left);
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.West);
            
            r.setLocation(X, Y, Orientation.North);
            //Rotate Right
            r.rotate(Rotation.Right);
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.East);

            //
            //From East
            //
            r.setLocation(X, Y, Orientation.East);
            //Rotate Left
            r.rotate(Rotation.Left);
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.North);

            r.setLocation(X, Y, Orientation.East);
            //Rotate Right
            r.rotate(Rotation.Right);
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.South);

            //
            //From South
            //
            r.setLocation(X, Y, Orientation.South);
            //Rotate Left
            r.rotate(Rotation.Left);
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.East);

            r.setLocation(X, Y, Orientation.South);
            //Rotate Right
            r.rotate(Rotation.Right);
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.West);

            //
            //From West
            //
            r.setLocation(X, Y, Orientation.West);
            //Rotate Left
            r.rotate(Rotation.Left);
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.South);

            r.setLocation(X, Y, Orientation.West);
            //Rotate Right
            r.rotate(Rotation.Right);
            l = r.getLocation();
            Assert.AreEqual(l.X, X);
            Assert.AreEqual(l.Y, Y);
            Assert.AreEqual(l.Orientation, Orientation.North);

        }

    }
}
