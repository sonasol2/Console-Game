using System;
namespace Console_Game
{
	public class Unit
	{
		public string name;
		public int damage;
		public int health;
		public bool death = false;
		int x;
		int y;
		int speed;

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
			}

		}

		public int Move(int x, int y)
		{
			this.x = x;
			this.y = y;

		}

        public void GetUnitInfo()
		{
			Console.WriteLine($"Ваш противник: {name}.");
		}

	}
}

