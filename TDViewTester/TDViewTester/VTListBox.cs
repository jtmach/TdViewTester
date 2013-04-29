namespace TdViewTester
{
  using System.Drawing;
  using System.Windows.Forms;

  public class VTListBox : ListBox
  {
    public VTListBox()
    {
      // Activate double buffering
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

      // Enable the OnNotifyMessage event so we get a chance to filter out 
      // Windows messages before they get to the form's WndProc
      this.SetStyle(ControlStyles.EnableNotifyMessage, true);

      this.DrawItem += this.VTListBox_DrawItem;
    }

    protected void VTListBox_DrawItem(object sender, DrawItemEventArgs e)
    {
      VTListBox listBox = (VTListBox)sender;
      if (listBox.Items.Count > 0)
      {
        e.DrawBackground();
        
        // Let's declare a brush, so that we can color the items that are added in the listbox.
        Brush myBrush = Brushes.Black;
        Font myFont = new Font(this.Font, FontStyle.Regular);
        if (e.State == DrawItemState.Selected)
        {
          e.Graphics.FillRectangle(Brushes.LightCyan, e.Bounds);
        }
        
        // Determine the color of the brush to draw each item based on the index of the item to draw.
        TDViews teradataViews = (TDViews)this.Items[e.Index];
        switch (teradataViews.ViewState)
        {
          case TDViews.TDViewState.Checking:
            myBrush = Brushes.Gray;
            break;
          case TDViews.TDViewState.Err:
            myBrush = Brushes.Red;
            myFont = new Font(myFont, FontStyle.Bold);
            break;
          case TDViews.TDViewState.NoErr:
            myBrush = Brushes.Green;
            break;
          case TDViews.TDViewState.NotChecked:
            myBrush = Brushes.Black;
            break;
        }
        
        // Draw the current item text based on the current Font and the custom brush settings.
        e.Graphics.DrawString(this.Items[e.Index].ToString(), myFont, myBrush, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
        
        // If the ListBox has focus, draw a focus rectangle around the selected item.
        e.DrawFocusRectangle();
      }
    }

    protected override void OnNotifyMessage(Message m)
    {
      // Filter out the WM_ERASEBKGND message
      if (m.Msg != 0x14)
      {
        base.OnNotifyMessage(m);
      }
    }
  }
}
