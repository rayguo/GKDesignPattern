using System;
using System.Collections.Generic;
using System.Text;

namespace LogoLib
{
   
    /// <summary>
    /// Models a classic Logo style Turtle.  Responds to commands like Forward, Rotate
    /// raises a TurtleMoved event whenever the turtle moves/rotates
    /// </summary>
    public class Turtle
    {
        public event EventHandler<TurtleMovedEventArgs> TurtleMoved;

        public Turtle()
        {
            // Initialise the turtle in terms of location and direction.
            Reset();
        }

        private Location location;

        public Location Location
        {
            get { return location; }
            private set { location = value; }
        }

        public void Forward(int distance)
        {
            Location prev = Location;

            // Moves the turtle to its new location based on the distance
            // and the current angle of the turtle.
            Location = location.Add((float)((float)distance * Math.Sin(angleInRadians)),
                                    (float)((float)distance * Math.Cos(angleInRadians)));

            // Raises an event to say the turtle has moved from location X to location Y
            OnTurtleMoved(new TurtleMovedEventArgs(prev, Location));
        }

       
        /// <summary>
        /// Rotates the turtle, changing its forward direction
        /// </summary>
        /// <param name="angleToRotate"></param>
        public void Rotate(int angleToRotate)
        {
            Angle += angleToRotate;

            OnTurtleMoved(new TurtleMovedEventArgs(Location, Location));
        }

        /// <summary>
        /// Resets turtle to its origin
        /// </summary>
        public void Reset()
        {
            Angle = 0;
            Location = new Location(0, 0);

            // Jump direct to the centre
            OnTurtleMoved(new TurtleMovedEventArgs(Location,Location));
        }

        /// <summary>
        /// Keeps a copy of the turtle's angle in radians
        /// </summary>
        private double angleInRadians;

        /// <summary>
        /// Angle the turtle is pointing in degrees
        /// </summary>
        private int angle;

        public int Angle
        {
            get { return angle; }
            private set
            { 
                angle = value;

                angleInRadians = (double)angle * Math.PI / 180.0; 
            }
        }

        /// <summary>
        /// Generate the TurtleMoved event so interested external parties can
        /// register interest in the turtles movements
        /// </summary>
        /// <param name="turtleMovedEventArgs"></param>
        protected virtual void OnTurtleMoved(TurtleMovedEventArgs turtleMovedEventArgs)
        {
            if (TurtleMoved != null)
            {
                TurtleMoved(this, turtleMovedEventArgs);
            }
        }
    }
}
