using System;
namespace Console_Game
{
    enum GameStatus
    {
        Play,
        Close,
        Pause
    }

    class Game
    {
        public int health = 100;

        public Game(GameStatus userSetup)
        {
            SetGameStatus(userSetup);
        }


        public void SetGameStatus(GameStatus gameStatus)
        {
            switch (gameStatus)
            {
                case GameStatus.Play:
                    Console.WriteLine("Игра запущена");
                    StartGame();
                    break;
                case GameStatus.Pause:
                    Console.WriteLine("Игра на паузе");
                    PauseGame();
                    break;
                case GameStatus.Close:
                    Console.WriteLine("Игра закрыта");
                    CloseGame();
                    break;
                default:
                    break;
            }

        }

        public void StartGame()
        {
            Player player = new Player();
        }


        //public void GetInfo()
        //{
        //    Console.WriteLine($"Положение персонажа: ось х:{x}, ось у:{y}. Оружие в инвентаре {weapon}. Текущее здоровье: {health}");
        //}
        public void PauseGame()
        { 
	    }
        public void CloseGame()
        {
        }

    }
}
