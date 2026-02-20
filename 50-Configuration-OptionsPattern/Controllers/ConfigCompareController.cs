using _50_Configuration_OptionsPattern.Services;
using Microsoft.AspNetCore.Mvc;

namespace _50_Configuration_OptionsPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigCompareController : ControllerBase
    {
        private IConfigCompareService _configCompareService;
        public ConfigCompareController(IConfigCompareService configCompareService)
        {
            _configCompareService = configCompareService;
        }

        [HttpGet("GetConfig")]
        public IActionResult GetConfig()
        {
            return Ok(_configCompareService.GetConfigCompare());
        }
    }
}

/*
https://localhost:7174/api/ConfigCompare/GetConfig

1. istek:
{
    "configuration": {
        "version": "1.0.0-dev",
        "appName": "_50_Configuration_OptionsPattern"
    },
    "options": {
        "version": "1.0.0-dev",
        "appName": "_50_Configuration_OptionsPattern"
    },
    "optionsSnapshot": {
        "version": "1.0.0-dev",
        "appName": "_50_Configuration_OptionsPattern"
    },
    "optionsMonitor": {
        "version": "1.0.0-dev",
        "appName": "_50_Configuration_OptionsPattern"
    }
}

2. istek (appsettings.development.json dosyasında version değeri 1.2.0 olarak değiştirildiğinde):
{
    "configuration": {
        "version": "1.2.0-dev",
        "appName": "_50_Configuration_OptionsPattern"
    },
    "options": {
        "version": "1.0.0-dev",
        "appName": "_50_Configuration_OptionsPattern"
    },
    "optionsSnapshot": {
        "version": "1.2.0-dev",
        "appName": "_50_Configuration_OptionsPattern"
    },
    "optionsMonitor": {
        "version": "1.2.0-dev",
        "appName": "_50_Configuration_OptionsPattern"
    }
}

konsol çıktısı:
_50_Configuration_OptionsPattern
1.0.0-dev
Montor Başlatıldı: 1.0.0-dev
dbug: Microsoft.AspNetCore.Watch.BrowserRefresh.BlazorWasmHotReloadMiddleware[0]
      Middleware loaded
dbug: Microsoft.AspNetCore.Watch.BrowserRefresh.BrowserScriptMiddleware[0]
      Middleware loaded. Script /_framework/aspnetcore-browser-refresh.js (16547 B).
dbug: Microsoft.AspNetCore.Watch.BrowserRefresh.BrowserScriptMiddleware[0]
      Middleware loaded. Script /_framework/blazor-hotreload.js (799 B).
dbug: Microsoft.AspNetCore.Watch.BrowserRefresh.BrowserRefreshMiddleware[0]
      Middleware loaded: DOTNET_MODIFIABLE_ASSEMBLIES=debug, __ASPNETCORE_BROWSER_TOOLS=true
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7174
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5099
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Berkant Karaca\Backend Projeler\C# - OOP\CSharp-.Net\50-Configuration-OptionsPattern
Yeni versiyon algılandı: 1.2.0-dev
Yeni versiyon algılandı: 1.2.0-dev
Yeni versiyon algılandı: 1.2.0-dev

 */
