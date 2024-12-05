
namespace WebAppDotnet9;
public class EmployeeRepository : IEmployeeRepository
{
    private static List<Employee> _employees = [
            new Employee(1,"Rajneesh", "Tech Lead",1000),
            new Employee(2,"Rajat", "Manager",1500),
            new Employee(3,"Rajneesh", "Tech Lead",1000),
        ];
    // public static List<Employee> GetEmployees => _employees;

    // public static void AddEmployee(Employee? employee)
    // {
    //     if (employee is not null)
    //         _employees.Add(employee);
    // }

    public void DeleteEmployee(Employee employee)
    {
        var emp = _employees.FirstOrDefault(employee);
        if(emp is not null){
            _employees.Remove(emp);
        }
    }

    public Employee? GetEmployee(int employeeId)
    {
        return _employees.FirstOrDefault(x=> x.Id == employeeId);
    }

    public void UpdateEmployee(Employee employee)
    {
        var emp = _employees.FirstOrDefault(x=> x.Id == employee.Id);
        if(emp is not null){
            emp.Name = employee.Name;
            emp.Position = employee.Position;
            emp.Salary = employee.Salary;
        }
    }

    public int AddEmployee(Employee employee)
    {
        int generatedId = _employees.Count + 1;
        if (employee is not null)
        {
            employee.Id = generatedId;
            _employees.Add(employee);
        }
        return generatedId;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _employees;
    }
}