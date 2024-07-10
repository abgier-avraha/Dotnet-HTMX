using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Server.Extensions
{
  public interface PartialModel
  {
    public static abstract string Path { get; }
  }

  public static class PartialModelExtensions
  {
    public static PartialViewResult Render<T>(this T model, PageModel page) where T : PartialModel
    {
      return page.Partial((string)model.GetType().GetProperty(nameof(PartialModel.Path))!.GetValue(null)!, model);
    }

    public async static Task<IHtmlContent> RenderAsync<T>(this T model, IHtmlHelper htmlHelper) where T : PartialModel
    {
      return await htmlHelper.PartialAsync((string)model.GetType().GetProperty(nameof(PartialModel.Path))!.GetValue(null)!, model);
    }
  }
}
