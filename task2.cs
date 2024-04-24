using System;
using System.IO;

class Book
{
    // Оголосимо делегат у класі Book
    public delegate void BookAction();

    public string Author;
    public int ReleaseDate;

    public Book()
    {
        Author = "Unknown";
        ReleaseDate = 0;
    }

    public Book(string author, int releaseDate)
    {
        Author = author;
        ReleaseDate = releaseDate;
    }

    // Метод, який буде викликати делегат
    public void Display()
    {
        Console.WriteLine($"=======================================");
        Console.WriteLine($"Author: {Author}, released in: {ReleaseDate}");
    }

    // Метод для введення даних про книгу
    public void Input()
    {
        Console.Write("Enter author: ");
        Author = Console.ReadLine();

        Console.Write("Enter release date: ");
        int.TryParse(Console.ReadLine(), out ReleaseDate);
    }

    // Метод для зміни інформації про книгу
    public void EditBook()
    {
        Console.WriteLine("Editing book information...");
        Input();
    }

    // Метод для реєстрації делегата
    public void RegisterActionDelegate(BookAction delegateMethod)
    {
        BookAction += delegateMethod;
    }

    // Метод для видалення делегата
    public void UnregisterActionDelegate(BookAction delegateMethod)
    {
        BookAction -= delegateMethod;
    }

    // Виклик делегата
    public void InvokeActionDelegate()
    {
        BookAction?.Invoke();
    }

    private BookAction BookAction; // Поле делегата
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();

        // Реєстрація методів як делегатів
        book.RegisterActionDelegate(new Book.BookAction(book.Display));
        book.RegisterActionDelegate(new Book.BookAction(book.EditBook));

        // Виклик методів через делегат
        book.InvokeActionDelegate();

        // Зчитування книг з файлу
        try
        {
            ReadBooksFromFile();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ReadBooksFromFile()
    {
        Console.WriteLine("Reading books information from file...");

        string filePath = "books.txt";
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The file does not exist.", filePath);
        }

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string author = parts[0].Trim();
                    int releaseDate;
                    if (int.TryParse(parts[1].Trim(), out releaseDate))
                    {
                        Book book = new Book(author, releaseDate);
                        book.Display();
                    }
                    else
                    {
                        throw new IOException("Invalid release date format in file.");
                    }
                }
                else
                {
                    throw new IOException("Invalid data format in file.");
                }
            }
        }
    }
}
