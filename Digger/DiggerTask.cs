using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Digger
{
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    public class Player : ICreature
    {
        private bool CanMove(int x, int y)
        {
            return Game.Map[x, y] == null || Game.Map[x, y].GetImageFileName() != "Sack.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            Keys key = Game.KeyPressed;

            switch (key)
            {
                case Keys.Down:
                    if (y < Game.MapHeight - 1 && CanMove(x, y + 1)) return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                    break;

                case Keys.Up:
                    if (y >= 1 && CanMove(x, y - 1)) return new CreatureCommand { DeltaX = 0, DeltaY = -1 };
                    break;

                case Keys.Right:
                    if (x < Game.MapWidth - 1 && CanMove(x + 1, y)) return new CreatureCommand { DeltaX = 1, DeltaY = 0 };
                    break;

                case Keys.Left:
                    if (x >= 1 && CanMove(x - 1, y)) return new CreatureCommand { DeltaX = -1, DeltaY = 0 };
                    break;
            }

            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.GetImageFileName() == "Gold.png")
                Game.Scores += 10;

            return conflictedObject.GetImageFileName() == "Sack.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }

    public class Sack : ICreature
    {
        private int _falling = 0;

        public CreatureCommand Act(int x, int y)
        {
            int below = Game.MapHeight - 1;

            while (y != below)
            {
                if (Game.Map[x, y + 1] == null || (Game.Map[x, y + 1].GetImageFileName() == "Digger.png" && _falling > 0))
                {
                    _falling++;
                    return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                }
                else if (_falling > 1)
                    return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
                else
                {
                    _falling = 0;
                    return new CreatureCommand { };
                }
            }

            if (_falling > 1)
                return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
            else
            {
                _falling = 0;
                return new CreatureCommand { };
            }
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }
}
