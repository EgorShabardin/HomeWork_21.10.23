using System;
using System.IO;
using System.Collections.Generic;

namespace Тумаков___Лабораторная_работа__8
{
    class Program
    {
        /// <summary>
        /// Метод, меняющий порядок следования символов в строке на обратный.
        /// </summary>
        /// <param name="sourceString"> Исходная строка. </param>
        /// <returns> Измененная строка </returns>
        static string ReversesTheOrderOfCharactersInString(string sourceString)
        {
            char[] stringCharacterArray = sourceString.ToCharArray();

            Array.Reverse(stringCharacterArray);

            return String.Concat(stringCharacterArray);
        }

        /// <summary>
        /// Метод, проверяющий реализует ли входной параметр интерфейс System.IFormattable с помощью is.
        /// </summary>
        /// <param name="checkedObject"> Проверяемый объект. </param>
        /// <returns> Возвращает true, если объект реализует интерфейс System.IFormattable, иначе false. </returns>
        static bool ChecksObjectImplementsIFormattableUsingIs(object checkedObject)
        {
            if (checkedObject is IFormattable)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, проверяющий реализует ли входной параметр интерфейс System.IFormattable с помощью as.
        /// </summary>
        /// <param name="checkedObject"> Проверяемый объект. </param>
        /// <returns> Возвращает true, если объект реализует интерфейс System.IFormattable, иначе false. </returns>
        static bool ChecksObjectImplementsIFormattableUsingAs(object checkedObject)
        {
            if (checkedObject as IFormattable == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод, получающий строку с данными и выделяющий из нее Email.
        /// </summary>
        /// <param name="dataString"> Строка с данными. </param>
        /// <returns> Возвращает true, если выделить Email получилось, false в обратном случае. </returns>
        static bool ExtractingEmailFromDataString(ref string dataString)
        {
            string[] data = dataString.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length == 2)
            {
                dataString = data[1];
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 81}", "ТУМАКОВ - ЛАБОРАТОРНАЯ РАБОТА №8. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 8.1. Программа из Упражнения 7.3, но добавлен метод перевода денег с одного счета на другой      -   цифра 1\n" +
                                  "Упражнение 8.2. Программа получает строку и возвращает новую, символы в которой идут в обратном порядке     -   цифра 2\n" +
                                  "Упражнение 8.3. Программа записывает в выходной файл содержимое исходного файла, но заглавными буквами      -   цифра 3\n" +
                                  "Упражнение 8.4. Программа проверяет реализует ли передаваемый объект интерфейс System.IFormattable          -   цифра 4\n" +
                                  "Домашнее задание 8.1. Программа выделяет из входного файла с данными e-mail и записывает его в новом файле  -   цифра 5\n" +
                                  "Домашнее задание 8.2. Программа создает список песен, выводит их на экран и сравнивает две из них           -   цифра 6\n" +
                                  "Закончить выполнение заданий и выйти из программы                                                           -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Упражнение 8.1. Программа из Упражнения 7.3, но добавлен метод перевода денег с одного счета на другой.
                        Console.Clear();
                        Console.WriteLine("{0, 112}", "УПРАЖНЕНИЕ 8.1. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 7.3, НО ДОБАВЛЕН МЕТОД ПЕРЕВОДА ДЕНЕГ С ОДНОГО СЧЕТА НА ДРУГОЙ\n");

                        BankAccount firstBankAccount = new BankAccount(AccountType.Текущий_счет);
                        BankAccount secondBankAccount = new BankAccount(AccountType.Текущий_счет);
                        bool putMoneyResult, transferringMoneyResult;

                        putMoneyResult = firstBankAccount.PutMoneyIntoAccount(500000.55M);
                        putMoneyResult &= secondBankAccount.PutMoneyIntoAccount(100000.87M);

                        if (putMoneyResult)
                        {
                            Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                              $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");

                            transferringMoneyResult = firstBankAccount.TransferringMoney(secondBankAccount, 50000.87M);

                            if (transferringMoneyResult)
                            {
                                Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                                  $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");
                            }
                            else
                            {
                                Console.WriteLine("На банковском счету недостаточно средств или вы неверно ввели сумму!");
                            }

                            transferringMoneyResult = secondBankAccount.TransferringMoney(firstBankAccount, 500000);

                            if (transferringMoneyResult)
                            {
                                Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                                  $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");
                            }
                            else
                            {
                                Console.WriteLine("На банковском счету недостаточно средств или вы неверно ввели сумму!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы неверно ввели сумму!");
                        }

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        // Упражнение 8.2. Программа получает строку и возвращает новую, символы в которой идут в обратном порядке.
                        Console.Clear();
                        Console.WriteLine("{0, 111}", "УПРАЖНЕНИЕ 8.2. ПРОГРАММА ПОЛУЧАЕТ СТРОКУ И ВОЗВРАЩАЕТ НОВУЮ, СИМВОЛЫ В КОТОРОЙ ИДУТ В ОБРАТНОМ ПОРЯДКЕ\n");

                        string userString, newString;

                        Console.Write("Введите строку: ");
                        userString = Console.ReadLine();

                        newString = ReversesTheOrderOfCharactersInString(userString);
                        Console.Write($"Из строки {userString} получилась строка: {newString}");

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        // Упражнение 8.3. Программа записывает в выходной файл содержимое исходного файла, но заглавными буквами.
                        Console.Clear();
                        Console.WriteLine("{0, 111}", "УПРАЖНЕНИЕ 8.3. ПРОГРАММА ЗАПИСЫВАЕТ В ВЫХОДНОЙ ФАЙЛ СОДЕРЖИМОЕ ИСХОДНОГО ФАЙЛА, НО ЗАГЛАВНЫМИ БУКВАМИ\n");

                        string path;
                        string[] fileContents;

                        Console.Write("Введите путь к файлу: ");
                        path = Console.ReadLine();

                        if (File.Exists(path))
                        {
                            fileContents = File.ReadAllLines(path);

                            for (int i = 0; i < fileContents.Length; i++)
                            {
                                File.AppendAllText(path + "/../newFile.txt", fileContents[i].ToUpper() + Environment.NewLine);
                            }

                            Console.WriteLine("Обработка прошла успешно. Рядом с исходным файлом добавлен новый!");
                            Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Данного файла не существует! Повторите попытку!");
                            Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        
                        break;
                    case "4":
                        // Упражнение 8.4. Программа проверяет реализует ли передаваемый объект интерфейс System.IFormattable.
                        Console.Clear();
                        Console.WriteLine("{0, 111}", "УПРАЖНЕНИЕ 8.4. ПРОГРАММА ПРОВЕРЯЕТ РЕАЛИЗУЕТ ЛИ ПЕРЕДАВАЕМЫЙ ОБЪЕКТ ИНТРЕФЕЙС System.IFormattable\n");

                        ClassImplementingIFormattables firstObject = new ClassImplementingIFormattables();
                        BankAccount secondObject = new BankAccount(AccountType.Текущий_счет);

                        if (ChecksObjectImplementsIFormattableUsingIs(firstObject))
                        {
                            Console.WriteLine("Объект реализует интерфейс System.IFormattable");
                        }
                        else
                        {
                            Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
                        }

                        if (ChecksObjectImplementsIFormattableUsingIs(secondObject))
                        {
                            Console.WriteLine("Объект реализует интерфейс System.IFormattable");
                        }
                        else
                        {
                            Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
                        }

                        if (ChecksObjectImplementsIFormattableUsingAs(firstObject))
                        {
                            Console.WriteLine("Объект реализует интерфейс System.IFormattable");
                        }
                        else
                        {
                            Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
                        }

                        if (ChecksObjectImplementsIFormattableUsingAs(secondObject))
                        {
                            Console.WriteLine("Объект реализует интерфейс System.IFormattable");
                        }
                        else
                        {
                            Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
                        }

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":
                        // Домашнее задание 8.1. Программа выделяет из входного файла с данными e-mail и записывает его в новом файле.
                        Console.Clear();
                        Console.WriteLine("{0, 113}", "ДОМАШНЕЕ ЗАДАНИЕ 8.1. ПРОГРАММА ВЫДЕЛЯЕТ ИЗ ВХОДНОГО ФАЙЛА С ДАННЫМИ E-MAIL И ЗАПИСЫВАЕТ ЕГО В НОВОМ ФАЙЛЕ\n");

                        bool extractingResult;
                        string[] dataFile = File.ReadAllLines("ProgramFiles/DataFile.txt");

                        for (int i = 0; i < dataFile.Length; i++)
                        {
                            string dataString = dataFile[i];
                            extractingResult = ExtractingEmailFromDataString(ref dataString);
                            if (extractingResult)
                            {
                                File.AppendAllText("ProgramFiles/EmailFile.txt", dataString + Environment.NewLine);
                            }
                            else
                            {
                                Console.WriteLine("Входные данные заполнены с ошибкой. Проверьте входной файл!");
                                break;
                            }
                        }

                        Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "6":
                        // Домашнее задание 8.2. Программа создает список песен, выводит их на экран и сравнивает две из них.
                        Console.Clear();
                        Console.WriteLine("{0, 110}", "ДОМАШНЕЕ ЗАДАНИЕ 8.2. ПРОГРАММА СОЗДАЕТ СПИСОК ПЕСЕН, ВЫВОДИТ ИХ НА ЭКРАН И СРАВНИВАЕТ ДВЕ ИЗ НИХ\n");

                        Song firstSong = new Song("Я Русский", "Shaman");
                        Song secondSong = new Song("Моя Россия", "Shaman", firstSong);
                        Song thirdSong = new Song("Вороны мои", "Shaman", secondSong);
                        Song fourthSong = new Song("Гимн России", "Shaman", thirdSong);

                        List<Song> songList = new List<Song> { firstSong, secondSong, thirdSong, fourthSong };

                        foreach (Song song in songList)
                        {
                            Console.WriteLine(song.Title);
                        }

                        if (firstSong.Equals(secondSong))
                        {
                            Console.WriteLine("\nПесни равны!");
                        }
                        else
                        {
                            Console.WriteLine("\nПесни неравны!");
                        }

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("{0, 69}", "ВЫ ВЫШЛИ ИЗ ПРОГРАММЫ");
                        tasksEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("{0, 98}", "ТАКОГО ЗАДАНИЯ НЕТ! ДОСТУПНЫЕ ЗАДАНИЯ УКАЗАНЫ В ПОДСКАЗКЕ. ПОВТОРИТЕ ПОПЫТКУ\n");
                        break;
                }
            } while (!tasksEnd);
        }
    }
}
