using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Ship : Vehicle
    {
        private readonly string townFrom;
        private readonly string townTo;
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
        public Ship(int ms, int cs, string from, string to) : base(ms, cs)
        {
            townFrom = from;
            townTo = to;
        }

        public override void SpeedDown() => Currspeed -= 1;
        public override void SpeedUp() => Currspeed += 1;
        public override string ToString() => $"Корабль плывёт со скоростью {Currspeed} км/ч из {townFrom} в {townTo}";
    }
}
