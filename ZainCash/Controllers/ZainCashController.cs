using Infrastructure.EPay;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]/[action]")]
public class ZainCashController : Controller
{
    [HttpPost]
    public async Task<IActionResult> Init(ZainCashInitModel model)
    {
        return Ok(await ZainCash.Init(model));
    }

    [HttpPost]
    public IActionResult Verify(string token)
    {
        return Ok(ZainCash.Verify(token));
    }

    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        return Ok(await ZainCash.Get(id));
    }

}
