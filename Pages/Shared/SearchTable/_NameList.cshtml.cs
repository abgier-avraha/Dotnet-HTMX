using Server.Extensions;

namespace Server.Pages.Shared.SearchTable
{
  public class NameListModel : PartialModel
  {
    public static string Path => "~/Pages/Shared/SearchTable/_NameList.cshtml";
    public string Id { get; set; } = "";
    public IEnumerable<string> Names { get; set; } = [];

    public Task LoadAsync(string query)
    {
      var names = TestAccounts.Select(t => $"{t.FirstName} {t.LastName}");
      if (!string.IsNullOrEmpty(query))
      {
        names = names
          .Where(n => n.ToLower().Contains(query.ToLower()));
      }

      Names = names.Take(5);
      return Task.CompletedTask;
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