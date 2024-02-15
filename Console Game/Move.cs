using System;
namespace Console_Game
{
	class Move
	{
        int x { get; set; }
        int y { get; set; }
        int speed;

        public Move ()
        { 
	        
	    }

        public void Moves(PlayerMove action)
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
        }
    }
}

