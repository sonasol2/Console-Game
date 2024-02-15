using System;
namespace Console_Game
{
	public class Potions
	{
		string name;
		int value;

		public Potions(string potionName, int effectsValue)
		{
			name = potionName;
			value = effectsValue;
		}

		public int Healing()
		{
			return value;
		}
	}
}

