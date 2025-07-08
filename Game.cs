using System;

public abstract class Games
{
  public Players GetPlayer1 { get; }
  public Players GetPlayer2 { get; }
    protected Games(Players player1, Players player2, DashBoards dashBoard, CheckWins checkWin)
    {
        this.GetPlayer1 = player1;
        this.GetPlayer2 = player2;
        this.GetDashBoard = dashBoard;
        this.GetCheckWin = checkWin;
    }

    public CheckWins GetCheckWin { get; }
    public DashBoards GetDashBoard { get; }
    public int GetPlayCount { get; set; } = 0;

    public abstract void Play();

}
public class Game : Games
{
    private Game(GameBuilder gameBuilder) : base(gameBuilder.GetPlayer1(), gameBuilder.GetPlayer2(),gameBuilder.DashBoard,gameBuilder.CheckWin)
    {
    }

    #region Builder
    public class GameBuilder
    {
        private Players _player1;
        private Players _player2;

        public CheckWins CheckWin { get;set;}
        public DashBoards DashBoard { get;set; }

        public Players GetPlayer1()
        {
            return this._player1;
        }
        public Players GetPlayer2()
        {
            return this._player2;
        }

        public GameBuilder SetCheckWin(CheckWins checkWin){
            this.CheckWin = checkWin;
            return this;
        }
        public GameBuilder SetDashBoard(DashBoards dashBoard)
        {
            this.DashBoard = dashBoard;
            return this;    
        }

        public GameBuilder SetPlayer1(Players player1)
        {
            this._player1 = player1;
            return this;
        }
        public GameBuilder SetPlayer2(Players player2)
        {
            this._player2 = player2;
            return this;
        }

        public Game Build()
        {
            return new Game(this);
        }


    }
    #endregion

    public static GameBuilder CreateBuilderGame()
    {
        return new GameBuilder();
    }


    public override void Play()
    {
        bool win = false;
        while (GetPlayCount < 9)
        {
            var turn = GetPlayCount % 2 == 0 ? GetPlayer1 : GetPlayer2;
            var lastTurn = GetPlayCount % 2 != 0 ? GetPlayer1 : GetPlayer2;
            Console.WriteLine($"\nPlease enter your position {turn.getName()}! to place your character {turn.getCharacter()}");
            this.GetDashBoard.DisplayBoard();
            var position = Console.ReadLine();
            this.GetDashBoard.UpdateBoard(position, turn.getCharacter(),lastTurn.getCharacter());
            this.GetPlayCount++;
            win = CheckWin(turn);
            if (win)
            {
                break;
            }

        }
        if (GetPlayCount == 9 && !win)
        {
            Console.WriteLine("Game Draw");
        }
        this.GetDashBoard.DisplayBoard();

    }
    public bool CheckWin(Players turn)
    {
        if (this.GetCheckWin.CheckRowWin() || this.GetCheckWin.CheckColumnWin() || this.GetCheckWin.CheckDiagonalWin())
        {
            Console.WriteLine("\n Player " + turn.getName() + " won the game!!!!!!!!");
            return true;
        }
        return false;
    } 

}

