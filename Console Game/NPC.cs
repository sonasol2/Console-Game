using System;
namespace Console_Game
{
	class NPC : Units
	{
		public NPC(int x, int y)
		{
            X = x;
            Y = y;
        }

        public override int Health => throw new NotImplementedException();

        public override int X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Hit()
        {
            throw new NotImplementedException();
        }

        public override void Move(int xTarget, int yTarget)
        {
            throw new NotImplementedException();
        }

        delegate void NoGamePlayer();
    }
}

