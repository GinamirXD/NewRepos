namespace Mazes
{
	public static class SnakeMazeTask
	{
        public static void MoveLeftRight(Robot robot, int stepCount, Direction curDir)
        {
            for (int i = 0; i < stepCount; i++)
            {
                robot.MoveTo(curDir);
            }
        }

        public static void MoveDown(Robot robot)
        {
            for (int i = 0; i < 2; i++)
            {
                robot.MoveTo(Direction.Down);
            }
        }

        public static void MoveOut(Robot robot, int width, int height)
        {
            MoveLeftRight(robot, width - 3, Direction.Right);
            MoveDown(robot);
            MoveLeftRight(robot, width - 3, Direction.Left);
            if (!robot.Finished)
            {
                MoveDown(robot);
                MoveOut(robot, width, height);
            }
        }
    }
}