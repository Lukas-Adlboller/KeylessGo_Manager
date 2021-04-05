using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using libKeylessGo;

namespace KeylessGo_GUI
{
  public enum SerialCommand
  {
    COMM_GET_ACC_NUM = 0x24,
    COMM_GET_ACC = 0x25,
    COMM_ADD_ACC = 0x26,
    COMM_REM_ACC = 0x27,
    COMM_EDIT_ACC = 0x28,
    COMM_GET_UNIQUE_ID = 0x29,
    COMM_GET_ALL_ENTRIES = 0x30,
    COMM_SEND_ACC_NUM = 0x40,
    COMM_SEND_ACC = 0x41,
    COMM_SEND_UNIQUE_ID = 0x42
  }

  public enum SerialCommandLimiter
  {
    COMM_BEGIN = 0x02,
    COMM_END = 0x03,
    US = 0x1F,
    ACK = 0x06,
    NACK = 0x15
  }

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
    public static Credential credentialQueue;
    public static SerialPort serialPort;

    public MainForm()
    {
      InitializeComponent();
      userPasswordDictionary = new Dictionary<GUIEntryCreator, Credential>();

      serialPort = new SerialPort("COM11", 9600);
      serialPort.Parity = Parity.None;
      serialPort.DataBits = 8;
      serialPort.StopBits = StopBits.One;
      serialPort.DtrEnable = true;
      serialPort.DataReceived += new SerialDataReceivedEventHandler(onSerialDataRecieve);

      try
      {
        serialPort.Open();
        
        if(!serialPort.IsOpen)
        {
          MessageBox.Show("Serial COM Port could not be opened!", "Serial COM Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          Environment.Exit(-1);
        }
      }
      catch (IOException ex)
      {
        MessageBox.Show("Serial COM Port could not be opened!", "Serial COM Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Environment.Exit(-1);
      }
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

    public static bool isValidCommand(byte[] data)
    {
      bool hasCommandBeginAndEnd = data[0] == (byte)SerialCommandLimiter.COMM_BEGIN && data[data.Length - 1] == (byte)SerialCommandLimiter.COMM_END;
      bool commandIsValid = Enum.IsDefined(typeof(SerialCommand), Convert.ToInt32(data[1]));

      return hasCommandBeginAndEnd && commandIsValid;
    }

    public string extractEntryData(ref byte[] data, byte limiter)
    {
      int length = Array.IndexOf(data, limiter);
      string strData = Encoding.ASCII.GetString(data.Take(length).ToArray());
      data = data.Skip(length + 1).ToArray();
      return strData;
    }

    private void onSerialDataRecieve(object sender, SerialDataReceivedEventArgs args)
    {
      string strData = serialPort.ReadExisting();

      byte[] byteData;
      try
      {
        byteData = Convert.FromBase64String(strData);
      }
      catch (FormatException ex)
      {
        return;
      }

      if(byteData[0] == (byte)SerialCommandLimiter.NACK)
      {
        MessageBox.Show("Something went wrong while communicating with the device!", "Device Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if(byteData.Length < 4)
      {
        return;
      }

      if(!isValidCommand(byteData))
      {
        MessageBox.Show("Recieved an invalid command!", "Invalid Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      int entryId;
      switch((SerialCommand)byteData[1])
      {
        case SerialCommand.COMM_SEND_ACC:
          entryId = (byteData[2] << 8) | byteData[3];
          byteData = byteData.Skip(4).ToArray();

          string title = extractEntryData(ref byteData, (byte)SerialCommandLimiter.US);
          string usr = extractEntryData(ref byteData, (byte)SerialCommandLimiter.US);
          string email = extractEntryData(ref byteData, (byte)SerialCommandLimiter.US);
          string pwd = extractEntryData(ref byteData, (byte)SerialCommandLimiter.US);
          string url = extractEntryData(ref byteData, (byte)SerialCommandLimiter.COMM_END);

          this.Invoke(new Action<int, string, string, string, string, string>(AddEntryFromSerial), entryId, title, usr, email, pwd, url);
          break;
        case SerialCommand.COMM_SEND_UNIQUE_ID:
          if(credentialQueue != null)
          {
            entryId = (byteData[2] << 8) | byteData[3];
            this.Invoke(
              new Action<int, string, string, string, string, string>(SendEntryToSerial),
              entryId,
              credentialQueue.GetData(Credential.UserDataType.Title),
              credentialQueue.GetData(Credential.UserDataType.Username),
              credentialQueue.GetData(Credential.UserDataType.Email),
              credentialQueue.GetData(Credential.UserDataType.Password),
              credentialQueue.GetData(Credential.UserDataType.Website));
            credentialQueue = null;
          }
          break;
      }
    }

    private void AddEntryFromSerial(int id, string title, string usr, string email, string pwd, string url)
    {
      Dictionary<Credential.UserDataType, string> userData = new Dictionary<Credential.UserDataType, string>()
      {
        { Credential.UserDataType.Id, id.ToString() },
        { Credential.UserDataType.Title, title },
        { Credential.UserDataType.Email, email },
        { Credential.UserDataType.Username, usr },
        { Credential.UserDataType.Password, pwd },
        { Credential.UserDataType.Website, url },
      };

      Credential credential = new Credential(userData);
      userPasswordDictionary.Add(new GUIEntryCreator(
        entryFlowLayoutPanel,
        credential,
        new MouseEventHandler(DeleteButton_OnMouseClick),
        new MouseEventHandler(EditButton_OnMouseClick)), credential);

      if(userPasswordDictionary.Count > 0)
      {
        lblPlaceholder.Visible = false;
      }
    }

    private static void CopyArray(string input, ref byte[] output, ref int outputIdx, int maxLength)
    {
      byte[] strByteData = Encoding.ASCII.GetBytes(input);
      for(var i = 0; i < maxLength; i++)
      {
        output[outputIdx++] = strByteData[i];

        if(strByteData.Length == i + 1)
        {
          return;
        }
      }
    }

    private void SendEntryToSerial(int id, string title, string usr, string email, string pwd, string url)
    {
      AddEntryFromSerial(id, title, usr, email, pwd, url);

      byte[] command = new byte[180];
      command[0] = (byte)SerialCommandLimiter.COMM_BEGIN;
      command[1] = (byte)SerialCommand.COMM_ADD_ACC;

      int commandIdx = 2;
      CopyArray(title, ref command, ref commandIdx, 16);
      command[commandIdx++] = (byte)SerialCommandLimiter.US;
      CopyArray(usr, ref command, ref commandIdx, 32);
      command[commandIdx++] = (byte)SerialCommandLimiter.US;
      CopyArray(email, ref command, ref commandIdx, 64);
      command[commandIdx++] = (byte)SerialCommandLimiter.US;
      CopyArray(pwd, ref command, ref commandIdx, 32);
      command[commandIdx++] = (byte)SerialCommandLimiter.US;
      CopyArray(url, ref command, ref commandIdx, 24);
      command[commandIdx++] = (byte)SerialCommandLimiter.COMM_END;

      serialPort.Write(command, 0, command.Length);
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
      this.Close();
    }

    public void DeleteButton_OnMouseClick(object sender, MouseEventArgs e)
    {
      if(MessageBox.Show("Do you really want to delete this entry?", "Remove Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
      {
        Panel panel = (Panel)((Button)sender).Parent;
        GUIEntryCreator guiEntryCreator = userPasswordDictionary.Keys.First(x => x.entryPanel == panel);

        Credential credential;
        userPasswordDictionary.TryGetValue(guiEntryCreator, out credential);
        int entryId = int.Parse(credential.GetData(Credential.UserDataType.Id));

        entryFlowLayoutPanel.Controls.Remove(guiEntryCreator.entryPanel);
        userPasswordDictionary.Remove(guiEntryCreator);

        byte[] command =
        {
          (byte)SerialCommandLimiter.COMM_BEGIN,
          (byte)SerialCommand.COMM_REM_ACC,
          (byte)((entryId & 0xFF00) >> 8),
          (byte)(entryId & 0xFF),
          (byte)SerialCommandLimiter.COMM_END
        };
        serialPort.Write(command, 0, 5);

        if (userPasswordDictionary.Count == 0)
        {
          lblPlaceholder.Visible = true;
        }
      }
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

        int entryId = int.Parse(credential.GetData(Credential.UserDataType.Id));
        byte[] command = new byte[180];
        command[0] = (byte)SerialCommandLimiter.COMM_BEGIN;
        command[1] = (byte)SerialCommand.COMM_EDIT_ACC;
        command[2] = (byte)((entryId & 0xFF00) >> 8);
        command[3] = (byte)(entryId & 0xFF00);
        command[4] = (byte)SerialCommandLimiter.US;

        int commandIdx = 5;
        CopyArray(credential.GetData(Credential.UserDataType.Title), ref command, ref commandIdx, 16);
        command[commandIdx++] = (byte)SerialCommandLimiter.US;
        CopyArray(credential.GetData(Credential.UserDataType.Username), ref command, ref commandIdx, 32);
        command[commandIdx++] = (byte)SerialCommandLimiter.US;
        CopyArray(credential.GetData(Credential.UserDataType.Email), ref command, ref commandIdx, 64);
        command[commandIdx++] = (byte)SerialCommandLimiter.US;
        CopyArray(credential.GetData(Credential.UserDataType.Password), ref command, ref commandIdx, 32);
        command[commandIdx++] = (byte)SerialCommandLimiter.US;
        CopyArray(credential.GetData(Credential.UserDataType.Website), ref command, ref commandIdx, 24);
        command[commandIdx++] = (byte)SerialCommandLimiter.COMM_END;

        serialPort.Write(command, 0, command.Length);
      }
    }

    private void buttonImportFile_Click(object sender, EventArgs e)
    {
      // Import does work but sending accounts to device does not.

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
        credentialQueue = new Credential(editEntryDialog.UserCredential);
      }

      byte[] command =
      {
        (byte)SerialCommandLimiter.COMM_BEGIN,
        (byte)SerialCommand.COMM_GET_UNIQUE_ID,
        (byte)SerialCommandLimiter.COMM_END
      };
      serialPort.Write(command, 0, 3);

      if(userPasswordDictionary.Count != 0)
      {
        lblPlaceholder.Visible = false;
      }
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      serialPort.Close();
    }

    private void buttonSyncDevice_Click(object sender, EventArgs e)
    {
      List<GUIEntryCreator> entries = userPasswordDictionary.Keys.ToList();
      foreach (GUIEntryCreator entry in entries)
      {
        entryFlowLayoutPanel.Controls.Remove(entry.entryPanel);
        userPasswordDictionary.Remove(entry);
      }

      byte[] command =
      {
        (byte)SerialCommandLimiter.COMM_BEGIN,
        (byte)SerialCommand.COMM_GET_ALL_ENTRIES,
        (byte)SerialCommandLimiter.COMM_END
      };

      serialPort.Write(command, 0, 3);
    }
  }
}
