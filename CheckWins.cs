using System;




public abstract class CheckWins{
  
  public Boards GetBoard { get; }

  public CheckWins(Boards board){
    this.GetBoard = board;
  }

  public abstract bool CheckRowWin();
  public abstract bool CheckColumnWin();
  public abstract  bool CheckDiagonalWin();

}
public class CheckWin:CheckWins
{
  private CheckWin(CheckWinBuilder checkWinBuilder):base(checkWinBuilder.Board){
  }
  public class CheckWinBuilder{
     public Boards Board { get;set; }
    
    public CheckWinBuilder SetBoard(Boards board){
      this.Board = board;
      return this;
    }

    public CheckWin Build(){
      return new CheckWin(this);
    }
    
  }

  public static CheckWinBuilder CreateBuilderCheckWin(){
    return new CheckWinBuilder();
  }
 

  public override bool CheckRowWin(){
    for(int i=0;i<3;i++){
      if(GetBoard.board[i][0]==GetBoard.board[i][1] && GetBoard.board[i][1]==GetBoard.board[i][2]){
        return true;
      }
    }
    return false;
  }
  public override bool CheckColumnWin(){
    for(int i=0;i<3;i++){
      if(GetBoard.board[0][i]==GetBoard.board[1][i] && GetBoard.board[1][i]==GetBoard.board[2][i]){
        return true;
      }
    }
    return false;
  }
  public override bool CheckDiagonalWin(){
    if(GetBoard.board[0][0]==GetBoard.board[1][1] && GetBoard.board[1][1]==GetBoard.board[2][2]){
      return true;
    }
    if(GetBoard.board[0][2]==GetBoard.board[1][1] && GetBoard.board[1][1]==GetBoard.board[2][0]){
      return true;
    }
    return false;
  }
}