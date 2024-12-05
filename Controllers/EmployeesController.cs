namespace WebAppDotnet9;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(ILogger<EmployeesController> logger)
    {
        this._logger = logger;
    }

    [HttpGet("/GetEmployees")]
    public async Task<ActionResult> GetEmployees()
    {

        return await Task.Run(() => Ok());
    }

    [HttpGet("/GetEmployeeById")]
    public async Task<Employee> GetEmployeeById(int id)
    {
        return await Task.Run(() => new Employee(id, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 1000));
    }
}