using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace libKeylessGo
{
  public class CSVProcessor
  {
    public enum CSVFileFormat { KeePass, Dashlane };

    private List<string> FileContent;

    /// <summary>
    /// Constructor of CSVProcessor. Checks if file exists and reads content.
    /// </summary>
    /// <param name="filePath">File Path</param>
    public CSVProcessor(string filePath)
    {
      if(!File.Exists(filePath))
      {
        throw new FileNotFoundException("CSV File '{0}' does not exist!", filePath);
      }

      List<string> fileContent = new List<string>();

      using (StreamReader streamReader = new StreamReader(filePath))
      {
        while (!streamReader.EndOfStream)
        {
          fileContent.Add(streamReader.ReadLine());
        }
      }

      FileContent = fileContent;
    }

    /// <summary>
    /// Parses Credentials from a file into a usable data structure
    /// </summary>
    /// <param name="fileFormat">Format of CSV-File</param>
    /// <param name="stringTable">String table</param>
    /// <returns>A list of parsed Credentials</returns>
    public IEnumerable<Credential> ParseCredentialsFromFile(CSVFileFormat fileFormat, List<List<string>> stringTable)
    {
      List<Credential> credentials = new List<Credential>();

      for (int index = 1; index < stringTable.Count; index++)
      {
        Dictionary<Credential.UserDataType, string> dictionary = 
          new Dictionary<Credential.UserDataType, string>();

        foreach(string dataType in stringTable[0])
        {
          int column = stringTable[0].IndexOf(dataType);
          KeyValuePair<Credential.UserDataType, string>? keyValuePair = 
            ParseUserDataType(fileFormat, dataType, stringTable[index][column]);

          if(keyValuePair != null)
          {
            dictionary.Add(keyValuePair.GetValueOrDefault().Key, keyValuePair.GetValueOrDefault().Value);
          }
        }

        if(dictionary.Count != 0)
        {
          credentials.Add(new Credential(dictionary));
        }
      }

      return credentials;
    }

    /// <summary>
    /// Parses a UserDataType and data into a KeyValuePair
    /// </summary>
    /// <param name="fileFormat">File Format</param>
    /// <param name="userDataType">UserDataType like LoginName or Password</param>
    /// <param name="data">Value</param>
    /// <returns>Null if information could not be parsed. Else a valid KeyValuePair</returns>
    public KeyValuePair<Credential.UserDataType, string>? ParseUserDataType(
      CSVFileFormat fileFormat, 
      string userDataType, 
      string data)
    {
      Credential.UserDataType? dataType = null;

      if(fileFormat == CSVFileFormat.KeePass)
      {
        switch(userDataType)
        {
          case "Account":
            dataType = Credential.UserDataType.Title;
            break;
          case "Login Name":
            dataType = Credential.UserDataType.Login;
            break;
          case "Password":
            dataType = Credential.UserDataType.Password;
            break;
          case "Web Site":
            dataType = Credential.UserDataType.Website;
            break;
          case "Comments":
            dataType = null;
            break;
          default:
            throw new ArgumentException(
              "This UserDataType is invalid in a '{0}' file!", 
              fileFormat.ToString());
        }
      }
      else if(fileFormat == CSVFileFormat.Dashlane)
      {
        throw new NotSupportedException("Dashlane is not supported yet!");
      }

      if(dataType == null)
      {
        return null;
      }

      return new KeyValuePair<Credential.UserDataType, string>(dataType.GetValueOrDefault(), data);
    }

    /// <summary>
    /// Parses lines of CSV-File into a string table.
    /// </summary>
    /// <param name="fileContent">File lines</param>
    /// <returns>String table</returns>
    public List<List<string>> GetStringTable()
    {
      List<List<string>> stringTable = new List<List<string>>();
      Regex regex = new Regex("(?<=^|,)(\"([^\"]*)\"|([^,]*))(?=$|,)", RegexOptions.Compiled);

      foreach(string line in FileContent)
      {
        MatchCollection matches = regex.Matches(line);
        stringTable.Add(matches.Cast<Match>().Select(x => x.Groups[2].Value).ToList());
      }

      return stringTable;
    }
  }
}
