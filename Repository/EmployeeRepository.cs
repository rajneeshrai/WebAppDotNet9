namespace WebAppDotnet9;
static class EmployeeRepository
{
    private static List<Employee> _employees = [
            new Employee(1,"Rajneesh", "Tech Lead",1000),
            new Employee(2,"Rajat", "Manager",1500),
            new Employee(3,"Rajneesh", "Tech Lead",1000),
        ];
    public static List<Employee> GetEmployees => _employees;

    public static void AddEmployee(Employee? employee)
    {
        if (employee is not null)
            _employees.Add(employee);
    }
}