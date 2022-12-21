using System;
class HelloWorld {
  static void Main() {
      Box box = new Box();
      Console.WriteLine("Current box position");
      box.ShowPos();
      Character character = new Character();
      IMoveable boxMove = new Adapter(box);
      Console.WriteLine("Character moved the box");
      character.Push(boxMove, box);
  }
}

class Character
{
    public void Push(IMoveable obj, Box box)
    {
        obj.Move(box.Pos);
    }
}

interface IMoveable
{
    void Move(Array pos);
}
class Box
{
    public int[] Pos = {123, 23, 45};
    public void ShowPos()
    {
        Console.WriteLine("x: {0}\ny: {1}\nz: {2}",Pos[0],Pos[1],Pos[2]);
    }
}
class Adapter : IMoveable
{
    Box box;
    public Adapter(Box b)
    {
        box = b;
    }
    
    public void Move(Array pos)
    {
        for (int i=0;i<pos.Length;i++)
        {
            box.Pos[i]+=(100/(i+1));
        }
        box.ShowPos();
    }
}