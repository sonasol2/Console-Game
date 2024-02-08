using System;
namespace Console_Game
{
	enum RepairWeaponStatus
	{
		Broken,
		Intact,
		Reparied
	}

	public class Weapon
	{
		string name;
		public int damage;

		public Weapon(string name, int damage)
		{
			this.name = name;
			this.damage = damage;
			RandomaizerDamage();

		}

		public void RandomaizerDamage()
		{
            Random random = new Random();
			int percentDamage = damage * (100 + 20) / 100;
            int unitCount = random.Next(damage, percentDamage);
            damage = unitCount;
        }

		void RepairWeaponStatus(RepairWeaponStatus repairWeaponStatus)
		{ 
			
		}
	}
}

