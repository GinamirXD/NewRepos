using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time1
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
            Hour = h;
            Minute = m;
            Second = s;
        }

        public Time(int h, int m) : this(h, m, 0)
        {
        }

        public Time() : this(0, 0, 0)
        {
        }

        public Time(int s) : this(0, 0, s)
        {
        }

        public int Seconds()
        {
            var x = Hour * 3600 + Minute * 60 + Second;
            return x;
        }

        public static Time operator +(Time t1, Time t2)
        {
            var h = t1.Hour + t2.Hour;
            var m = t1.Minute + t2.Minute;
            var s = t1.Second + t2.Second;
            return new Time(h, m, s);
        }

        public static Time operator -(Time t1, Time t2)
        {
            var h = t1.Hour - t2.Hour;
            var m = t1.Minute - t2.Minute;
            var s = t1.Second - t2.Second;
            return new Time(h, m, s);
        }

        public static Time operator *(Time t1, int a)
        {
            var h = t1.Hour * a;
            var m = t1.Minute * a;
            var s = t1.Second * a;
            return new Time(h, m, s);
        }

        public static Time operator /(Time t1, int a)
        {
            var h = t1.Hour / a;
            var m = t1.Minute / a;
            var s = t1.Second / a;
            return new Time(h, m, s);
        }
    }
}
