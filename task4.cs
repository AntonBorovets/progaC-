using System;

public interface ISwimmable
{
    void Swim();
}

public interface IFlyable
{
    int MaxHeight { get; }
    void Fly();
}

public interface IRunnable
{
    int MaxSpeed { get; }
    void Run();
}

public interface IAnimal
{
    int LifeExpectancy { get; }
    void MakeSound();
    void DisplayInformation();
}

public class Cat : IAnimal, IRunnable
{
    public int LifeExpectancy { get; } = 15; // Cats live around 15 years
    public int MaxSpeed { get; } = 30; // Cats can run up to 30 km/h

    public void MakeSound()
    {
        Console.WriteLine("Meow!");
    }

    public void Run()
    {
        Console.WriteLine($"I can run at speeds up to {MaxSpeed} kilometers per hour.");
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"I am a Cat and I live for about {LifeExpectancy} years.");
    }
}

public class Eagle : IAnimal, IFlyable
{
    public int LifeExpectancy { get; } = 25; // Eagles live around 25 years
    public int MaxHeight { get; } = 5000; // Eagles can fly up to 5000 meters

    public void MakeSound()
    {
        Console.WriteLine("No vocalization!");
    }

    public void Fly()
    {
        Console.WriteLine($"I can soar up to {MaxHeight} meters in the sky!");
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"I am an Eagle and my lifespan is about {LifeExpectancy} years.");
    }
}

public class Shark : IAnimal, ISwimmable
{
    public int LifeExpectancy { get; } = 30; // Sharks live around 30 years

    public void MakeSound()
    {
        Console.WriteLine("No vocalization!");
    }

    public void Swim()
    {
        Console.WriteLine("I can swim gracefully through the waters.");
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"I am a Shark and my lifespan is approximately {LifeExpectancy} years.");
    }
}

class Program
{
    static void Main(string[] args)
    {

        Cat cat = new Cat();
        cat.DisplayInformation(); // Output: I am a Cat and I live for about 15 years.
        cat.MakeSound();          // Output: Meow!
        cat.Run();                // Output: I can run at speeds up to 30 kilometers per hour.

        Console.WriteLine();

        Eagle eagle = new Eagle();
        eagle.DisplayInformation(); // Output: I am an Eagle and my lifespan is about 25 years.
        eagle.MakeSound();          // Output: No vocalization!
        eagle.Fly();                // Output: I can soar up to 5000 meters in the sky!

        Console.WriteLine();

        Shark shark = new Shark();
        shark.DisplayInformation(); // Output: I am a Shark and my lifespan is approximately 30 years.
        shark.MakeSound();          // Output: No vocalization!
        shark.Swim();               // Output: I can swim gracefully through the waters.
    }
}
