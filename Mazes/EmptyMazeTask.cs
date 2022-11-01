namespace Mazes
{
	public static class EmptyMazeTask
	{
        public static void MoveRight(Robot robot, int stepCount)
        {
            for (int i = 0; i < stepCount; i++)
            {
                robot.MoveTo(Direction.Right);
            }
        }
        public static void MoveDown(Robot robot, int stepCount)
        {
            for (int i = 0; i < stepCount; i++)
            {
                robot.MoveTo(Direction.Down);
            }
        }
        public static void MoveOut(Robot robot, int width, int height)
		{
            MoveDown(robot, height - 3);
            MoveRight(robot, width - 3);
		}
	}
}