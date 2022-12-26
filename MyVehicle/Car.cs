using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Car : Vehicle
    {
        private string townFrom;
        private string townTo;
        
        protected override int Maxspeed { get => maxSpeed; set { } }
        protected override int Currspeed
        {
            get => currSpeed;
            set
            {
                if (value > Maxspeed)
                    currSpeed = Maxspeed;
                else if (value < 0)
                    currSpeed = 0;
                currSpeed = value;
            }
        }
        public Car(int ms, int cs, string from, string to) : base(ms, cs)
        {
            townFrom = from;
            townTo = to;
        }
        

        public override void SpeedDown() => Currspeed -= 5;
        public override void SpeedUp() => Currspeed += 5;
        public override string ToString() => $"Машина едет со скоростью {Currspeed} км/ч из {townFrom} в {townTo}";
    }
}
