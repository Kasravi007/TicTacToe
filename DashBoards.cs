using System;

public abstract class DashBoards
{
   public Boards GetBoard { get; }

  public DashBoards(Boards board){
    this.GetBoard = board;
  }
  public virtual void DisplayBoard(){
    Console.WriteLine("\nCurrent Board:\n");
    var board = this.GetBoard.board;
    for(int i = 0; i < 3; i++){
      Console.WriteLine($"{board[i][0]} | {board[i][1]} | {board[i][2]}");
      if(i < 2) Console.WriteLine("---------");
    }
    Console.WriteLine();
  }

  public virtual void UpdateBoard(string position,string character,string lastTurnCharacter){
    try{
    var updatedBoard = this.GetBoard.board;
      if(updatedBoard[position[0]-'0'][position[1]-'0'] == character || updatedBoard[position[0]-'0'][position[1]-'0'] == lastTurnCharacter){
        Console.WriteLine("Occupied Position. Please enter a available position");
        var newPosition = Console.ReadLine();
        UpdateBoard( newPosition, character,lastTurnCharacter);
      }else{
    updatedBoard[position[0]-'0'][position[1]-'0'] = character;
    this.GetBoard.setBoard(updatedBoard);
        }
      }
    catch(IndexOutOfRangeException ex){
      Console.WriteLine("Invalid Position. Please enter a valid position");
      var newPosition = Console.ReadLine();
      UpdateBoard( newPosition, character,lastTurnCharacter);

    }catch(Exception ex)
    {
      Console.WriteLine($"{ex.Message}");
    }
  } 
}

public class DashBoard:DashBoards{

  private DashBoard  (DashBoardBuilder dashBoardBuilder):base(dashBoardBuilder.board){
  }

  public static DashBoardBuilder CreateBuilderDashBoard(){
    return DashBoardBuilder.CreateBuilderDashBoard();
  }

  #region Builder
  public class DashBoardBuilder
  {
    public  Boards board{get; private set;}

    private DashBoardBuilder(){
    }

    public DashBoardBuilder SetBoard(Boards board){
      this.board = board;
      return this;
    }
    public DashBoard Build(){
      return new DashBoard(this);
    }
    public static DashBoardBuilder CreateBuilderDashBoard(){
      return new DashBoardBuilder();
    }
    
    
  }
  #endregion
 
}