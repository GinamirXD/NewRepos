using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    abstract public class Vehicle
    {
        protected int maxSpeed;
        protected int currSpeed;
        abstract protected int Maxspeed { get; set; }
        abstract protected int Currspeed { get; set; }
        public Vehicle(int ms, int cs)
        {
            maxSpeed = ms;
            currSpeed = cs;
        }

        abstract public void SpeedUp();
        abstract public void SpeedDown();
    }
}
