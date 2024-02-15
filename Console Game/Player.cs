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

		public Player(int startX = -5, int startY = -5)
		{
			this.x = startX;
			this.y = startY;
			//Inventory();
            StartGame();
        }

		public void StartGame()
		{

			for (; LiveInit() ;)
			{
				GetInfo();
				PlayerController();
			}
		}

		public void MoveCommand()
		{
			Console.WriteLine("Введие куда хотите пойти: Straight, Back, Left, Right");	
			string move = Console.ReadLine();
            switch (move)
			{
				case "Straight":
					Move(PlayerMove.Straight);
                    break;

				case "Back":
                    Move(PlayerMove.Back);
                    break;

				case "Right":
					Move(PlayerMove.Rght);
                    break;

				case "Left":
                    Move(PlayerMove.Left);
                    break;

				default:
					Console.WriteLine("Неизвестная комманда!");
					break;
			}

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
						Leave(unit);
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
            Console.WriteLine("Введите команду: 'Go', 'Fight', 'Stay'");
            string command = Console.ReadLine();
            switch (command)
			{
				case "Go":
					MoveCommand();
					break;

				case "Fight":
					Fight();
					break;

				case "Stay":
					GetInfo();
					break;
            }
				 

        }
		
		public void Leave(Unit unit)
		{

			for (;LiveInit() || unit.InitLive();)
			{
			Console.WriteLine("Вы пытаетесь сбежать от противника");
			MoveCommand();
			unit.Stalking(this.x, this.y);
			}
			
		}

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

