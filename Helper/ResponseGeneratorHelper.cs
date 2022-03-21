using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Enum;

namespace Minder.Helper
{
    public class ResponseGeneratorHelper : ControllerBase
    {
        public ActionResult ResponseGenerator<T>(BaseResponse<T> incomingResponse)
        {
            switch (incomingResponse.ResponseStatusCodes)
            {
                case ResponseStatusCodes.Success:
                    return Ok(incomingResponse);
                case ResponseStatusCodes.AccountNotFound:
                case ResponseStatusCodes.DataNotFound:
                    return NotFound(incomingResponse);
                default:
                    return BadRequest(incomingResponse);
            }
        }
    }
}