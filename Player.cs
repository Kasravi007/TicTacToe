using System;

public class Player: Players
{
   
  
  private Player(PlayerBuilder playerBuilder):base(playerBuilder.GetName(), playerBuilder.GetCharacter()){
      
  }
  
  #region Builder
  public class PlayerBuilder
    {
        private PlayerBuilder(){
            
        }
    private string _name;
    private string _character;

      public string GetName()
      {
        return this._name;
      }
        
      public string GetCharacter()
      {
            return this._character;
      }
        
    public PlayerBuilder SetName(string name){
        this._name = name;
        return this;
    }
        
    public PlayerBuilder SetCharacter(string character){
        this._character = character;
        return this;
    }
        public static PlayerBuilder CreateBuilderPlayer(){ //inside inner class 
           return new PlayerBuilder();
        }
        
    public Player Build(){
        return new Player(this);
    }
    
  }
  #endregion

  public static PlayerBuilder CreateBuilderPlayer(){ //outside of inner class 
      return PlayerBuilder.CreateBuilderPlayer();
  }
    
}



//Abstract class for Players

public abstract class Players
{

private string _name;
private  string _character;

protected Players(string name, string character)
  {
    this._name = name;
    this._character = character;
}
public string getName(){
  return this._name;
}
public string getCharacter(){
  return this._character;
}


}



    
  