namespace TdViewTester
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.components = new System.ComponentModel.Container();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnWriteResults = new System.Windows.Forms.Button();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbUserID = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnGetViews = new System.Windows.Forms.Button();
      this.btnCheckViews = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.tbServerName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.ViewsListBox = new TdViewTester.VTListBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tbDatabaseName = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tbDatabaseName);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.tbServerName);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.btnWriteResults);
      this.panel1.Controls.Add(this.tbPassword);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.tbUserID);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.btnGetViews);
      this.panel1.Controls.Add(this.btnCheckViews);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(750, 57);
      this.panel1.TabIndex = 0;
      // 
      // btnWriteResults
      // 
      this.btnWriteResults.Enabled = false;
      this.btnWriteResults.Location = new System.Drawing.Point(394, 31);
      this.btnWriteResults.Name = "btnWriteResults";
      this.btnWriteResults.Size = new System.Drawing.Size(85, 23);
      this.btnWriteResults.TabIndex = 5;
      this.btnWriteResults.Text = "Write Results";
      this.btnWriteResults.UseVisualStyleBackColor = true;
      this.btnWriteResults.Click += new System.EventHandler(this.WriteResults_Click);
      // 
      // tbPassword
      // 
      this.tbPassword.Location = new System.Drawing.Point(387, 5);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.PasswordChar = '*';
      this.tbPassword.Size = new System.Drawing.Size(100, 20);
      this.tbPassword.TabIndex = 2;
      this.tbPassword.UseSystemPasswordChar = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(348, 8);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(33, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Pswd";
      // 
      // tbUserID
      // 
      this.tbUserID.Location = new System.Drawing.Point(242, 5);
      this.tbUserID.Name = "tbUserID";
      this.tbUserID.Size = new System.Drawing.Size(100, 20);
      this.tbUserID.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(193, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "User ID";
      // 
      // btnGetViews
      // 
      this.btnGetViews.Location = new System.Drawing.Point(213, 30);
      this.btnGetViews.Name = "btnGetViews";
      this.btnGetViews.Size = new System.Drawing.Size(84, 23);
      this.btnGetViews.TabIndex = 3;
      this.btnGetViews.Text = "Get Views";
      this.btnGetViews.UseVisualStyleBackColor = true;
      this.btnGetViews.Click += new System.EventHandler(this.GetViews_Click);
      // 
      // btnCheckViews
      // 
      this.btnCheckViews.Enabled = false;
      this.btnCheckViews.Location = new System.Drawing.Point(303, 30);
      this.btnCheckViews.Name = "btnCheckViews";
      this.btnCheckViews.Size = new System.Drawing.Size(85, 23);
      this.btnCheckViews.TabIndex = 4;
      this.btnCheckViews.Text = "Check Views";
      this.btnCheckViews.UseVisualStyleBackColor = true;
      this.btnCheckViews.Click += new System.EventHandler(this.CheckViews_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
      this.statusStrip1.Location = new System.Drawing.Point(0, 335);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(750, 22);
      this.statusStrip1.TabIndex = 3;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.ViewsListBox);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 57);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(750, 278);
      this.panel3.TabIndex = 4;
      // 
      // tbServerName
      // 
      this.tbServerName.Location = new System.Drawing.Point(87, 5);
      this.tbServerName.Name = "tbServerName";
      this.tbServerName.Size = new System.Drawing.Size(100, 20);
      this.tbServerName.TabIndex = 0;
      this.toolTip1.SetToolTip(this.tbServerName, "Database Name or IP Address");
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Server Name";
      // 
      // ViewsListBox
      // 
      this.ViewsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ViewsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.ViewsListBox.FormattingEnabled = true;
      this.ViewsListBox.Location = new System.Drawing.Point(0, 0);
      this.ViewsListBox.Name = "ViewsListBox";
      this.ViewsListBox.Size = new System.Drawing.Size(750, 278);
      this.ViewsListBox.Sorted = true;
      this.ViewsListBox.TabIndex = 0;
      this.ViewsListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ViewsListBox_MouseClick);
      this.ViewsListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewsListBox_KeyDown);
      this.ViewsListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewsListBox_MouseMove);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 34);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(84, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Database Name";
      this.toolTip1.SetToolTip(this.label4, "Will accept wildcards");
      // 
      // tbDatabaseName
      // 
      this.tbDatabaseName.Location = new System.Drawing.Point(102, 31);
      this.tbDatabaseName.Name = "tbDatabaseName";
      this.tbDatabaseName.Size = new System.Drawing.Size(100, 20);
      this.tbDatabaseName.TabIndex = 10;
      this.toolTip1.SetToolTip(this.tbDatabaseName, "Database Name or IP Address");
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(750, 357);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.panel1);
      this.DoubleBuffered = true;
      this.MinimumSize = new System.Drawing.Size(491, 395);
      this.Name = "MainForm";
      this.Text = "TD View Tester";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGetViews;
		private System.Windows.Forms.Button btnCheckViews;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbUserID;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Panel panel3;
		private VTListBox ViewsListBox;
    private System.Windows.Forms.Button btnWriteResults;
    private System.Windows.Forms.TextBox tbServerName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbDatabaseName;
    private System.Windows.Forms.Label label4;
	}
}

