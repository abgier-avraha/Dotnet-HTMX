using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Pages.Shared;

namespace Server.Pages
{
  public class IndexModel : PageModel
  {
    public string? Target { get; private set; } = null;
    public SearchTableModel SearchTableModel { get; private set; } = new();

    // TODO: example of passing request validation data into response
    // Can we leverage annotation based model validation?

    public ActionResult OnGet(string query)
    {
      var names = TestAccounts.Select(t => $"{t.FirstName} {t.LastName}");
      if (!string.IsNullOrEmpty(query))
      {
        names = names
          .Where(n => n.ToLower().Contains(query.ToLower()))
          .ToList();
      }
      names = names.Take(5);

      Target = Request.Headers["Hx-Target"];
      SearchTableModel = new SearchTableModel()
      {
        Names = names,
        DefaultQuery = query
      };

      switch (Target)
      {
        case "search-template-root":
          return SearchTableModel.Render(this);
        default:
          return Page();
      }
    }

    // TODO: move to a service DI class
    class Account
    {
      public string FirstName { get; set; } = "";
      public string LastName { get; set; } = "";
    }

    private static List<Account> TestAccounts = new List<Account>()
    {
      new()
      {
        FirstName = "Johnny",
        LastName =  "Appleseed",
      },
      new(){
        FirstName ="Martha",
        LastName = "Washington",
      },
      new(){
        FirstName ="Marcellus", LastName ="Nolan"},
      new(){
        FirstName ="Coleen", LastName ="James"},
      new(){
        FirstName ="Zachary", LastName ="Gillespie"},
      new(){
        FirstName ="Saundra", LastName ="Joseph"},
      new(){
        FirstName ="Amalia", LastName ="Marsh"},
      new(){
        FirstName ="Wes", LastName ="Dougherty"},
      new(){
        FirstName ="Sallie", LastName ="Blackburn"},
      new(){
        FirstName ="Abram", LastName ="Rangel"},
      new(){
        FirstName ="Rhonda", LastName ="Zhang"},
      new(){
        FirstName ="Rosario", LastName ="Willis"},
      new(){
        FirstName ="Melody", LastName ="Cross"},
      new(){
        FirstName ="Clint", LastName ="Love"},
      new(){
        FirstName ="Bonnie", LastName ="Palmer"},
      new(){
        FirstName ="Dwain", LastName ="Bullock"},
      new(){
        FirstName ="Dusty", LastName ="Flowers"},
      new(){
        FirstName ="Porter", LastName ="Brady"},
      new(){
        FirstName ="Lloyd", LastName ="Bowen"},
      new(){
        FirstName ="Sharlene", LastName ="Mccann"},
      new(){
        FirstName ="Tanya", LastName ="Casey"},
      new(){
        FirstName ="Bernadine", LastName ="Watkins"},
    };

  }
}