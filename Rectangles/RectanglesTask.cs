using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			if (Math.Min(r1.Right, r2.Right) >= Math.Max(r1.Left, r2.Left) &&
			Math.Min(r1.Bottom, r2.Bottom) >= Math.Max(r1.Top, r2.Top))
			{
				return true;
			}
			return false;

		}

		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (AreIntersected(r1, r2))
				return Math.Abs((Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left)) *
				(Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top)));
			return 0;

		}

		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
				return 0;
			if (r1.Left <= r2.Left && r1.Right >= r2.Right && r1.Top <= r2.Top && r1.Bottom >= r2.Bottom)
				return 1;
			return -1;
		}
	}
}