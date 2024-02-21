using System;
namespace Console_Game
{
    public interface IMove
    {

        static int speed;
        static int x;
        static int y;

        public void Move()
        {
        }

        delegate void MoveHandler();

        event MoveHandler MoveEvent;
    }
}

