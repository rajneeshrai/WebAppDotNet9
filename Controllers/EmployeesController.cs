namespace WebAppDotnet9;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(ILogger<EmployeesController> logger, IEmployeeRepository employeeRepository)
    {
        this._logger = logger;
        this._employeeRepository = employeeRepository;
    }

    [HttpGet("/GetEmployees")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetEmployees()
    {
        var employees = _employeeRepository.GetEmployees();
        return await Task.Run(() => Ok(employees));
    }

    [HttpGet("/GetEmployeeById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<Employee?> GetEmployeeById(int id)
    {
        var employee = _employeeRepository.GetEmployee(id);
        return await Task.Run(() => employee);
    }
}