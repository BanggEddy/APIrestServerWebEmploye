using Microsoft.AspNetCore.Mvc;

namespace TestAppResFull.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeController : ControllerBase
    {

        private readonly ILogger<EmployeController> _logger;

        public EmployeController(ILogger<EmployeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Employe> Get()
        {
            return EmployeDAO.getEmployes();
        }

        [HttpGet("{id}")]
        public Employe GetById(int id)
        {
            return EmployeDAO.trouveEmploye(id);

        }

        [HttpPost]
        public void Post(Employe emp)
        {
            EmployeDAO.insertEmploye(emp);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeDAO.deleteEmploye(id);
        }


    }
}