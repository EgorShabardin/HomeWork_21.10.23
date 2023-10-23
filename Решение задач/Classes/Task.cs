namespace Решение_задач
{
    /// <summary>
    /// Класс, описывающий задачу для работников компании.
    /// </summary>
    class Task
    {
        #region Поля
        private string taskContent;
        private WorkingDepartments taskAddress;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле taskContent.
        /// </summary>
        public string TaskContent
        {
            get
            {
                return taskContent;
            }
        }
        /// <summary>
        /// Свойство, позволяющее читать поле taskAddress.
        /// </summary>
        public WorkingDepartments TaskAddress
        {
            get
            {
                return taskAddress;
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, создающий экземпляр класса Task.
        /// </summary>
        /// <param name="taskContent"> Содержание задачи. </param>
        /// <param name="taskAddress"> Место, куда направлена эта задача. </param>
        public Task(string taskContent, WorkingDepartments taskAddress)
        {
            this.taskContent = taskContent;
            this.taskAddress = taskAddress;
        }
        #endregion
    }
}
