namespace HM_07
{
    partial class MainWindow
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
            this.InputButton = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.HappyButton = new System.Windows.Forms.Button();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.InputfileButton = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label_times = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputButton
            // 
            this.InputButton.Location = new System.Drawing.Point(354, 287);
            this.InputButton.Name = "InputButton";
            this.InputButton.Size = new System.Drawing.Size(75, 23);
            this.InputButton.TabIndex = 0;
            this.InputButton.Text = "输入";
            this.InputButton.UseVisualStyleBackColor = true;
            this.InputButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(12, 28);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageBox.Size = new System.Drawing.Size(321, 201);
            this.MessageBox.TabIndex = 1;
            // 
            // HappyButton
            // 
            this.HappyButton.Location = new System.Drawing.Point(354, 206);
            this.HappyButton.Name = "HappyButton";
            this.HappyButton.Size = new System.Drawing.Size(75, 23);
            this.HappyButton.TabIndex = 2;
            this.HappyButton.Text = "增加快乐";
            this.HappyButton.UseVisualStyleBackColor = true;
            this.HappyButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(12, 247);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputBox.Size = new System.Drawing.Size(321, 63);
            this.InputBox.TabIndex = 3;
            this.InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            this.InputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyUp);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(354, 57);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "储存";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(354, 28);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 5;
            this.LoadButton.Text = "导入";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "machineinfo.txt";
            this.openFileDialog1.Filter = "txt|*.txt";
            this.openFileDialog1.InitialDirectory = "E:\\CProjects\\HM_07\\HM_07\\bin\\Debug";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(354, 177);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "清空";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(447, 15);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(65, 12);
            this.label_info.TabIndex = 8;
            this.label_info.Text = "系统信息：";
            // 
            // InputfileButton
            // 
            this.InputfileButton.Location = new System.Drawing.Point(354, 258);
            this.InputfileButton.Name = "InputfileButton";
            this.InputfileButton.Size = new System.Drawing.Size(75, 23);
            this.InputfileButton.TabIndex = 9;
            this.InputfileButton.Text = "输入文档";
            this.InputfileButton.UseVisualStyleBackColor = true;
            this.InputfileButton.Click += new System.EventHandler(this.InputfileButton_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "txt|*.txt";
            this.openFileDialog2.InitialDirectory = "E:\\CProjects\\HM_07\\HM_07\\bin\\Debug";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // label_times
            // 
            this.label_times.AutoSize = true;
            this.label_times.Location = new System.Drawing.Point(207, 9);
            this.label_times.Name = "label_times";
            this.label_times.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_times.Size = new System.Drawing.Size(71, 12);
            this.label_times.TabIndex = 10;
            this.label_times.Text = "输入次数：0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "查看全部";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 323);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_times);
            this.Controls.Add(this.InputfileButton);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.HappyButton);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.InputButton);
            this.Name = "MainWindow";
            this.Text = "=w=";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InputButton;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button HappyButton;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button InputfileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label_times;
        private System.Windows.Forms.Button button1;
    }
}

