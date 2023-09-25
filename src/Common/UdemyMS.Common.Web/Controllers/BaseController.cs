﻿using Microsoft.AspNetCore.Mvc;
using UdemyMS.Common.Core.Utilities.Results;

namespace UdemyMS.Common.Web.Controllers;
public class BaseController : ControllerBase
{
    public IActionResult GetResult(Result result) => new ObjectResult(result);
    public IActionResult GetResult<T>(Result<T> result) => new ObjectResult(result) { StatusCode = result.StatusCode };
}
