using Microsoft.AspNetCore.Mvc.ViewEngines;
using Server.Extensions;

public static class WebApplicationExtensions
{
  public static void CheckPartialPaths(this WebApplication app)
  {
    var scope = app.Services.CreateScope();
    var viewEngine = scope.ServiceProvider.GetService<ICompositeViewEngine>()!;

    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => typeof(PartialModel).IsAssignableFrom(p) && typeof(PartialModel) != p);

    foreach (var partialType in types)
    {
      var path = (string)partialType.GetProperty(nameof(PartialModel.Path))!.GetValue(null)!;
      Console.WriteLine($"Checking partial path for \"{partialType.FullName}\"...");

      if (!viewEngine.PartialExists(path))
      {
        throw new Exception($"Partial path \"{path}\" in class \"{partialType.FullName}\" is invalid!");
      }
    }
  }
}