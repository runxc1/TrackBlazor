using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackBlazor.Framework
{
    public static class JsInterop
    {
        public static ValueTask<string> noSleepSetup(IJSRuntime jsRuntime)
          => jsRuntime.InvokeAsync<string>("noSleepSetup");

        public static ValueTask<string> DisableNoSleep(IJSRuntime jsRuntime)
        => jsRuntime.InvokeAsync<string>("noSleepDisable");
    }
}
