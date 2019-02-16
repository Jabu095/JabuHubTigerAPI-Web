using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Api.Controllers.API.V1
{
    [Route("api/v1/[controller]/[action]")]
    public abstract class V1Controller : BaseController
    {
    }
}
