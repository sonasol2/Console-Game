using System;
namespace Console_Game
{

	class Goblin : Units	
	{
		int health;
        public override int X { get; set; }
        public override int Y { get; set; }
        public override int Health
		{
			get => health;
		}


		public Goblin(string name, int speed, int x, int y) : base	(name, speed, x, y ) 
		{
			health = 100;
		}

		public override void Move(int xTarget, int yTarget)
		{ 
			
		}

		public override void Hit()
		{ 
			
		}
	
		public void Info()
		{
			Console.WriteLine($"My coord now is X: {X}, Y: {Y}");
		}
    }
}

