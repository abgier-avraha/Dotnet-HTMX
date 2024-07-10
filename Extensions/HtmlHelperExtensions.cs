using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Server.Extensions
{
  public static class ICompositeViewEngineExtensions
  {
    public static bool PartialExists(this ICompositeViewEngine viewEngine, string partialViewName)
    {
      var viewEngineResult = viewEngine.GetView(null, partialViewName, false);
      return viewEngineResult.Success;
    }
  }
}
