namespace AspNetCoreWebAppTodoList.Model
{
    public class TodoItem
    {
        /// <summary>
        /// Internal id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Title of ToDo-Item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Defines if todo is done or not.
        /// </summary>
        public bool IsComplete { get; set; }
    }
}