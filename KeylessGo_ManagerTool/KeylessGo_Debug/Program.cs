using libKeylessGo;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace KeylessGo_Debug
{
  class Program
  {
    static string TestCSVFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\TestCSVFile.csv");
    static string TestJSONFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\TestJSONFile.json");

    static void Main(string[] args)
    {
      // CSV Processor Test
      CSVProcessor csvProcessor = new CSVProcessor(TestCSVFilePath);
      List<List<string>> stringTable = csvProcessor.GetStringTable();
      List<Credential> credentials = csvProcessor.ParseCredentialsFromFile(CSVProcessor.CSVFileFormat.KeePass, stringTable).ToList();

      // JSON Processor Test
      JSONProcessor jsonProcessor = new JSONProcessor(TestJSONFilePath);
      List<Credential> credentials1 = jsonProcessor.ParseCredentialsFromFile().ToList();
    }
  }
}
