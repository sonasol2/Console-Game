using System;
using static Console_Game.Weapon;
namespace Console_Game
{
	class Player
	{
		public string weapon;
		private int health = 100;
		int damage;
		int x;
		int y;
		int killCounter;
		int speed;

		public Player(string newWeapon = "Sword", int startX = 0, int startY = 0)
		{

			this.weapon = newWeapon;
			this.x = startX;
			this.y = startY;
			speed = 5;
		}

		public void StartGame()
		{
			for (; health > 0;)
			{
				GetInfo();
				GameController();
			}
		}

		static void GetPosition(int x = 0, int y = 0)
		{

		}

		public void Move()
		{
			string[] positionLable = new string[] { "Straight", "Back", "Right", "Left" };
			Console.WriteLine($"Введие куда хотите пойти: {positionLable[0]}, {positionLable[1]}, {positionLable[2]}, {positionLable[3]}");
			
			string move = Console.ReadLine();
		
			//Console.WriteLine("Введите сколько шагов хотите пройти.");
			//int steps = Convert.ToInt32(Console.ReadLine());
			
            switch (move)
			{
				case "Straight":
					this.y += speed;
					RandomBattle();
                    break;

				case "Back":
					this.y -= speed;
                    RandomBattle();
                    break;

				case "Right":
					this.x += speed;
                    RandomBattle();
                    break;

				case "Left":
					this.x -= speed;
                    RandomBattle();
                    break;

				default:
					Console.WriteLine("Неизвестная комманда!");
					break;
			}

		}

		public void Fight()
		{
            Unit unit = new Unit();
            unit.GetUnitInfo();
			for ( ;unit.health > 0 ; )
			{
                Console.WriteLine("Введите команду: 'Hit', 'Dodge'");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "Hit":
                        unit.GetDamage(AvalibleWeapon());
                        break;

                    case "Dodge":
                        Dodge();
                        break;
                }

				if (unit.death)
				{
					Console.WriteLine($"Вы победили противника {unit.name}");
					killCounter++;
					return;
				}

                GetDamage(unit.RandomUnitDamage(), unit.name);

            }	
		}

		public void RandomBattle()
		{
            Random random = new Random();
            bool getBattle = random.Next(2) == 0 ? false : true;
			if (getBattle)
			{
                Console.WriteLine("На вашем пути попался противник!");
                Fight();
            }
		}
		
		public bool GetDamage(int unitDamage, string unitName)
		{

			if (health - unitDamage <= 0)
			{
				Console.WriteLine($"Вы получили {unitDamage} единиц урона от {unitName}.");
				Death();
				return true;
			}
			else if (health - unitDamage > 0)
			{
				health -= unitDamage;
				Console.WriteLine($"Вы получили {unitDamage} единиц урона от {unitName}. Ваше здоровье: {health}");
				return false;
			}
			else if (Dodge())
			{
				Console.WriteLine("Вы успешно увернулись от атаки и не получаете урона.");
				return false;
            }
			return false;

		}

		public void DoDamage(int a) 
		{ 
			
		}

		public void Death()
		{
            Console.WriteLine("Вы мертвы.");
            Environment.Exit(0);
        }

		public bool Dodge()
		{
            Random random = new Random();
            return random.Next(2) == 0? false : true;
        }

		public int AvalibleWeapon()
		{
			Weapon sword = new Weapon("Health Sword", 10);
			return sword.damage;
		}

		public void GetInfo()
		{
			Console.WriteLine($"Положение персонажа: ось х:{x}, ось у:{y}. Оружие в инвентаре {weapon}. Текущее здоровье: {health}");
		}

		public void GameController()
		{
            Console.WriteLine("Введите команду: 'Go', 'Fight', 'Wait'");
            string command = Console.ReadLine();
            switch (command)
			{
				case "Go":
					Move();
					break;

				case "Fight":
					Fight();
					break;

				case "Wait":
					GetInfo();
					break;
            }
				 

        }
		
	}
}

