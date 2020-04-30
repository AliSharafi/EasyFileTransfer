namespace EasyFileTransfer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pb = new CircularProgressBar.CircularProgressBar();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToServerToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // sendToServerToolStripMenuItem
            // 
            this.sendToServerToolStripMenuItem.Name = "sendToServerToolStripMenuItem";
            this.sendToServerToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.sendToServerToolStripMenuItem.Text = "Send to server";
            this.sendToServerToolStripMenuItem.Click += new System.EventHandler(this.sendToServerToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // pb
            // 
            this.pb.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.pb.AnimationSpeed = 500;
            this.pb.BackColor = System.Drawing.Color.Transparent;
            this.pb.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.pb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(202)))), ((int)(((byte)(53)))));
            this.pb.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(202)))), ((int)(((byte)(53)))));
            this.pb.InnerMargin = -1;
            this.pb.InnerWidth = 1;
            this.pb.Location = new System.Drawing.Point(17, 2);
            this.pb.Margin = new System.Windows.Forms.Padding(0);
            this.pb.MarqueeAnimationSpeed = 2000;
            this.pb.Name = "pb";
            this.pb.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(202)))), ((int)(((byte)(53)))));
            this.pb.OuterMargin = 1;
            this.pb.OuterWidth = 0;
            this.pb.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(202)))), ((int)(((byte)(53)))));
            this.pb.ProgressWidth = 5;
            this.pb.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.pb.Size = new System.Drawing.Size(100, 100);
            this.pb.StartAngle = 270;
            this.pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pb.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.pb.SubscriptText = ".23";
            this.pb.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pb.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.pb.SuperscriptText = "°C";
            this.pb.TabIndex = 1;
            this.pb.TextMargin = new System.Windows.Forms.Padding(0);
            this.pb.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pb);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy File Transfer";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.SteelBlue;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendToServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private CircularProgressBar.CircularProgressBar pb;
    }
}