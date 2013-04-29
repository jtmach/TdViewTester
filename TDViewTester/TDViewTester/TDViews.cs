namespace TdViewTester
{
  public class TDViews
  {
    public TDViews(string databaseName, string viewName)
    {
      this.DataBaseName = databaseName;
      this.ViewName = viewName;
      this.ViewState = TDViewState.NotChecked;
      this.ErrorText = string.Empty;
    }

    public enum TDViewState
    {
      Checking,
      Err,
      NoErr,
      NotChecked
    }

    public string CreateTimeStamp { get; set; }

    public string CreatorID { get; set; }

    public string CreatorName { get; set; }

    public string DataBaseName { get; set; }

    public string ErrorText { get; set; }

    public string LastAlterID { get; set; }

    public string LastAccessTimeStamp { get; set; }

    public string LastAlterName { get; set; }

    public string Script { get; set; }

    public string ViewName { get; set; }

    public TDViewState ViewState { get; set; }

    public override string ToString()
    {
      return this.DataBaseName + "." + this.ViewName;
    }
  }
}
