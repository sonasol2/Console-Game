using System;
namespace Console_Game
{

	abstract class Units
	{
		public string Name { get; }
		public abstract int Health { get; }
		public int Speed { get; }
		public abstract int X { get; set; }
		public abstract int Y { get; set; }

		public Units(string name, int speed, int x, int y)
		{
            Name = name;
            Speed = speed;
            X = x;
            Y = y;
        }

		public abstract void Move(int xTarget, int yTarget);
		public abstract void Hit();
		
	}
}

