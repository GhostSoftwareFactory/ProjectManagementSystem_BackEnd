using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementAPI.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult CustomResponse(
            object? responseObject,
            bool isSuccess,
            string returnMessage = "")
        {
            if (responseObject is not null)
            {
                if (isSuccess)
                    return Ok(new
                    {
                        success = isSuccess,
                        message = returnMessage,
                        data = responseObject
                    });

                return BadRequest(new
                {
                    success = isSuccess,
                    message = returnMessage,
                    data = responseObject
                });
            }

            return NotFound(new
            {
                success = isSuccess,
                message = returnMessage,
                data = responseObject
            });
        }

        protected IActionResult PostCustomResponse(
            object? responseObject = null,
            bool isSuccess = false,
            string returnMessage = "")
        {
            if (isSuccess && responseObject is null)
                return Created();

            if (isSuccess)
            {
                return Ok(new
                {
                    success = isSuccess,
                    message = returnMessage,
                    data = responseObject
                });
            }

            return BadRequest(new
            {
                success = isSuccess,
                message = returnMessage
            });
        }

        protected IActionResult InternalError(
            object? responseObject = null,
            bool isSuccess = false,
            string returnMessage = "")
        {
            return InternalError(responseObject, isSuccess, returnMessage);
        }
    }
}
