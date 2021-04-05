using System;
using System.Collections.Generic;
using System.Linq;

namespace libKeylessGo
{
  public class Credential
  {
    public enum UserDataType { Id, Title, Email, Username, Password, Website };

    private Dictionary<UserDataType, string> CredentialDataDictionary;

    /// <summary>
    /// Constructor of Credentials. Checks if everything that is needed is existing.
    /// </summary>
    /// <param name="credentialDataDictionary">Dictionary with data for Credential</param>
    public Credential(Dictionary<UserDataType, string> credentialDataDictionary)
    {
      if(credentialDataDictionary == null)
      {
        throw new ArgumentNullException("CredentalDataDictionary can not be NULL!");
      }

      if(!CheckNeededData(credentialDataDictionary.Keys))
      {
        throw new ArgumentException("Not enough UserDataTypes given!");
      }

      CredentialDataDictionary = credentialDataDictionary;
    }

    /// <summary>
    /// Constructor for Credentials
    /// </summary>
    /// <param name="credential">Credential data</param>
    public Credential(Credential credential)
    {
      CredentialDataDictionary = new Dictionary<UserDataType, string>(credential.CredentialDataDictionary);
    }

    /// <summary>
    /// Edits data of Credential
    /// </summary>
    /// <param name="dataType">DataType to be edited</param>
    /// <param name="data">Data to be edited</param>
    public void EditCredential(UserDataType dataType, string data)
    {
      if(string.IsNullOrEmpty(data))
      {
        throw new ArgumentException("Data can not be NULL!");
      }

      if(!CredentialDataDictionary.ContainsKey(dataType))
      {
        CredentialDataDictionary.Add(dataType, data);
        return;
      }

      CredentialDataDictionary[dataType] = data;
    }

    /// <summary>
    /// Functions is checking if needed UserDataTypes are existing.
    /// </summary>
    /// <param name="dataTypes">Existing UserDataTypes</param>
    /// <returns>True if everything that is needed is existing. False if not.</returns>
    private bool CheckNeededData(IEnumerable<UserDataType> dataTypes)
    {
      if(dataTypes.Contains(UserDataType.Email) && 
        dataTypes.Contains(UserDataType.Password) && 
        dataTypes.Contains(UserDataType.Title))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Get Data from UserDataType
    /// </summary>
    /// <param name="userDataType">User Data Type</param>
    /// <returns>returns data in form of a string</returns>
    public string GetData(UserDataType userDataType)
    {
      if(!CredentialDataDictionary.ContainsKey(userDataType))
      {
        return string.Empty;
      }

      return CredentialDataDictionary[userDataType];
    }

    /// <summary>
    /// Get all UserDataType keys
    /// </summary>
    /// <returns>List of UserDataTypes</returns>
    public IEnumerable<UserDataType> GetKeys()
    {
      return CredentialDataDictionary.Keys;
    }
  }
}
