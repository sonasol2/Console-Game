using System;
namespace Console_Game
{

	class Goblin : Units	
	{
		int health = 100;
        public override int X { get; set; }
        public override int Y { get; set; }
        public override int Health
		{
			get => health;
		}


		public Goblin(string name, int speed, int x, int y) : base	(name, speed, x, y ) {}

		public override void Move(int xTarget, int yTarget)
		{
			int xSteps;
			int ySteps;


			xSteps = X - xTarget;
			ySteps = Y - yTarget;


            for (; xSteps != 0 || ySteps != 0;)
			{
				xSteps = Math.Abs(xSteps);
				ySteps = Math.Abs(ySteps);
				if (xSteps > ySteps & xSteps != 0)
				{
					if (xSteps < Speed)
					{
						if (xTarget >= 0 & xSteps < 0) X += xSteps; else if (xTarget <= 0 & xSteps > 0) X -= xSteps;
                        if (Speed - xSteps > ySteps)
                        {
                            Y += ySteps;
                        }
                        else Y -= Speed - xSteps;
                        ySteps = Y - yTarget;
                        xSteps = X - xTarget;
                    } 
					else 
					{
						if (X > xTarget) X -= Speed; else if (X < xTarget || xSteps < 0) X += Speed;
							xSteps = X - xTarget;
					}
   
                } 
				else
				{
                    if (ySteps < Speed & ySteps != 0)
                    {
                        if (yTarget >= 0 & ySteps < 0) Y += ySteps; else if (yTarget <= 0 & ySteps > 0) Y -= ySteps;
                        if (Speed - ySteps > xSteps)
						{
							X += xSteps;
						}
						else X -= Speed - ySteps;
                        ySteps = Y - yTarget;
                        xSteps = X - xTarget;
                    }
					else
					{ 
						if (Y > yTarget) Y -= Speed; else if (Y < yTarget || ySteps < 0) Y += Speed;
						ySteps = Y - yTarget;
					}
                    
                }

					Console.WriteLine($"My coord now is X: {X}, Y: {Y}");

            }
			Console.WriteLine("Im here");
			
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

