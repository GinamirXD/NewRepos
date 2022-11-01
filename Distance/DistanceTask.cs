using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            double t;

            t = ((x - ax) * (bx - ax) + (y - ay) * (by - ay))
            / ((bx - ax) * (bx - ax) + (by - ay) * (by - ay));
            if (t < 0 || (ax == bx && ay == by))
                t = 0;
            else if (t > 1)
                t = 1;

            return Math.Sqrt((ax - x + (bx - ax) * t) * (ax - x + (bx - ax) * t)
            + (ay - y + (by - ay) * t) * (ay - y + (by - ay) * t));
        }
	}
}