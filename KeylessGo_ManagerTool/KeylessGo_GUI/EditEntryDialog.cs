using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

      if(string.IsNullOrEmpty(txtBoxUsername.Text))
      {
        MessageBox.Show("Username has to be set!", "Edit Entry Error", MessageBoxButtons.OK);
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

      userDataDictionary.Add(Credential.UserDataType.Title, txtBoxTitle.Text);
      userDataDictionary.Add(Credential.UserDataType.Login, txtBoxUsername.Text);
      userDataDictionary.Add(Credential.UserDataType.Website, txtBoxWebsite.Text);
      userDataDictionary.Add(Credential.UserDataType.Password, txtBoxPassword.Text);

      if(!string.IsNullOrEmpty(txtBoxEmail.Text))
      {
        userDataDictionary.Add(Credential.UserDataType.SecondaryLogin, txtBoxEmail.Text);
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
            case Credential.UserDataType.Login:
              txtBoxUsername.Text = userCredential.GetData(dataType);
              break;
            case Credential.UserDataType.SecondaryLogin:
              txtBoxEmail.Text = userCredential.GetData(dataType);
              break;
            case Credential.UserDataType.Website:
              txtBoxWebsite.Text = userCredential.GetData(dataType);
              break;
            case Credential.UserDataType.Password:
              txtBoxPassword.Text = userCredential.GetData(dataType);
              break;
          }
        }
      }
    }
  }
}
