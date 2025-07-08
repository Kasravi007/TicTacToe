using System;
public abstract class Boards
{
  public  string[][] board{get;private set;} =new string[3][]{ new string[3]{"00","01","02"}, new string[3]{"10","11","12"},new string[3]{"20","21","22"}};
  public void setBoard(string[][] board){
    this.board = board;
  }
}

public class Board :Boards {
  
 
}
  