using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using libKeylessGo;

namespace KeylessGo_GUI
{
  public partial class MainForm : Form
  {
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn
    (
      int nLeftRect, 
      int nTopRect, 
      int nRightRect,
      int nBottomRect, 
      int nWidthEllipse, 
      int nHeightEllispe
    );

    public Dictionary<GUIEntryCreator, Credential> userPasswordDictionary;

    public MainForm()
    {
      InitializeComponent();
      userPasswordDictionary = new Dictionary<GUIEntryCreator, Credential>();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      // Rounded Corners for Form
      Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

      // Gradient Colors for Side Menue
      sideMenuePanel.ColorTop = Color.FromArgb(111, 134, 214);
      sideMenuePanel.ColorBottom = Color.FromArgb(72, 198, 239);

      // Button Icons
      buttonExitProg.Image = KeylessGo_GUI.Properties.Resources.about_icon;
      buttonAddEntry.Image = KeylessGo_GUI.Properties.Resources.add_entry_icon;
      buttonImportFile.Image = KeylessGo_GUI.Properties.Resources.import_file_icon;
      buttonSyncDevice.Image = KeylessGo_GUI.Properties.Resources.sync_icon;
      buttonSettings.Image = KeylessGo_GUI.Properties.Resources.settings_icon;

      buttonSoftwareInfo.Image = KeylessGo_GUI.Properties.Resources.software_icon;
      buttonDeviceInfo.Image = KeylessGo_GUI.Properties.Resources.device_icon;

      // FlowLayoutPanel
      entryFlowLayoutPanel.HorizontalScroll.Visible = false;
    }

    private void panelInformation_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
      }
    }

    private void bttnExit_Click(object sender, EventArgs e)
    {
      Environment.Exit(0);
    }

    public void DeleteButton_OnMouseClick(object sender, MouseEventArgs e)
    {
      Panel panel = (Panel)((Button)sender).Parent;
      GUIEntryCreator guiEntryCreator = userPasswordDictionary.Keys.First(x => x.entryPanel == panel);
      entryFlowLayoutPanel.Controls.Remove(guiEntryCreator.entryPanel);
      userPasswordDictionary.Remove(guiEntryCreator);
    }

    public void EditButton_OnMouseClick(object sender, MouseEventArgs e)
    {
      Panel panel = (Panel)((Button)sender).Parent;
      GUIEntryCreator guiEntryCreator = userPasswordDictionary.Keys.First(x => x.entryPanel == panel);

      EditEntryDialog editEntryDialog = new EditEntryDialog();
      editEntryDialog.UserCredential = userPasswordDictionary[guiEntryCreator];

      if (editEntryDialog.ShowDialog() == DialogResult.OK)
      {
        Credential credential = new Credential(editEntryDialog.UserCredential);
        userPasswordDictionary.Remove(guiEntryCreator);

        entryFlowLayoutPanel.Controls.Remove(guiEntryCreator.entryPanel);

        userPasswordDictionary.Add(new GUIEntryCreator(
          entryFlowLayoutPanel,
          credential,
          new MouseEventHandler(DeleteButton_OnMouseClick),
          new MouseEventHandler(EditButton_OnMouseClick)), credential);
      }
    }

    private void buttonImportFile_Click(object sender, EventArgs e)
    {
      using(OpenFileDialog openFileDialog = new OpenFileDialog())
      {

        openFileDialog.InitialDirectory = "C:\\";
        openFileDialog.Filter = "Dashlane-Files (*.json)|*.json|KeePass-Files (*.csv)|*.csv";
        openFileDialog.FilterIndex = 1;
        
        if(openFileDialog.ShowDialog() == DialogResult.OK)
        {
          string filePath = openFileDialog.FileName;
          List<Credential> userPasswords = new List<Credential>();
          
          switch(openFileDialog.FilterIndex)
          {
            case 1:
              JSONProcessor jsonProcessor = new JSONProcessor(filePath);
              userPasswords = jsonProcessor.ParseCredentialsFromFile().ToList();
              break;
            case 2:
              CSVProcessor csvProcessor = new CSVProcessor(filePath);
              userPasswords = csvProcessor.
                ParseCredentialsFromFile(CSVProcessor.CSVFileFormat.KeePass, csvProcessor.GetStringTable()).ToList();
              break;
          }

          if(userPasswords.Count == 0)
          {
            return;
          }

          foreach(Credential credential in userPasswords)
          {
            userPasswordDictionary.Add(new GUIEntryCreator(
              entryFlowLayoutPanel, 
              credential, 
              new MouseEventHandler(DeleteButton_OnMouseClick),
              new MouseEventHandler(EditButton_OnMouseClick)), credential);
          }
        }
      }
    }

    private void bttnMinimize_Click(object sender, EventArgs e)
    {
      WindowState = FormWindowState.Minimized;
    }

    private void buttonAddEntry_Click(object sender, EventArgs e)
    {
      EditEntryDialog editEntryDialog = new EditEntryDialog();
      if(editEntryDialog.ShowDialog() == DialogResult.OK)
      {
        Credential credential = new Credential(editEntryDialog.UserCredential);
        userPasswordDictionary.Add(new GUIEntryCreator(
          entryFlowLayoutPanel, 
          credential,
          new MouseEventHandler(DeleteButton_OnMouseClick),
          new MouseEventHandler(EditButton_OnMouseClick)), credential);
      }
    }
  }
}
