using System;
using static Console_Game.Weapon;
namespace Console_Game
{
    
	enum PlayerMove
    { 
		Straight,
		Rght,
		Left,
		Back
    }
	enum PlayerStatus
	{ 
		Live,
		Death,	
    }
	enum FightCommand
	{ 
	Hit,
    Dodge,
    Leave
    }

	class Player
	{
		public string weapon;
		private int health = 100;
		int damage = 1;
		int x;
		int y;
		int killCounter;
		int speed = 5;
		private PlayerStatus status = PlayerStatus.Live;

		public Player(int startX, int startY)
		{
			this.x = startX;
			this.y = startY;
			//Inventory();
            Live();
        }

		public void Live()
		{

			for (; LiveInit() ;)
			{
				GetInfo();
				PlayerController();
			}
		}

		public void MoveCommand()
		{
			Console.WriteLine("Выберете куда хотите пойти: 1. Straight, 2. Back, 3. Left, 4. Right");	
			string? move = Console.ReadLine();
			if (int.TryParse(move, out int x))
			{
				switch (x)
				{
					case 1:
						Move(PlayerMove.Straight);
						break;

					case 2:
						Move(PlayerMove.Back);
						break;

					case 3:
						Move(PlayerMove.Rght);
						break;

					case 4:
						Move(PlayerMove.Left);
						break;

					default:
						Console.WriteLine("Неизвестная комманда!");
						break;
				}
			}
			else { Console.WriteLine("Неизвестная команда"); return; }  

		}

		public void Move(PlayerMove action)
		{
			switch (action)
			{
				case PlayerMove.Straight:
                    this.y += speed;
					break;
				case PlayerMove.Back:
                    this.y -= speed;
					break;
				case PlayerMove.Rght:
                    this.x += speed;
					break;
				case PlayerMove.Left:
                    this.x -= speed;
					break;
                default:
					break;
			}
            //RandomBattle();
        }

        public void Fight()
		{
			Unit unit = new Unit(this.x, this.y);
			unit.GetUnitInfo();
			for ( ;unit.InitLive(); )
			{
                Console.WriteLine("Введите команду: 'Hit', 'Dodge', 'Leave'");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "Hit":
                        unit.GetDamage(DoDamage());
                        break;

                    case "Dodge":
                        Dodge();
                        break;

					case "Leave":
						//Leave(unit);
						//Stalking(unit.Move(this.x, this.y));
						break;
                }

				if (!unit.InitLive())
				{
					Console.WriteLine($"Вы победили противника {unit.name}");
					killCounter++;
					return;
				}

                GetDamage(unit);

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
		
		public bool GetDamage(Unit unit)
		{

			if (health - unit.damage <= 0)
			{
				Console.WriteLine($"Вы получили {unit.damage} единиц урона от {unit.name}.");
				Death();
				return true;
			}
			else if (health - unit.damage > 0)
			{
				health -= unit.damage;
				Console.WriteLine($"Вы получили {unit.damage} единиц урона от {unit.name}. Ваше здоровье: {health}");
				return false;
			}
			else if (Dodge())
			{
				Console.WriteLine("Вы успешно увернулись от атаки и не получаете урона.");
				return false;
            }
			return false;

		}

		public int DoDamage() 
		{
            Weapon sword = new Weapon("Health Sword", 10);
			return damage = sword.damage;
		}

		public void Death()
		{
            Console.WriteLine("Вы мертвы.");
            Environment.Exit(0);
        }

		public bool Dodge()
		{
            Random random = new Random();
            return random.Next(2) == 0 ? false : true;
        }

		//public int Inventory()
		//{	
		//	//Potions healingPotion = new Potions("Исцеляющее зелье", 30);
		//}

		public void GetInfo()
		{
			Console.WriteLine($"Положение персонажа: ось х:{x}, ось у:{y}. Оружие в инвентаре {weapon}. Текущее здоровье: {health}");
		}	

		public void PlayerController()
		{
            Console.WriteLine("Введите команду: 1.'Go', 2.'Fight', 3.'Stay'");
            string? command = Console.ReadLine();
			if (int.TryParse(command, out int result))
            switch (result)
			{
				case 1:
					MoveCommand();
					break;

				case 2:
					Fight();
					break;

				case 3:
					GetInfo();
					break;
            }
				 

        }
		
		//public void Leave(Unit unit)
		//{

		//	for (;LiveInit() || unit.InitLive();)
		//	{
		//	Console.WriteLine("Вы пытаетесь сбежать от противника");
		//	MoveCommand();
		//	unit.Stalking(this.x, this.y);
		//	}
			
		//}

		public bool LiveInit()
		{
			switch (this.status)
			{
				case PlayerStatus.Live:
					return true;
				case PlayerStatus.Death:
					return false;
				default:
					break;
			}
			return true;
			
		}
	}
}

