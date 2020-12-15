using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace libKeylessGo
{
  public class JSONProcessor
  {
    /// <summary>
    /// Class for JSON Deserialization
    /// </summary>
    private class Authentifiant
    {
      public string Domain { get; set; }
      public string Email { get; set; }
      public string Login { get; set; }
      public string Note { get; set; }
      public string Password { get; set; }
      public string SecondaryLogin { get; set; }
      public string Title { get; set; }
    }

    /// <summary>
    /// Class for JSON Deserialization
    /// </summary>
    private class Root
    {
      public IList<Authentifiant> Authentifiant { get; set; }
    }

    private string FileContent;

    /// <summary>
    /// Constructor for JSONProcessor. Checks if input file does exist.
    /// </summary>
    /// <param name="filePath">File Path</param>
    public JSONProcessor(string filePath)
    {
      if (!File.Exists(filePath))
      {
        throw new FileNotFoundException("JSON File '{0}' does not exist!", filePath);
      }

      using (StreamReader streamReader = new StreamReader(filePath))
      {
        FileContent = streamReader.ReadToEnd();
      }

      if (!FileContent.Contains("AUTHENTIFIANT"))
      {
        throw new InvalidDataException("File '{0}' does not contain valid password info!");
      }
    }

    /// <summary>
    /// Parses Credentials from JSON File Content. Uses Newtonsofts JSON Library.
    /// </summary>
    /// <returns>List of parsed credentials</returns>
    public IEnumerable<Credential> ParseCredentialsFromFile()
    {
      Regex regex = new Regex("(?=\"AUTHENTIFIANT\")((.|\n)*?)(?<=])", RegexOptions.Compiled);
      Match match = regex.Match(FileContent);
      string parsedJSONPart = "{" + match.Groups[0].Value + "}";

      Root root = JsonConvert.DeserializeObject<Root>(parsedJSONPart);
      List<Credential> credentials = new List<Credential>();

      foreach(Authentifiant data in root.Authentifiant)
      {
        Dictionary<Credential.UserDataType, string> dictionary =
          new Dictionary<Credential.UserDataType, string>();

        dictionary.Add(Credential.UserDataType.Login, data.Login);
        
        if(!string.IsNullOrEmpty(data.SecondaryLogin))
        {
          dictionary.Add(Credential.UserDataType.SecondaryLogin, data.Email);
        }

        dictionary.Add(Credential.UserDataType.Title, data.Title);
        dictionary.Add(Credential.UserDataType.Password, data.Password);
        dictionary.Add(Credential.UserDataType.Website, data.Domain);

        credentials.Add(new Credential(dictionary));
      }

      return credentials;
    }
  }
}
