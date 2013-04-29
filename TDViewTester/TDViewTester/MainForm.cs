namespace TdViewTester
{
  using System;
  using System.Data;
  using System.Data.OleDb;
  using System.IO;
  using System.Windows.Forms;

  public partial class MainForm : Form
  {
    private int checkedViews;
    private int errorViews;

    public MainForm()
    {
      InitializeComponent();
    }

    private string ConnectionString
    {
      get
      {
        return string.Format("Provider=TdOleDb.1;Data Source={0};{1};{2};Connect Timeout=90;", this.tbServerName.Text, this.UserId, this.Password);
      }
    }

    private string Password
    {
      get
      {
        return "Password=" + this.tbPassword.Text;
      }
    }

    private string UserId
    {
      get
      {
        return "User ID=" + this.tbUserID.Text;
      }
    }

    private void GetViews()
    {
      this.toolStripStatusLabel1.Text = "Getting views please wait";
      this.btnCheckViews.Enabled = false;
      ViewsListBox.Items.Clear();

      SQLInfo sqlInfo = new SQLInfo();
      sqlInfo.OleDbConnectionString = new OleDbConnection(this.ConnectionString);
      sqlInfo.OleDbCommandObject = new OleDbCommand("SELECT TBLS.* FROM DBC.TABLES TBLS WHERE (DATABASENAME LIKE '" + this.tbDatabaseName.Text + "') AND TABLEKIND LIKE '%V%'");

      SQLRunner sqlRunner = new SQLRunner(sqlInfo);
      sqlRunner.OnSQLFinishedRunning += this.SQLR_OnSQLFinishedRunning;
    }
    
    private void CheckViews()
    {
      foreach (TDViews teradataView in ViewsListBox.Items)
      {
        teradataView.ViewState = TDViews.TDViewState.Checking;
        ViewsListBox.Refresh();

        SQLInfo sqlInfo = new SQLInfo();
        sqlInfo.OleDbConnectionString = new OleDbConnection(string.Format(ConnectionString, this.tbUserID.Text, this.tbPassword.Text));
        sqlInfo.OleDbCommandObject = new OleDbCommand("EXPLAIN SELECT * FROM " + teradataView.DataBaseName + "." + teradataView.ViewName);
        sqlInfo.DatabaseName = teradataView.DataBaseName;
        sqlInfo.ViewName = teradataView.ViewName;

        SQLRunner sqlRunner = new SQLRunner(sqlInfo);
        sqlRunner.OnSQLFinishedRunning += this.CheckViewFinished;
      }
    }
    
    private void CheckViewFinished(SQLInfo sqlInfo)
    {
      TDViews teradataView = null;

      foreach (TDViews view in this.ViewsListBox.Items)
      {
        if (view.DataBaseName == sqlInfo.DatabaseName && view.ViewName == sqlInfo.ViewName)
        {
          teradataView = view;
        }
      }

      if (teradataView == null)
      {
        return;
      }

      if (sqlInfo.ErrorOccured == false)
      {
        teradataView.ViewState = TDViews.TDViewState.NoErr;
        ViewsListBox.Refresh();
      }
      else
      {
        teradataView.ViewState = TDViews.TDViewState.Err;
        teradataView.ErrorText = sqlInfo.Error.Message;
        this.errorViews++;

        SQLInfo sqlinfo2 = new SQLInfo();
        sqlinfo2.DatabaseName = teradataView.DataBaseName;
        sqlinfo2.ViewName = teradataView.ViewName;
        sqlinfo2.OleDbConnectionString = new OleDbConnection(string.Format(ConnectionString, this.tbUserID.Text, this.tbPassword.Text));
        sqlinfo2.OleDbCommandObject = new OleDbCommand("SHOW VIEW " + teradataView.DataBaseName + "." + teradataView.ViewName);

        SQLRunner sqlRunner = new SQLRunner(sqlinfo2);
        sqlRunner.OnSQLFinishedRunning += this.ShowViewFinished;

        ViewsListBox.Refresh();
      }

      this.checkedViews++;

      double percentComplete = Math.Round(this.checkedViews / (double)ViewsListBox.Items.Count, 4) * 100;
      this.toolStripStatusLabel1.Text = percentComplete + "% Complete; Status: " + this.errorViews + "/" + ViewsListBox.Items.Count + " didn't run.";
    }
    
    private void ShowViewFinished(SQLInfo sqlInfo)
    {
      if (sqlInfo.ErrorOccured == false)
      {
        foreach (TDViews teradataView in this.ViewsListBox.Items)
        {
          if (teradataView.DataBaseName.ToUpper() == sqlInfo.DatabaseName.ToUpper() && teradataView.ViewName.ToUpper() == sqlInfo.ViewName.ToUpper())
          {
            teradataView.Script = sqlInfo.ResultsDataTable.Rows[0][0].ToString();
          }
        }
      }
    }

    private void CheckViews_Click(object sender, EventArgs e)
    {
      btnCheckViews.Enabled = false;
      this.errorViews = 0;
      this.CheckViews();
      this.btnWriteResults.Enabled = true;
    }
    
    private void GetViews_Click(object sender, EventArgs e)
    {
      this.GetViews();
    }
    
    private void WriteResults_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.AddExtension = true;
      saveFileDialog.CheckPathExists = true;
      saveFileDialog.DefaultExt = "sql";
      saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        if (saveFileDialog.FileName != null)
        {
          StreamWriter streamWriter = new StreamWriter(saveFileDialog.OpenFile());

          foreach (TDViews teradataViews in this.ViewsListBox.Items)
          {
            if (teradataViews.ErrorText != string.Empty)
            {
              string line = string.Empty;
              line += teradataViews.DataBaseName + "." + teradataViews.ViewName + "|";

              line += teradataViews.CreateTimeStamp + "|";
              line += teradataViews.LastAccessTimeStamp + "|";

              if (teradataViews.LastAlterName != string.Empty)
              {
                line += teradataViews.LastAlterName + "|";
              }
              else if (teradataViews.LastAlterID != string.Empty)
              {
                line += teradataViews.LastAlterID + "|";
              }
              else if (teradataViews.CreatorName != string.Empty)
              {
                line += teradataViews.CreatorName + "|";
              }
              else
              {
                line += teradataViews.CreatorID + "|";
              }

              line += teradataViews.ErrorText;
              streamWriter.WriteLine(line);
            }
          }

          streamWriter.WriteLine(string.Empty);
          streamWriter.WriteLine(string.Empty);

          foreach (TDViews teradataView in this.ViewsListBox.Items)
          {
            if (!string.IsNullOrEmpty(teradataView.ErrorText))
            {
              streamWriter.WriteLine("-----------------------------------------------------------");
              streamWriter.WriteLine(teradataView.DataBaseName + "." + teradataView.ViewName);
              streamWriter.WriteLine("-----------------------------------------------------------");
              streamWriter.WriteLine(teradataView.Script);
            }
          }

          streamWriter.Close();
        }
      }
    }
    
    private void SQLR_OnSQLFinishedRunning(SQLInfo sqlInfo)
    {
      if (sqlInfo.ErrorOccured == false)
      {
        foreach (DataRow dr in sqlInfo.ResultsDataTable.Rows)
        {
          TDViews teradataViews = new TDViews(dr["DatabaseName"].ToString().Trim(), dr["TableName"].ToString().Trim());
          teradataViews.CreateTimeStamp = dr.Table.Columns.Contains("CreateTimeStamp") ? dr["CreateTimeStamp"].ToString().Trim() : string.Empty;
          teradataViews.CreatorID = dr["CreatorName"].ToString().Trim();
          teradataViews.CreatorName = dr.Table.Columns.Contains("OWNER_NAME") ? dr["OWNER_NAME"].ToString().Trim() : string.Empty;
          teradataViews.LastAlterID = dr.Table.Columns.Contains("LastAlterName") ? dr["LastAlterName"].ToString().Trim() : string.Empty;
          teradataViews.LastAlterName = dr.Table.Columns.Contains("Last_Alter_Name") ? dr["Last_Alter_Name"].ToString().Trim() : string.Empty;
          teradataViews.LastAccessTimeStamp = dr.Table.Columns.Contains("LastAccessTimeStamp") ? dr["LastAccessTimeStamp"].ToString().Trim() : string.Empty;
          ViewsListBox.Items.Add(teradataViews);
        }

        this.btnCheckViews.Enabled = true;
        this.toolStripStatusLabel1.Text = "Found " + sqlInfo.ResultsDataTable.Rows.Count.ToString() + " views";
      }
      else
      {
        this.toolStripStatusLabel1.Text = "Error Occured: " + sqlInfo.Error.Message;
      }
    }
    
    private void ViewsListBox_MouseClick(object sender, MouseEventArgs e)
    {
      int index = ViewsListBox.IndexFromPoint(e.Location);
      if ((index >= 0) && (index < ViewsListBox.Items.Count))
      {
        TDViews teradataViews = (TDViews)ViewsListBox.Items[index];
        if (!string.IsNullOrEmpty(teradataViews.ErrorText))
        {
          toolTip1.SetToolTip(ViewsListBox, teradataViews.ErrorText);
        }
      }
    }
    
    private void ViewsListBox_MouseMove(object sender, MouseEventArgs e)
    {
      int index = ViewsListBox.IndexFromPoint(e.Location);
      if ((index >= 0) && (index < ViewsListBox.Items.Count))
      {
        TDViews teradataViews = (TDViews)ViewsListBox.Items[index];
        if (!string.IsNullOrEmpty(teradataViews.ErrorText))
        {
          toolTip1.SetToolTip(ViewsListBox, teradataViews.ErrorText);
        }
      }
    }
    
    private void ViewsListBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (ViewsListBox.SelectedIndex >= 0 && e.Control && e.KeyCode == Keys.C)
      {
        Clipboard.SetText(ViewsListBox.SelectedItem.ToString());
      }
    }
  }
}