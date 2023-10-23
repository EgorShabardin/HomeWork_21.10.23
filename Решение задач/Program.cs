using System;

namespace Решение_задач
{
    /// <summary>
    /// Перечислимый тип, содержащий виды мест работы.
    /// </summary>
    enum WorkingDepartments
    {
        системщики,
        разработчики,
        начальство,
    }
    class Program
    {
        static void Main()
        {
            // Программа создает иерархию сотрудников, дает им задачи и выводит на экран, берут они ее или нет.
            Console.WriteLine("{0, 108}", "ПРОГРАММА СОЗДАЕТ ИЕРАРХИЮ СОТРУДНИКОВ, ДАЕТ ИМ ЗАДАЧИ И ВЫВОДИТ НА ЭКРАН, БЕРУТ ОНИ ЕЕ ИЛИ НЕТ\n");

            #region Иерархия сотрудников компании
            Employee Semyon = new Employee("Семен", "Генеральный директор", WorkingDepartments.начальство);

            Employee Rashid = new Employee("Рашид", "Финансовый директор", WorkingDepartments.начальство, Semyon);
            Employee Lucas = new Employee("Лукас", "Начальник бухгалтерии", WorkingDepartments.начальство, Rashid);

            Employee OIlham = new Employee("О Ильхам", "Директор по автоматизации", WorkingDepartments.начальство, Semyon);          
            Employee Orkady = new Employee("Оркадий", "Начальник отдела информационных технологий", WorkingDepartments.начальство, OIlham);
            Employee Volodya = new Employee("Володя", "Зам. начальника отдела информационных технологий", WorkingDepartments.начальство, Orkady);

            Employee Ilshat = new Employee("Ильшат", "Начальник отдела системщиков", WorkingDepartments.начальство, Orkady, Volodya);
            Employee Ivanych = new Employee("Иваныч", "Зам. начальника отдела системщиков", WorkingDepartments.начальство, Ilshat);

            Employee Ilya = new Employee("Илья", "Работник отдела системщиков", WorkingDepartments.системщики, Ivanych);
            Employee Vitya = new Employee("Витя", "Работник отдела системщиков", WorkingDepartments.системщики, Ivanych);
            Employee Zhenya = new Employee("Женя", "Работник отдела системщиков", WorkingDepartments.системщики, Ivanych);

            Employee Sergey = new Employee("Сергей", "Начальник отдела разработчиков",  WorkingDepartments.начальство, Orkady, Volodya);        
            Employee Laysan = new Employee("Ляйсан", "Зам. начальника отдела разработчиков", WorkingDepartments.начальство, Sergey);

            Employee Marat = new Employee("Марат", "Работник отдела разработчиков", WorkingDepartments.разработчики, Laysan);
            Employee Dina = new Employee("Дина", "Работник отдела разработчиков", WorkingDepartments.разработчики, Laysan);
            Employee Ildar = new Employee("Ильдар", "Работник отдела разработчиков", WorkingDepartments.разработчики, Laysan);
            Employee Anton = new Employee("Антон", "Работник отдела разработчиков", WorkingDepartments.разработчики, Laysan);
            #endregion

            #region Задания для работников
            Task task1 = new Task("Расчитать прибыль компании", WorkingDepartments.начальство);
            Task task2 = new Task("Разработать приложение", WorkingDepartments.разработчики);
            Task task3 = new Task("Настроить работу корпоративной сети", WorkingDepartments.системщики);
            Task task4 = new Task("Провести собрание с сотрудниками", WorkingDepartments.начальство);
            #endregion

            Ilya.AssignmentOfTask(task3, Ivanych);
            Vitya.AssignmentOfTask(task3, Lucas);
            Zhenya.AssignmentOfTask(task1, Ivanych);

            Marat.AssignmentOfTask(task2, Laysan);
            Dina.AssignmentOfTask(task3, Laysan);
            Ildar.AssignmentOfTask(task2, Sergey);
            Anton.AssignmentOfTask(task4, Marat);

            Sergey.AssignmentOfTask(task4, Orkady);
            Sergey.AssignmentOfTask(task4, Volodya);
        }
    }
}
