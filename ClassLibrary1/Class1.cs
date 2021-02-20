using System;

namespace ClassLibrary1
{
    public class BasicPlayer
    {
       public int health = 0;
       public int id = 0;
      protected  BettleType BettleType = BettleType.basicBattle;
    }
    public class SuperPower : BasicPlayer
    {
        BettleType BettleType = BettleType.animalBettle;
        public void Battle()
        {
            if(BettleType == BettleType.animalBettle)
            {

            }
        }
    }
    
    public enum BettleType
    {
         basicBattle=1,
         animalBettle=2
    }
}
