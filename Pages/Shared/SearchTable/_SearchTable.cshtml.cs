using Server.Extensions;

namespace Server.Pages.Shared.SearchTable
{
  public class SearchTableModel : PartialModel
  {
    public static string Path => "~/Pages/Shared/SearchTable/_SearchTable.cshtml";
    public string Query { get; set; } = "";
    public NameListModel NamesList { get; set; } = new NameListModel();

    public async Task LoadAsync()
    {
      await NamesList.LoadAsync(Query);
    }
  }
}