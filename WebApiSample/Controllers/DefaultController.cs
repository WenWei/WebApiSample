using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiSample.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
		private readonly ILogger<DefaultController> logger;

		public DefaultController(ILogger<DefaultController> logger)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		public object Get()
		{
			var responseObject = new
			{
				Status = "Up"
			};
			logger.LogInformation($"Status pinged: {responseObject.Status}");
			return responseObject;
		}
	}
}
