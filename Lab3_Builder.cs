
using System;

class Weapon
{
    public int DamageStats {get; set;}
}
class Armor
{
    public int ArmorStats {get; set;}
}
class Ring
{
    public string RingStats {get; set;}
}

class Character
{
    public Weapon Weapon {get; set;}
    public Armor Armor {get; set;}
    public Ring Ring{get; set;}
    public void showStats()
    {
        Console.WriteLine("Damage: "+ Weapon.DamageStats +"\nArmor: "+ Armor.ArmorStats + "\nCurrentRing: " + Ring.RingStats);
        
    }
}

class Director
{
    public Character Make(CharacterBuilder characterBuilder)
    {
        characterBuilder.CreateCharacter();
        characterBuilder.SetArmor();
        characterBuilder.SetWeapon();
        characterBuilder.SetRing();
        return characterBuilder.Character;
    }
}

abstract class CharacterBuilder
{
    public Character Character{ get; set; }
    public void CreateCharacter()
    {
        Character = new Character();
    }
    public abstract void SetWeapon();
    public abstract void SetArmor();
    public abstract void SetRing();
}

class WarriorBuilder : CharacterBuilder
{
    public override void SetArmor()
    {
        this.Character.Armor = new Armor { ArmorStats = 40 };
    }
 
    public override void SetWeapon()
    {
        this.Character.Weapon = new Weapon { DamageStats = 30 };
    }
 
    public override void SetRing()
    {
        this.Character.Ring = new Ring{ RingStats = "Ring of power" };
    }
}
class PeasantBuilder : CharacterBuilder
{
    public override void SetArmor()
    {
        this.Character.Armor = new Armor { ArmorStats = 10 };
    }
 
    public override void SetWeapon()
    {
        this.Character.Weapon = new Weapon { DamageStats = 5 };
    }
 
    public override void SetRing()
    {
        this.Character.Ring = new Ring{ RingStats = "Ring of madness" };
    }
}

class HelloWorld {
  static void Main() {
    Director maker = new Director();
    CharacterBuilder peasant_builder = new PeasantBuilder();
    CharacterBuilder warrior_builder = new WarriorBuilder();
    Character peasant = maker.Make(peasant_builder);
    peasant.showStats();
    Character warrior = maker.Make(warrior_builder);
    warrior.showStats();
  }
}