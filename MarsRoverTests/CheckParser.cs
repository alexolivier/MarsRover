using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using MarsRover.Models;

namespace MarsRoverTests
{
    //
    // In most of these failing cases, an exception is thrown which causes a message to be displayed to the user
    //

    [TestClass]
    public class CheckParser
    {
        // Checking that the exception is thrown when the input isnt the correct length
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Parser_Valid_Instructions_No_Robots()
        {
            Parser p = new Parser();
            string input = "5 5";
            p.SetInstructions(input);
            List<Robot> result = p.Parse();
        }

        // Checking with one robot and the result
        [TestMethod]
        public void Parser_Valid_Instructions_One_Robot()
        {
            Parser p = new Parser();
            string input =  "5 5\r\n" +
                            "1 2 N\r\n" +
                            "LMLMLMLMM";
            p.SetInstructions(input);
            List<Robot> result = p.Parse();
            Assert.AreEqual(result.Count, 1);

            //test robot one output
            Location l = result[0].getLocation();
            Assert.AreEqual(l.X, 1);
            Assert.AreEqual(l.Y, 3);
            Assert.AreEqual(l.Orientation, Orientation.North);

        }

        // Checking with two robots and the result
        [TestMethod]
        public void Parser_Valid_Instructions_Two_Robots()
        {
            Parser p = new Parser();
            string input =  "5 5\r\n" +
                            "1 2 N\r\n" +
                            "LMLMLMLMM\r\n" +
                            "3 3 E\r\n" +
                            "MMRMMRMRRM\r\n";

            p.SetInstructions(input);
            List<Robot> result = p.Parse();
            Assert.AreEqual(result.Count, 2);

            //test robot one output
            Location l1 = result[0].getLocation();
            Assert.AreEqual(l1.X, 1);
            Assert.AreEqual(l1.Y, 3);
            Assert.AreEqual(l1.Orientation, Orientation.North);

            //test robot two output
            Location l2 = result[1].getLocation();
            Assert.AreEqual(l2.X, 5);
            Assert.AreEqual(l2.Y, 1);
            Assert.AreEqual(l2.Orientation, Orientation.East);
        }

        // Checking with three robots and the result
        [TestMethod]
        public void Parser_Valid_Instructions_Three_Robots()
        {
            Parser p = new Parser();
            string input =  "5 5\r\n" +
                            "1 2 N\r\n" +
                            "LMLMLMLMM\r\n" +
                            "1 2 N\r\n" +
                            "LMLMLMRMR\r\n" +
                            "3 3 E\r\n" +
                            "MMRMMRMRRM\r\n";
            p.SetInstructions(input);
            List<Robot> result = p.Parse();
            Assert.AreEqual(result.Count, 3);

            //test robot one output
            Location l1 = result[0].getLocation();
            Assert.AreEqual(l1.X, 1);
            Assert.AreEqual(l1.Y, 3);
            Assert.AreEqual(l1.Orientation, Orientation.North);

            //test robot two output
            Location l2 = result[1].getLocation();
            Assert.AreEqual(l2.X, 1);
            Assert.AreEqual(l2.Y, 0);
            Assert.AreEqual(l2.Orientation, Orientation.West);

            //test robot three output
            Location l3 = result[2].getLocation();
            Assert.AreEqual(l3.X, 5);
            Assert.AreEqual(l3.Y, 1);
            Assert.AreEqual(l3.Orientation, Orientation.East);

        }

        // Extra-line breaks should not cause issue as they will be stripped out
        [TestMethod]
        public void Parser_Invalid_Instructions_ExtraLineBreak()
        {
            Parser p = new Parser();
            string input = "5 5\n" +
                            "1 2 N\n\n\r\r\n" +
                            "LMLMLMLMM\n\r\n";
            p.SetInstructions(input);
            List<Robot> result = p.Parse();
            Assert.AreEqual(result.Count, 1);
        }


        // Unexepected characters will result in a parse error displayed to the user
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Parser_Invalid_Instructions_RandomChars()
        {
            Parser p = new Parser();
            string input = "asdd \n" +
                            "156 N\n\n\r\r\n" +
                            "LMLMLMLMM\n\r\n";
            p.SetInstructions(input);
            List<Robot> result = p.Parse();
            Assert.AreEqual(result.Count, 1);
        }

    }
}
