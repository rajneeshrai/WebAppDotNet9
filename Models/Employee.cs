namespace WebAppDotnet9;
public class Employee
{
    public Employee(int id, string name, string position, decimal salary)
    {
        this.Id = id;
        this.Name = name;
        this.Position = position;
        this.Salary = salary;
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public decimal Salary { get; set; }
}