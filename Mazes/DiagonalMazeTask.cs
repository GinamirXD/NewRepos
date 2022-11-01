using System;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace Mazes
{
    public static class DiagonalMazeTask
    {       
        public static void Move(Robot robot, int length, Direction side)
        {
            for (int i = 0; i < length; i++)
            {
                robot.MoveTo(side);
            }
        }

        public static int StepSize(int width, int height)
        {
            int step = 0;
            height = height - 2;
            width = width - 2;
            step = ((Math.Max(width, height) - 1) / Math.Min(width, height));

            return step;
        }

        public static void Exit(Robot robot, int length, int step, Direction side)
        {
            int count = 0;
            while (count < (length - 3))
            {
                Move(robot, step, side);
                if (side == Direction.Right)
                    robot.MoveTo(Direction.Down);
                else
                {
                    robot.MoveTo(Direction.Right);
                }
                count++;
            }
            Move(robot, step, side);
        }

        public static void MoveOut(Robot robot, int width, int height)
        {
            int step = StepSize(width, height);
            if (width > height)
                Exit(robot, height, step, Direction.Right);
            else
                Exit(robot, width, step, Direction.Down);
        }
    }
}