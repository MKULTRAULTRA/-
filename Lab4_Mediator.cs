using System;
class HelloWorld {
  static void Main() {
      ConcreteMediator mediator = new ConcreteMediator();
      Character thief = new ThiefChar(mediator);
      Character swordsman = new SwordsmanChar(mediator);
      
      mediator.Thief = thief;
      mediator.Swordsman = swordsman;

      thief.Send("Thief is weak to heavy damage");
      swordsman.Send("Swordsman is weak to poison");

  }
}

class ThiefChar : Character
{
    public ThiefChar(Mediator mediator) :base(mediator)
    {}
     
    public override void Notify(string message)
    {
        Console.WriteLine("Message to thief: " + message);
    }
}
class SwordsmanChar : Character
{
    public SwordsmanChar(Mediator mediator) :base(mediator)
    {} 
 
    public override void Notify(string message)
    {
        Console.WriteLine("Message to swordsman: " + message);
    }
}
abstract class Character
{
    protected Mediator mediator;
 
    public Character(Mediator mediator)
    {
        this.mediator = mediator;
    }
 
    public virtual void Send(string message)
    {
        mediator.Send(message, this);
    }
    public abstract void Notify(string message);
}

abstract class Mediator
{
    public abstract void Send(string msg, Character character);
}


class ConcreteMediator : Mediator
{
    public Character Thief { get; set; }
    public Character Swordsman { get; set; }
    public override void Send(string msg, Character character)
    {
        if (character == Thief)
            Thief.Notify(msg);
        else if(character == Swordsman)
            Swordsman.Notify(msg);

    }
}