

namespace WikiViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            buttonSave = new Button();
            label2 = new Label();
            label1 = new Label();
            textBoxPassword = new TextBox();
            textBoxUsername = new TextBox();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(1216, 651);
            webView21.TabIndex = 0;
            webView21.Visible = false;
            webView21.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonSave);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxPassword);
            panel1.Controls.Add(textBoxUsername);
            panel1.Location = new Point(396, 96);
            panel1.Name = "panel1";
            panel1.Size = new Size(452, 224);
            panel1.TabIndex = 1;
            panel1.Visible = false;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(121, 152);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(136, 29);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save and Load";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 80);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 31);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(132, 77);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(283, 27);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(131, 28);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(284, 27);
            textBoxUsername.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 651);
            Controls.Add(panel1);
            Controls.Add(webView21);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += this.Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }        

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private Button buttonSave;
    }
}
