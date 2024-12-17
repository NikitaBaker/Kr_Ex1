using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8; // Кодування, яке використовується для виведення тексту в консоль.

        // Імена файлів для читання та запису
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        ReadAndDisplayFile(inputFile); // Зчитування тексту з файлу input.txt та виведення його вмісту в консоль
        string newText = ValidateUserInput(); // Запит введення нового тексту від користувача
        AppendToFile(outputFile, newText); // Додавання нового тексту до файлу output.txt
    }

    static void ReadAndDisplayFile(string filename) // Метод для зчитування вмісту файлу та виведення його у консоль
    {
        try
        {
            if (File.Exists(filename)) // Перевірка, чи існує файл
            {
                string content = File.ReadAllText(filename); // Зчитування всього тексту з файлу
                Console.WriteLine($"Вміст файлу {filename}: {content}"); // Вивід зчитанного тексту
            }
            else
            {
                Console.WriteLine($"Файл {filename} не знайдено."); // Повідомлення, якщо файл не знайдено
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка при читанні файлу {filename}: {ex.Message}"); // Вивід помилки, якщо вона сталася
        }
    }

    static string ValidateUserInput() // Метод для перевірки введення користувача
    {
        string userInput;
        do
        {
            // Запит користувача на введення тексту
            Console.Write("\nВведіть новий текст (не порожній рядок): ");
            userInput = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(userInput)) // Перевірка, чи рядок не є порожнім
            {
                Console.WriteLine("Введення не може бути порожнім. Спробуйте ще раз.");
            }
        } while (string.IsNullOrEmpty(userInput)); // Повторний запит, якщо введення некоректне

        return userInput; // Повернення коректного тексту
    }

    static void AppendToFile(string filename, string text) // Метод для додавання тексту до файлу
    {
        try
        {
            // Відкриття файлу у режимі запису (додавання)
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(text); // Запис тексту у файл
                Console.WriteLine($"Текст успішно додано до файлу {filename}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка при записі до файлу {filename}: {ex.Message}"); // Вивід помилки, якщо вона сталася
        }
    }
}
