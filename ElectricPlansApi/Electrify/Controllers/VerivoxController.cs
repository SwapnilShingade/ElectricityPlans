using BusinessLayer.Interface;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace Electrify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerivoxController : ControllerBase
    {
        #region Private Members

        private readonly IPlanComparison _planComparison;
        private readonly ILogger<VerivoxController> _logger;
        private readonly IConfiguration _config;
        private string loggingMessage = "Method Name: {0}. Response Message: {1}.";

        #endregion
        public VerivoxController(IPlanComparison planComparison, ILogger<VerivoxController> logger, IConfiguration config)
        {
            _planComparison = planComparison;
            _logger = logger;
            _config = config;
        }

        #region GET

        [HttpGet("Products/")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<Products> Products()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var response = _planComparison.GetProducts();
            if (response == null)
            {
                _logger.LogInformation(string.Format(loggingMessage, methodName, "Null response received from GetProducts Method."));
                return BadRequest("No Products Found!!");
            }
            _logger.LogInformation(string.Format(loggingMessage, methodName, "Response Sent Successfully!!"));
            return Ok(response);
        }

        [HttpGet("Products/Compare")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<Products> ProductCompare([FromQuery] QueryParameters queryParam)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (queryParam.Usage <= 0)
            {
                ModelState.AddModelError(nameof(QueryParameters.Usage), "Usage must be greater than 0 kWH");
                return BadRequest(ModelState);
            }

            // configurable value for Flat Rate Consumption Value
            int flatConsumption = _config.GetValue<int>("FlatRateConsumptionValue");
            var response = _planComparison.CompareTariff(queryParam.Usage, flatConsumption);

            if (response == null)
            {
                _logger.LogInformation(string.Format(loggingMessage, methodName, "Null response received from CompareTariff Method."));
                return BadRequest("No Products Found!!");
            }
            _logger.LogInformation(string.Format(loggingMessage, methodName, "Response Sent Successfully from method"));
            return Ok(response);
        }
        #endregion
    }
}
