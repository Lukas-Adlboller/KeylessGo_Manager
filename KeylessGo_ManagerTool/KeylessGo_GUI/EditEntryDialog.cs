using System;
using System.Collections.Generic;
using System.Windows.Forms;
using libKeylessGo;

namespace KeylessGo_GUI
{
  public partial class EditEntryDialog : Form
  {
    private Credential userCredential;

    public Credential UserCredential 
    { 
      get 
      { 
        return userCredential; 
      }
      set
      {
        userCredential = value;
      }
    }

    public EditEntryDialog()
    {
      InitializeComponent();
    }

    private void bttnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void bttnMinimize_Click(object sender, EventArgs e)
    {
      WindowState = FormWindowState.Minimized;
    }

    private void bttnOk_Click(object sender, EventArgs e)
    {
      Dictionary<Credential.UserDataType, string> userDataDictionary = new Dictionary<Credential.UserDataType, string>();

      if(string.IsNullOrEmpty(txtBoxTitle.Text))
      {
        MessageBox.Show("Title has to be set!", "Edit Entry Error", MessageBoxButtons.OK);
        return;
      }

      if(string.IsNullOrEmpty(txtBoxPrimary.Text))
      {
        MessageBox.Show("Primary Login has to be set!", "Edit Entry Error", MessageBoxButtons.OK);
        return;
      }

      if (string.IsNullOrEmpty(txtBoxWebsite.Text))
      {
        MessageBox.Show("Website has to be set!", "Edit Entry Error", MessageBoxButtons.OK);
        return;
      }

      if (string.IsNullOrEmpty(txtBoxPassword.Text))
      {
        MessageBox.Show("Password has to be set!", "Edit Entry Error", MessageBoxButtons.OK);
        return;
      }

      if (string.IsNullOrEmpty(txtBoxRepeat.Text))
      {
        MessageBox.Show("Please repeat your Password!", "Edit Entry Error", MessageBoxButtons.OK);
        return;
      }

      if(!string.Equals(txtBoxPassword.Text, txtBoxRepeat.Text))
      {
        MessageBox.Show("Repeated Password is not equal entered Password!", "Edit Entry Error", MessageBoxButtons.OK);
        return;
      }

      if(userCredential != null)
      {
        userDataDictionary.Add(Credential.UserDataType.Id, userCredential.GetData(Credential.UserDataType.Id));
      }
      
      userDataDictionary.Add(Credential.UserDataType.Title, txtBoxTitle.Text);
      userDataDictionary.Add(Credential.UserDataType.Email, txtBoxPrimary.Text);
      userDataDictionary.Add(Credential.UserDataType.Website, txtBoxWebsite.Text);
      userDataDictionary.Add(Credential.UserDataType.Password, txtBoxPassword.Text);

      if(!string.IsNullOrEmpty(txtBoxSecondary.Text))
      {
        
        userDataDictionary.Add(Credential.UserDataType.Username, txtBoxSecondary.Text);
      }

      userCredential = new Credential(userDataDictionary);

      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void bttnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void bttnShowHidePwd_Click(object sender, EventArgs e)
    {
      txtBoxPassword.UseSystemPasswordChar = !txtBoxPassword.UseSystemPasswordChar;
      txtBoxRepeat.UseSystemPasswordChar = !txtBoxRepeat.UseSystemPasswordChar;
    }

    private void EditEntryDialog_Load(object sender, EventArgs e)
    {
      if (userCredential != null)
      {
        foreach (Credential.UserDataType dataType in userCredential.GetKeys())
        {
          switch (dataType)
          {
            case Credential.UserDataType.Title:
              txtBoxTitle.Text = userCredential.GetData(dataType);
              break;
            case Credential.UserDataType.Email:
              txtBoxPrimary.Text = userCredential.GetData(dataType);
              break;
            case Credential.UserDataType.Username:
              txtBoxSecondary.Text = userCredential.GetData(dataType);
              break;
            case Credential.UserDataType.Website:
              txtBoxWebsite.Text = userCredential.GetData(dataType);
              break;
            //case Credential.UserDataType.Password:
            //  txtBoxPassword.Text = userCredential.GetData(dataType);
            //  break;
          }
        }
      }
    }
  }
}
