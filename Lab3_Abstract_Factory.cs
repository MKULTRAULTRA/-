using System;

abstract class Weapon
{
    public abstract void DamageStats();
}
abstract class Gear
{
    public abstract void DefenseStats();
}
 
class GreatSword : Weapon
{
    public override void DamageStats()
    {
        Console.WriteLine("+30 dmg");
    }
}
class Dagger : Weapon
{
    public override void DamageStats()
    {
        Console.WriteLine("+10 dmg");
    }
}
class Armor : Gear
{
    public override void DefenseStats()
    {
        Console.WriteLine("+30 armor");
    }
}
class Tunic : Gear
{
    public override void DefenseStats()
    {
        Console.WriteLine("+1 armor");
    }
}
abstract class Character_class
{
    public abstract Gear CreateGear();
    public abstract Weapon CreateWeapon();
}

class Warrior : Character_class
{
    public override Gear CreateGear()
    {
        return new Armor();
    }
 
    public override Weapon CreateWeapon()
    {
        return new GreatSword();
    }
}
class Peasant : Character_class
{
    public override Gear CreateGear()
    {
        return new Tunic();
    }
 
    public override Weapon CreateWeapon()
    {
        return new Dagger();
    }
}

class Character
{
    private Gear gear;
    private Weapon weapon;
    
    
    public Character(Character_class character_class)
    {
        gear = character_class.CreateGear();
        weapon = character_class.CreateWeapon();
    }
    public void ShowStats()
    {
        gear.DefenseStats();
        weapon.DamageStats();
    }
}

class HelloWorld {
  static void Main() {
    Character main_char = new Character(new Warrior());
    main_char.ShowStats();
    main_char = new Character(new Peasant());
    main_char.ShowStats();
  }
}

