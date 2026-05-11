using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace CampusRunnerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbTestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DbTestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("ping")]
        public IActionResult PingOracle()
        {
            string connStr = _configuration.GetConnectionString("OracleDb");

            using var conn = new OracleConnection(connStr);
            conn.Open();

            using var cmd = conn.CreateCommand();

            // 这里改成你已经创建好的某张表
            cmd.CommandText = "SELECT COUNT(*) FROM users";

            var count = cmd.ExecuteScalar();

            return Ok(new
            {
                message = "Oracle connected successfully",
                count = count
            });
        }
    }
}