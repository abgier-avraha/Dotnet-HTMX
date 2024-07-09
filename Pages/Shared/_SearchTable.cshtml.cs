namespace Server.Pages.Shared
{
  public class SearchTableModel
  {
    public IEnumerable<string> Names { get; set; } = new List<string>();
    public string DefaultQuery { get; set; } = "";
  }

  public static class SearchTableModelExtensions
  {
    public static PartialViewResult Render(this SearchTableModel model, PageModel page)
    {
      return page.Partial("~/Pages/Shared/_SearchTable.cshtml", model);
    }
  }
}