using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Plane : Vehicle
    {
        private readonly string cityFrom;
        private readonly string cityTo;
        public Plane(int ms, int cs, string from, string to) : base(ms, cs)
        {
            cityFrom = from;
            cityTo = to;
        }

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

        public override void SpeedDown() => Currspeed -= 50;
        public override void SpeedUp() => Currspeed += 50;
        public override string ToString() => $"Самолет летит со скоростью {Currspeed} км/ч из {cityFrom} в {cityTo}";
    }
}
