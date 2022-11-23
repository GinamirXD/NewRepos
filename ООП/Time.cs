using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП
{
    internal class Time
    {
        private int hour;
        private int minute;
        private int second;

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value >= 24)
                    hour = value % 24;
                else if (value < 0)
                    throw new ArgumentException("Time can't be negative");
                else
                    hour = value;
            }
        }
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value >= 60)
                    minute = value % 60;
                else if (value < 0)
                    throw new ArgumentException("Time can't be negative");
                else
                    minute = value;
            }
        }

        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (value >= 60)
                    second = value % 60;
                else if (value < 0)
                    throw new ArgumentException("Time can't be negative");
                else
                    second = value;
            }
        }
        public override string ToString()
        {
            return $"{Hour}:{Minute}:{Second}";
        }

        public Time(int h, int m, int s)
        {

        }

    }
}
