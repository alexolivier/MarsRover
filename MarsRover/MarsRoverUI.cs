using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MarsRover.Models;

namespace MarsRover
{
    public partial class MarsRoverUI : Form
    {
        //setup a new parser for the input - only one required for whole system
        private Parser parser = new Parser();

        public MarsRoverUI()
        {
            InitializeComponent();
        }

        private void calcPosition_Btn_Click(object sender, EventArgs e)
        {
            if (this.instructions_Txt.Text != "")
            {
                //reset the output text box
                this.output_Txt.Text = "";
                this.calcPosition_Btn.Enabled = false;

                //pass to it the instructions
                parser.SetInstructions(this.instructions_Txt.Text);

                try
                {
                    //do the parse which returns a list of robot objects
                    List<Robot> robots = parser.Parse();
                    var output = new List<string>();

                    //Loop through the robots, get their location and format for output
                    for (int i = 0; i < robots.Count; i++)
                    {
                        Location l = robots[i].getLocation();
                        output.Add(l.X + " " + l.Y + " " + l.Orientation.ToString().Substring(0, 1));
                    }

                    //Show the ouput
                    this.output_Txt.Text = output.Aggregate((a, b) => a + "\r\n" + b);
                }
                catch (Exception ex) //inside the program exceptions are thrown if an error occurs which is caught here and shown to the user
                {
                    this.output_Txt.Text = ex.Message;
                }
                finally
                {
                    this.calcPosition_Btn.Enabled = true;
                }
            }
        }
    }
}
