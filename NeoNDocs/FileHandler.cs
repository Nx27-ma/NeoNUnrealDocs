using NeoNDocs.Pages;

namespace NeoNDocs;

public class FileHandler
{
  public string RootDir = "empty";

  public void Init()
  {
    RootDir = AppDomain.CurrentDomain.BaseDirectory;
  }
}
