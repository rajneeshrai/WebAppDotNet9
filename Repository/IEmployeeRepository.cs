namespace WebAppDotnet9;
public interface IEmployeeRepository
{
    IEnumerable<Employee> GetEmployees();

    Employee? GetEmployee(int employeeId);

    int AddEmployee(Employee employee);

    void UpdateEmployee(Employee employee);

    void DeleteEmployee(Employee employee);
}