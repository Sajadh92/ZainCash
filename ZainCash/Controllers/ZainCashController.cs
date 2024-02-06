using Infrastructure.EPay;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ZainCashController : Controller
{
    [HttpPost]
    public async Task<IActionResult> Init(ZainCashInitModel model)
    {
        return Ok(await ZainCash.Init(model));
    }

    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        return Ok(await ZainCash.Get(id));
    }

    [HttpPost]
    public IActionResult Verify(string token)
    {
        return Ok(ZainCash.Verify(token));
    }
}
