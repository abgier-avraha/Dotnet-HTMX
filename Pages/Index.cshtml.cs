using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Extensions;
using Server.Pages.Shared.SearchTable;

namespace Server.Pages
{
  public class IndexModel : PageModel
  {
    public SearchTableModel SearchTable = new SearchTableModel();

    public async Task<ActionResult> OnGet(string query)
    {
      SearchTable = new SearchTableModel()
      {
        Query = query,
        NamesList = new NameListModel()
        {
          Id = "name-list-root",
        }
      };
      await SearchTable.LoadAsync();

      var target = Request.Headers["Hx-Target"];
      switch (target)
      {
        case "name-list-root":
          return SearchTable.NamesList.Render(this);
        default:
          return Page();
      }
    }
  }
}