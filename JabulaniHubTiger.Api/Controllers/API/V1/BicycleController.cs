using JabulaniHubTiger.Helper;
using JabulaniHubTiger.Service.Bicycle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Api.Controllers.API.V1
{
    public class BicycleController : V1Controller
    {
        private readonly IBicycleService BicycleService;
        public BicycleController(IBicycleService bicycleService)
        {
            BicycleService = bicycleService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Produces(typeof(ResponseViewModel<BicycleResponseViewModel>))]
        public async Task<IActionResult> Post([FromBody]BicycleRequestViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await BicycleService.InsertAsync(new ORM.Bicycle
                    {
                        BicyleCondition = viewModel.BicyleCondition,
                        CreatedOn = DateTime.Now,
                        Model = viewModel.Model
                    });

                    return StatusCode(201,new ResponseViewModel<BicycleResponseViewModel> { data = MapResponse(response) , message = "Bicycle created", statusCode = 201});

                }
                return BadRequest(new ResponseViewModel<bool> { data = false, message = "all fields are required", statusCode = 400 });
            }catch(Exception ex)
            {
                return EasyServerError(ex);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Produces(typeof(ResponseViewModel<BicycleResponseViewModel>))]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                if(Id == 0)
                    return BadRequest(new ResponseViewModel<bool> { data = false, message = "ID is required", statusCode = 400 });

                var response = await BicycleService.GetByIdAsync(Id);
                if(response != null)
                {
                    return Ok(new ResponseViewModel<BicycleResponseViewModel>
                    {
                        data = MapResponse(response),
                        message = "record found",
                        statusCode = 200
                    });
                }
               
                return NotFound(new ResponseViewModel<bool> { data = false, message = "not found", statusCode = 404 });
            }
            catch (Exception ex)
            {
                return EasyServerError(ex);
            }
        }


        [AllowAnonymous]
        [HttpGet]
        [Produces(typeof(ResponseViewModel<List<BicycleResponseViewModel>>))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                
                var response = await BicycleService.GetAllAsync();
                if (response != null)
                {
                    var _list = new List<BicycleResponseViewModel>();
                    foreach (var item in response)
                    {
                        _list.Add(MapResponse(item));
                    }
                    return Ok(new ResponseViewModel<List<BicycleResponseViewModel>>
                    {
                        data = _list,
                        message = "record found",
                        statusCode = 200
                    });
                }

                return NotFound(new ResponseViewModel<bool> { data = false, message = "not found", statusCode = 404 });
            }
            catch (Exception ex)
            {
                return EasyServerError(ex);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Produces(typeof(ResponseViewModel<BicycleResponseViewModel>))]
        public async Task<IActionResult> Put([FromBody]BicycleRequestViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var bike = await BicycleService.GetByIdAsync(viewModel.Id);
                    var response = await BicycleService.UpdateAsync(new ORM.Bicycle
                    {
                        BicyleCondition = viewModel.BicyleCondition,
                        Model = viewModel.Model,
                        UpdatedOn = DateTime.Now,
                        CreatedOn = viewModel.CreatedOn,
                        Id = viewModel.Id
                    });

                    return Ok(new ResponseViewModel<BicycleResponseViewModel>
                    {
                        data = MapResponse(response),
                        message = "record upadated",
                        statusCode = 200
                    });

                }
                return BadRequest(new ResponseViewModel<bool> { data = false, message = "All feilds are required", statusCode = 400 });
            }
            catch (Exception ex)
            {
                return EasyServerError(ex);
            }
        }

        [AllowAnonymous]
        [HttpDelete]
        [Produces(typeof(ResponseViewModel<bool>))]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0)
                    return BadRequest(new ResponseViewModel<bool> { data = false, message = "ID is required", statusCode = 400 });
                var response = await BicycleService.DeleteAsync(new ORM.Bicycle
                {
                    Id = Id
                });
                if (response > 0)
                    return Ok(new ResponseViewModel<bool> { data = true, message = "Bicycle deleted", statusCode = 200 });

                return BadRequest(new ResponseViewModel<bool> { data = false, message = "All feilds are required", statusCode = 400 });
            }
            catch (Exception ex)
            {
                return EasyServerError(ex);
            }
        }


        private BicycleResponseViewModel MapResponse(ORM.Bicycle bicycle)
        {
            return new BicycleResponseViewModel
            {
                BicyleCondition  = Enum.GetName(typeof(BicyleCondition),bicycle.BicyleCondition),
                CreatedOn = bicycle.CreatedOn,
                Model = bicycle.Model,
                Id = bicycle.Id
            };
        }
    }
}
