namespace Server.Pages.Shared
{
  public class SearchTableModel
  {
    public IEnumerable<string> Names { get; set; } = new List<string>();
    public string DefaultQuery { get; set; } = "";
  }
}