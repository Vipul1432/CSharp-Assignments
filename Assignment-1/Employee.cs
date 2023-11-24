namespace Assignment_1
{
    public class Employee
    {
        private int Id;
        private string Name;
        private string DepartmentName;

        // Event declaration
        public event EventHandler MethodCalled;

        /// <summary>
        /// Initializes a new instance of the Employee class with specified values.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="departmentName">The department name of the employee.</param>
        public Employee(int id, string name, string departmentName)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;
        }

        /// <summary>
        /// Retrieves the ID of the employee.
        /// </summary>
        /// <returns>The ID of the employee.</returns>
        public int GetId()
        {
            OnMethodCalled("GetId() method called");
            return Id;
        }

        /// <summary>
        /// Retrieves the name of the employee.
        /// </summary>
        /// <returns>The name of the employee.</returns>
        public string GetName()
        {
            OnMethodCalled("GetName() method called");
            return Name;
        }

        /// <summary>
        /// Retrieves the department name of the employee.
        /// </summary>
        /// <returns>The department name of the employee.</returns>
        public string GetDepartmentName()
        {
            OnMethodCalled("GetDepartmentName() method called");
            return DepartmentName;
        }

        /// <summary>
        /// Updates the ID of the employee with the specified value.
        /// </summary>
        /// <param name="newId">The new ID to set for the employee.</param>
        public void UpdateId(int newId)
        {
            Id = newId;
            OnMethodCalled("UpdateId() method called");
        }

        /// <summary>
        /// Updates the name of the employee with the specified value.
        /// </summary>
        /// <param name="newName">The new name to set for the employee.</param>
        public void UpdateName(string newName)
        {
            Name = newName;
            OnMethodCalled("UpdateName() method called");
        }

        /// <summary>
        /// Updates the department name of the employee with the specified value.
        /// </summary>
        /// <param name="newDepartmentName">The new department name to set for the employee.</param>
        public void UpdateDepartmentName(string newDepartmentName)
        {
            DepartmentName = newDepartmentName;
            OnMethodCalled("UpdateDepartmentName() method called");
        }

        /// <summary>
        /// Invokes the MethodCalled event and prints a message indicating the method called.
        /// </summary>
        /// <param name="message">The message to print indicating the method called.</param>
        protected virtual void OnMethodCalled(string message)
        {
            MethodCalled?.Invoke(this, new EventArgs());
            Console.WriteLine(message);
        }
    }
}
