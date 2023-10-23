using System;
using System.Collections.Generic;

namespace Решение_задач
{
    /// <summary>
    /// Класс работников компании.
    /// </summary>
    class Employee
    {
        #region Поля
        private string employeeName;
        private string jobTitle;
        private WorkingDepartments workDepartment;
        private List<Employee> superiors = new List<Employee>();
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле employeeName.
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле jobTitle.
        /// </summary>
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле workDepartment.
        /// </summary>
        public WorkingDepartments WorkDepartment
        {
            get
            {
                return workDepartment;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле superiors.
        /// </summary>
        public List<Employee> Superiors
        {
            get
            {
                return superiors;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, который проверяет, возьмет ли сотрудник задачу, и выводит соответсвующее сообщение.
        /// </summary>
        /// <param name="task"> Задача. </param>
        /// <param name="employee"> Работник, который выдал задачу. </param>
        public void AssignmentOfTask(Task task, Employee employee)
        {
            Console.WriteLine($"От {employee.EmployeeName} ({employee.JobTitle}) дается задача\n{task.TaskContent} работнику {employeeName} ({jobTitle})");

            if (superiors.Contains(employee) && (workDepartment == task.TaskAddress))
            {
                Console.WriteLine($"{employeeName} ({jobTitle}) берет задачу\n");
            }
            else
            {
                Console.WriteLine($"{employeeName} ({jobTitle}) не берет задачу\n");
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, создающий экземпляр класса Employee.
        /// </summary>
        /// <param name="employeeName"> Имя работника. </param>
        /// <param name="jobTitle"> Должность работника. </param>
        /// <param name="workDepartment"> Место работы. </param>
        /// <param name="superiors"> Начальство работника. </param>
        public Employee(string employeeName, string jobTitle, WorkingDepartments workDepartment, params Employee[] superiors)
        {
            this.employeeName = employeeName;
            this.jobTitle = jobTitle;
            this.workDepartment = workDepartment;
            this.superiors.AddRange(superiors);
        }
        #endregion
    }
}
