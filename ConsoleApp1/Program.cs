using System;
using System.Text;

class Employee
{

    // Поля для збереження прізвища та імені співробітника
    private string lastName;
    private string firstName;

    // Поля для посади та стажу
    private string position;
    private int experience;

    // Конструктор
    public Employee(string lastName, string firstName, string position, int experience)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.position = position;
        this.experience = experience;
    }

    // Метод для розрахунку окладу
    public double CalculateSalary()
    {
        double baseSalary;

        // Визначення базового окладу залежно від посади
        switch (position.ToLower())
        {
            case "менеджер":
                baseSalary = 1000;
                break;
            case "інженер":
                baseSalary = 800;
                break;
            case "робітник":
                baseSalary = 600;
                break;
            default:
                baseSalary = 500;
                break;
        }

        // Додавання надбавки за стаж
        double experienceBonus = experience * 50;
        return baseSalary + experienceBonus;
    }

    // Метод для розрахунку податкового збору
    public double CalculateTax()
    {
        double salary = CalculateSalary();
        return salary * 0.2; // 20% податковий збір
    }

    // Метод для виведення інформації про співробітника
    public void DisplayInfo()
    {
        Console.WriteLine($"Прізвище: {lastName}");
        Console.WriteLine($"Ім'я: {firstName}");
        Console.WriteLine($"Посада: {position}");
        Console.WriteLine($"Оклад: {CalculateSalary():F2}");
        Console.WriteLine($"Податковий збір: {CalculateTax():F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding +

        // Зчитування інформації про співробітника від користувача
        Console.Write("Введіть прізвище співробітника: ");
        string lastName = Console.ReadLine();

        Console.Write("Введіть ім'я співробітника: ");
        string firstName = Console.ReadLine();

        Console.Write("Введіть посаду співробітника: ");
        string position = Console.ReadLine();

        Console.Write("Введіть стаж роботи (у роках): ");
        int experience = int.Parse(Console.ReadLine());

        // Створення об'єкта класу Employee
        Employee employee = new Employee(lastName, firstName, position, experience);

        // Виведення інформації про співробітника
        Console.WriteLine("\nІнформація про співробітника:");
        employee.DisplayInfo();
    }
}
