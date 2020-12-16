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
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void bttnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
