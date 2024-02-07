namespace WinFormsApp1
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
            btnGetMessage = new Button();
            listBox1 = new ListBox();
            btnClean = new Button();
            SuspendLayout();
            // 
            // btnGetMessage
            // 
            btnGetMessage.Location = new Point(12, 12);
            btnGetMessage.Name = "btnGetMessage";
            btnGetMessage.Size = new Size(127, 31);
            btnGetMessage.TabIndex = 0;
            btnGetMessage.Text = "Get Message Async";
            btnGetMessage.UseVisualStyleBackColor = true;
            btnGetMessage.Click += btnGetMessage_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 50);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(462, 154);
            listBox1.TabIndex = 3;
            // 
            // btnClean
            // 
            btnClean.Location = new Point(399, 12);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 31);
            btnClean.TabIndex = 4;
            btnClean.Text = "Clean";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 212);
            Controls.Add(btnClean);
            Controls.Add(listBox1);
            Controls.Add(btnGetMessage);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGetMessage;
        private RichTextBox richTextBox1;
        private ListBox listBox1;
        private Button btnClean;
    }
}
