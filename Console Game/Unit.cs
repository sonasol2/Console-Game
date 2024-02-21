using System;
namespace Console_Game
{
	enum UnitReaction
	{
		Agressive,
		Escape,
		Calm
	}
    enum UnitStatus
    {
        Live,
        Death,
    }

    public class Unit
	{
		public string name;
		public int damage;
		public int health;
		public bool death = false;
		private UnitStatus status = UnitStatus.Live;
		int x;
		int y;
		int speed = 4;

		public Unit(int playerX, int playerY)
		{
			this.x = x;
			this.y = y;	
			RandomUnitDamage();
			RandomUnitName();
			RandomUnitHealt();
        }

		public string RandomUnitName() 
		{
			Random random = new Random();
			int unitCount = random.Next(7);
			string[] units = new string[] { "Гоблин", "Имп", "Орк", "Гремлин", "Гарпия", "Утконос", "Лич" };
			return name = units[unitCount];
		}

		public int RandomUnitDamage()
		{
            Random random = new Random();
            int unitCount = random.Next(15, 30);
			return damage = unitCount;	
        }

        public int RandomUnitHealt()
        {
            Random random = new Random();
            int unitCount = random.Next(15, 25);
            return health = unitCount;
        }

        public int RandomUnitSpeed()
        {
            Random random = new Random();
            int unitCount = random.Next(2, 8);
            return speed = unitCount;
        }

        public void GetDamage(int recivededDamage)
		{
			this.health -= recivededDamage;
			Console.WriteLine($"{this.name} получает {recivededDamage} единиц урона");				
			if (health <= 0 )
			{
				Console.WriteLine($"{this.name} погибает");
				death = true;
				this.status = UnitStatus.Death;
			}

		}

		public int Move(int x, int y)
		{
			this.x = x;
			this.y = y;
			return (x);
		}

   //     public void Stalking(int x, int y)
   //     {
			//int unitPos = this.x + this.y;
			//int playerPos = (x + y)/speed;
	  
   //         int otrezokX = x - this.x;
			//int otrezokY = y - this.y;

			//if (otrezokX < otrezokY)
			//{
			//	this.x += otrezokX;
			//	this.y += otrezokY;
			//} 
			//else if (otrezokY > otrezokX)
			//{
			//	this.y += otrezokY;
			//	this.x += otrezokX;
			//} else if (otrezokX == otrezokY)
			//{ 
				
			//}


            //if (this.x < x) { }
				
        //}

        public void GetUnitInfo()
		{
			Console.WriteLine($"Ваш противник: {name}.");
		}

		public int DoDamage()
		{
			return damage;
		}
		
		public bool InitLive()
		{
			switch (this.status)
			{
				case UnitStatus.Live:
					return true;
				case UnitStatus.Death:
					return false;
				default:
					break;	
			}
            return true;

        }
    }
}

