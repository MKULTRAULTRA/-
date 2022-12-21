using System;
abstract class Trigonometry
{
    public void Functions(double angle)
    {
        Cosine(angle);
        Sine(angle);
        Tan(angle);
    }
    public abstract void Cosine(double angle);
    public abstract void Sine(double angle);
    public abstract void Tan(double angle);
}

class Rads : Trigonometry
{
    public override void Cosine(double angle)
        => Console.WriteLine(Math.Cos(angle));
    public override void Sine(double angle)
        => Console.WriteLine(Math.Sin(angle));
    public override void Tan(double angle)
        => Console.WriteLine(Math.Tan(angle));
}
class Lab1_Template 
{
  static void Main() 
  {
    double degrees = 30;
    double angle   = Math.PI * degrees / 180.0;
    Trigonometry test1 = new Rads();
    test1.Functions(angle);
  }
}
