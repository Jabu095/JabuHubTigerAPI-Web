﻿using JabulaniHubTiger.Helper;
using JabulaniHubTiger.Helper.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Api.Controllers.API
{
    [Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {

        protected ObjectResult EasyServerError(Exception ex)
        {
            try
            {
                if (ex is HttpException)
                {
                    var _exception = (HttpException)ex;
                    return StatusCode(_exception.StatusCode, new ResponseViewModel<bool> { data = false, message = _exception.Message, statusCode = _exception.StatusCode });
                }
                return StatusCode(500, new ResponseViewModel<bool> { data = false, message = ex.Message, statusCode = 500 });
            }
            catch
            {
                return StatusCode(500, new ResponseViewModel<bool> { data = false, message = ex.Message, statusCode = 500 });
            }
        }
    }
}
