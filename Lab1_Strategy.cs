using System;

interface ITrigonometrical{
    void Res(double angle);
}

class Cosine:ITrigonometrical
{
    public void Res(double angle) => Console.WriteLine(Math.Cos(angle));
}
class Sine:ITrigonometrical
{
    public void Res(double angle) => Console.WriteLine(Math.Sin(angle));
}
class Tangent:ITrigonometrical
{
    public void Res(double angle) => Console.WriteLine(Math.Tan(angle));
}

class Trigonometry
{
  public ITrigonometrical Trigonometrical
  {
    private get;
    set;
  }
  public double Angle
  {
    get;
    set;
  }
  public Trigonometry (ITrigonometrical trigonometrical, double angle) => (Trigonometrical, Angle) = (trigonometrical, angle);

  public void Calculate () => Trigonometrical ?.Res(Angle);
}



class Lab1_Strategy
{
  static void Main ()
  {
    double degrees = 30;
    double angle   = Math.PI * degrees / 180.0;
    
    
    
    ITrigonometrical trigonometrical = new Cosine();
    Trigonometry trigonometry = new Trigonometry(trigonometrical, angle);
    trigonometry.Calculate();
    
    trigonometry.Trigonometrical = new Sine();
    trigonometry.Calculate();
    
    trigonometry.Trigonometrical = new Tangent();
    trigonometry.Calculate();
  }
}
