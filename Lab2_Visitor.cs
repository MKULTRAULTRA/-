using System;
using System.Collections.Generic;

interface IPlace
{

    void Accept(IVisitor visitor);
}
 
class Room : IPlace
{
   
    public string Address { get; set;}
    public int Floor {get; set;}
    
    
    public void Accept(IVisitor visitor)
    {
        visitor.VisitRoom(this);
    }
}
 
class Mansion : IPlace
{
    public string Address { get; set;}
    public int Size { get; set; }
 
    public void Accept(IVisitor visitor)
    {
        visitor.VisitMansion(this);
    }
}

class District
{
    List<IPlace> places = new List<IPlace>();
    public void Add(IPlace place)
    {
        places.Add(place);
    }
    public void Remove(IPlace place)
    {
        places.Remove(place);
    }
    public void Accept(IVisitor visitor)
    {
        foreach (IPlace place in places)
            place.Accept(visitor);
    }
}

interface IVisitor
{
    void VisitRoom(Room room);
    void VisitMansion(Mansion mansion);
}
 

class CasualVisitor : IVisitor
{
    public void VisitRoom(Room room)
    {
        Console.WriteLine("{0} visited by {1}\nRoom floor: {2}\n-Looks good", room.Address , this.GetType().Name, room.Floor);
    }
 
    public void VisitMansion(Mansion mansion)
    {
        Console.WriteLine("{0} visited by {1}\nMansion size in squares: {2}\n-Looks great", mansion.Address, this.GetType().Name, mansion.Size);
    }
}
 
class ProfessionalVisitor : IVisitor
{
    public void VisitRoom(Room room)
    {
       Console.WriteLine("{0} visited by {1}\nRoom floor: {2}\n-Many layout errors!", room.Address , this.GetType().Name, room.Floor);
    }
 
    public void VisitMansion(Mansion mansion)
    {
        Console.WriteLine("{0} visited by {1}\nMansion size in squares: {2}\n-This mansion is too old and in need of restoration", mansion.Address, this.GetType().Name, mansion.Size);
    }
}
 
class HelloWorld
{
    static void Main()
    {
        var structure = new District();
        structure.Add(new Room { Address = "King's Row, 144", Floor = 5 });
        structure.Add(new Mansion {Address = "King's Row, 145", Size = 2400});
        structure.Accept(new CasualVisitor());
        structure.Accept(new ProfessionalVisitor());
    }
}
