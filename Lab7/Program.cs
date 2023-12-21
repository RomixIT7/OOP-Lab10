using System;
using System.Collections.Generic;
using System.Linq;
using SimpleClassLibrary;

class Program
{
    static void Main()
    {
        Console.WriteLine("Оберіть завдання:");
        Console.WriteLine("1. Робота з SortedList");
        Console.WriteLine("2. Робота з Dictionary");
        Console.WriteLine("3. Закінчити програму");

        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 3))
        {
            Console.WriteLine("Будь ласка, введіть коректне число від 1 до 3.");
        }

        switch (choice)
        {
            case 1:
                WorkWithSortedList();
                break;
            case 2:
                WorkWithDictionary();
                break;
            case 3:
                Environment.Exit(0);
                break;
        }
    }

    static void WorkWithSortedList()
    {
        SortedList<string, double> sortedList = new SortedList<string, double>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Додати елемент");
            Console.WriteLine("2. Сортувати елементи за зростанням значення");
            Console.WriteLine("3. Показати елементи");
            Console.WriteLine("4. Закінчити роботу з SortedList");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 4))
            {
                Console.WriteLine("Будь ласка, введіть коректне число від 1 до 4.");
            }

            switch (choice)
            {
                case 1:
                    AddElementToSortedList(sortedList);
                    break;
                case 2:
                    SortListAscending(sortedList);
                    break;
                case 3:
                    ShowElements(sortedList);
                    break;
                case 4:
                    return;
            }
        }
    }

    static void AddElementToSortedList(SortedList<string, double> sortedList)
    {
        Console.Write("Введіть ім'я: ");
        string name = Console.ReadLine();

        double value;

        Console.Write("Введіть значення: ");

        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Будь ласка, введіть коректне значення.");
        }

        sortedList.Add(name, value);
        Console.WriteLine("Елемент успішно доданий. Натисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static void SortListAscending(SortedList<string, double> sortedList)
    {
        var sortedItems = sortedList.OrderBy(x => x.Value).ToList();

        Console.Clear();
        Console.WriteLine("Елементи колекції SortedList (відсортовані за зростанням значення):");

        foreach (var item in sortedItems)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }


    static void ShowElements(SortedList<string, double> sortedList)
    {
        Console.Clear();
        Console.WriteLine("Елементи колекції SortedList:");

        for (int i = 0; i < sortedList.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {sortedList.Keys[i]} - {sortedList.Values[i]}");
        }

        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static void WorkWithDictionary()
    {
        Dictionary<string, Worker> workersDictionary = new Dictionary<string, Worker>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Додати працівника");
            Console.WriteLine("2. Видалити працівника");
            Console.WriteLine("3. Знайти працівника");
            Console.WriteLine("4. Показати кількість працівників");
            Console.WriteLine("5. Очистити список працівників");
            Console.WriteLine("6. Закінчити роботу з Dictionary");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 6))
            {
                Console.WriteLine("Будь ласка, введіть коректне число від 1 до 6.");
            }

            switch (choice)
            {
                case 1:
                    AddWorkerToDictionary(workersDictionary);
                    break;
                case 2:
                    RemoveWorkerFromDictionary(workersDictionary);
                    break;
                case 3:
                    FindWorkerInDictionary(workersDictionary);
                    break;
                case 4:
                    ShowNumberOfWorkers(workersDictionary);
                    break;
                case 5:
                    workersDictionary.Clear();
                    Console.WriteLine("Список працівників очищено. Натисніть Enter, щоб продовжити...");
                    Console.ReadLine();
                    break;
                case 6:
                    return;
            }
        }
    }

    static void AddWorkerToDictionary(Dictionary<string, Worker> workersDictionary)
    {
        Worker newWorker = Worker.CreateWorkerFromConsole();
        workersDictionary.Add(newWorker.FullName, newWorker);
        Console.WriteLine("Працівник успішно доданий. Натисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static void RemoveWorkerFromDictionary(Dictionary<string, Worker> workersDictionary)
    {
        Console.Write("Введіть прізвище працівника для видалення: ");
        string lastName = Console.ReadLine();

        if (workersDictionary.ContainsKey(lastName))
        {
            workersDictionary.Remove(lastName);
            Console.WriteLine("Працівник успішно видалений. Натисніть Enter, щоб продовжити...");
        }
        else
        {
            Console.WriteLine($"Працівник із прізвищем {lastName} не знайдений.");
        }

        Console.ReadLine();
    }

    static void FindWorkerInDictionary(Dictionary<string, Worker> workersDictionary)
    {
        Console.Write("Введіть прізвище працівника для пошуку: ");
        string lastName = Console.ReadLine();

        if (workersDictionary.ContainsKey(lastName))
        {
            DisplayWorkerInfo(workersDictionary[lastName]);
        }
        else
        {
            Console.WriteLine($"Працівник із прізвищем {lastName} не знайдений.");
        }
    }

    static void ShowNumberOfWorkers(Dictionary<string, Worker> workersDictionary)
    {
        Console.WriteLine($"Кількість працівників: {workersDictionary.Count}");
        Console.WriteLine("Натисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static void DisplayWorkerInfo(Worker worker)
    {
        Console.Clear();
        Console.WriteLine(worker.ToString());
        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }
}
