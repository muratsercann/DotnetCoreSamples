namespace ConfigureAwait
{
    partial class Form2
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
            listBoxThreads = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // listBoxThreads
            // 
            listBoxThreads.FormattingEnabled = true;
            listBoxThreads.ItemHeight = 15;
            listBoxThreads.Location = new Point(12, 12);
            listBoxThreads.Name = "listBoxThreads";
            listBoxThreads.Size = new Size(494, 334);
            listBoxThreads.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 363);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(listBoxThreads);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxThreads;
        private Button button1;
    }
}