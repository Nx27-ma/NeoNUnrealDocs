using System.Diagnostics;
using System.Text.Json;

namespace NeoNDocs.Json;

public class SGSection
{
  public string? ID { get; set; }
  public List<string>? HTMLContent { get; set; }
}



public class LoadRequestedJson
{
  private readonly HttpClient _httpClient;

  public LoadRequestedJson(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<List<string>> LoadSectionsAsync(string jsonPath, string ID)
  {
    var json = await _httpClient.GetStringAsync(jsonPath);
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var allSections = JsonSerializer.Deserialize<List<SGSection>>(json, options);
    Debug.WriteLine("hhh");
    Debug.WriteLine(allSections == null);

    var selection = allSections?.Find(s => s.ID == ID);
    Console.WriteLine("Selection should not be null");

    return selection?.HTMLContent ?? new List<string> {"Nothing at this subpage" };
  }
}
