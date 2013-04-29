namespace TdViewTester
{
  using System.ComponentModel;
  using System.Data;
  using System.Data.OleDb;

  public class SQLInfo
  {
    public string DatabaseName { get; set; }

    public OleDbException Error { get; set; }

    public bool ErrorOccured { get; set; }

    public OleDbConnection OleDbConnectionString { get; set; }
    
    public OleDbCommand OleDbCommandObject { get; set; }
    
    public DataTable ResultsDataTable { get; set; }

    public string ViewName { get; set; }
  }

  public class SQLRunner
  {
    public SQLRunner(SQLInfo sqlInfo)
    {
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += this.BW_DoWork;
      backgroundWorker.RunWorkerCompleted += this.BW_RunWorkerCompleted;
      backgroundWorker.RunWorkerAsync(sqlInfo);
    }

    public delegate void SQLFinishedRunningHandler(SQLInfo SQLI);

    public event SQLFinishedRunningHandler OnSQLFinishedRunning;
 
    private void BW_DoWork(object sender, DoWorkEventArgs e)
    {
      SQLInfo sqlInfo = (SQLInfo)e.Argument;
      sqlInfo = this.GetQueryResults(sqlInfo);
      e.Result = sqlInfo;
    }
    
    private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.OnSQLFinishedRunning((SQLInfo)e.Result);
    }
    
    private SQLInfo GetQueryResults(SQLInfo sqlInfo)
    {
      OleDbConnection cn = sqlInfo.OleDbConnectionString;
      OleDbCommand cmd = sqlInfo.OleDbCommandObject;

      try
      {
        cmd.Connection = cn;
        cmd.CommandTimeout = 0;

        cn.Open();

        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet("report");
        da.Fill(ds, "DataTable");
        sqlInfo.ResultsDataTable = ds.Tables["DataTable"];
        cn.Close();
      }
      catch (OleDbException exception)
      {
        sqlInfo.ErrorOccured = true;
        sqlInfo.Error = exception;
      }
      finally
      {
        if (cn.State == ConnectionState.Open)
        {
          cn.Close();
        }

        cn = null;
        cmd = null;
      }

      return sqlInfo;
    }
  }
}
