using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JabulaniHubTiger.Helper;
using JabulaniHubTiger.Helper.Provider;
using JabulaniHubTiger.Web.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace JabulaniHubTiger.Web.Controllers
{
   
    public class BicycleController : BaseController
    {
        private readonly CustomApp Configuration;
        public BicycleController(IOptions<CustomApp> _configuration)
        {
            Configuration = _configuration.Value;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody]BicycleRequestViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await new NetWorkCalls<ResponseViewModel<BicycleResponseViewModel>>().POST(Configuration.BicycleMicroservice.Post, JsonConvert.SerializeObject(viewModel));

                    return Ok(response);

                }
                return BadRequest(new ResponseViewModel<bool> { data = false, message = "all fields are required", statusCode = 400 });
            }
            catch (Exception ex)
            {
                return EasyServerError(ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Put([FromBody]BicycleRequestViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await new NetWorkCalls<ResponseViewModel<BicycleResponseViewModel>>().PUT(Configuration.BicycleMicroservice.Put, JsonConvert.SerializeObject(viewModel));

                    return Ok(response);

                }
                return BadRequest(new ResponseViewModel<bool> { data = false, message = "all fields are required", statusCode = 400 });
            }
            catch (Exception ex)
            {
                return EasyServerError(ex);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await new NetWorkCalls<ResponseViewModel<List<BicycleResponseViewModel>>>().GET(Configuration.BicycleMicroservice.GetAll);

                    return Ok(response);

                }
                return BadRequest(new ResponseViewModel<bool> { data = false, message = "all fields are required", statusCode = 400 });
            }
            catch (Exception ex)
            {
                return EasyServerError(ex);
            }
        }
    }
}