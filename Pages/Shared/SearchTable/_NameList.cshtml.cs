using Server.Extensions;

namespace Server.Pages.Shared.SearchTable
{
  public class NameListModel : PartialModel
  {
    public override string Path => "~/Pages/Shared/SearchTable/_NameList.cshtml";
    public string Id { get; set; } = "";
    public IEnumerable<string> Names { get; set; } = [];
  }
}