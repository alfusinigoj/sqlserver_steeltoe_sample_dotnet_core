using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SqlServer.Steeltoe.Sample.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SqlTestController : ControllerBase
    {
        private readonly IDbConnection dbConnection;
        private readonly ILogger<SqlTestController> logger;

        public SqlTestController(IDbConnection dbConnection, ILogger<SqlTestController> logger)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                using (dbConnection)
                {
                    dbConnection.Open();
                    var command = dbConnection.CreateCommand();
                    command.CommandText = "select 1";
                    command.CommandTimeout = 1;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return $"Exception Occurred, {ex}";
            }

            return "Sql server connection succeeded";
        }
    }
}
