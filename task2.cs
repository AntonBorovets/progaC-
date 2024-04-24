using System;

public class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        DateTime today = DateTime.Today;
        int experienceYears = today.Year - hiringDate.Year;

        // Adjusting experience calculation based on the hiring date
        if (hiringDate > today.AddYears(-experienceYears))
        {
            experienceYears--;
        }

        return experienceYears;
    }

    public virtual void ShowInfo()
    {
        int yearsOfExperience = Experience();
        Console.WriteLine($"{name} has {yearsOfExperience} year(s) of experience");
    }
}

public class Developer : Employee
{
    private string programmingLanguage;

    public Developer(string name, DateTime hiringDate, string programmingLanguage)
        : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public override void ShowInfo()
    {
        base.ShowInfo(); // Reuse base class method to display common information
        Console.WriteLine($"{name} is a {programmingLanguage} programmer");
    }
}

public class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation)
        : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public override void ShowInfo()
    {
        int yearsOfExperience = Experience();
        string testerType = isAutomation ? "automated" : "manual";
        Console.WriteLine($"{name} is {testerType} tester and has {yearsOfExperience} year(s) of experience");
    }
}

class Program
{
    static void Main()
    {
        Developer dev = new Developer("John Doe", new DateTime(2010, 5, 15), "C#");
        dev.ShowInfo();
        Console.WriteLine();

        Tester automatedTester = new Tester("Alice Smith", new DateTime(2015, 8, 20), true);
        automatedTester.ShowInfo();
        Console.WriteLine();

        Tester manualTester = new Tester("Bob Johnson", new DateTime(2013, 10, 10), false);
        manualTester.ShowInfo();
    }
}
