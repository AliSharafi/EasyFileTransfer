namespace EasyFileTransfer
{
    partial class FrmClipboard
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
            this.txtClipboard = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtClipboard
            // 
            this.txtClipboard.BackColor = System.Drawing.Color.Wheat;
            this.txtClipboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClipboard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClipboard.Location = new System.Drawing.Point(7, 17);
            this.txtClipboard.Multiline = true;
            this.txtClipboard.Name = "txtClipboard";
            this.txtClipboard.Size = new System.Drawing.Size(337, 102);
            this.txtClipboard.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Wheat;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(0, 122);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(349, 31);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send To Server";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(326, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmClipboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(349, 153);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtClipboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClipboard";
            this.Opacity = 0.75D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clipboard";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox txtClipboard;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
    }
}