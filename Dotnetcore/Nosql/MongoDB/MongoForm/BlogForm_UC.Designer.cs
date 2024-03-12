namespace MongoForm
{
    partial class BlogForm_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cBoxRating = new ComboBox();
            btnSave = new Button();
            label3 = new Label();
            txtUrl = new TextBox();
            label2 = new Label();
            txtTitle = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // cBoxRating
            // 
            cBoxRating.FormattingEnabled = true;
            cBoxRating.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cBoxRating.Location = new Point(126, 111);
            cBoxRating.Name = "cBoxRating";
            cBoxRating.Size = new Size(121, 23);
            cBoxRating.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(272, 153);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 111);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 12;
            label3.Text = "Rating";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(126, 79);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(221, 23);
            txtUrl.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 82);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 10;
            label2.Text = "Url";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(126, 50);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(221, 23);
            txtTitle.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 53);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 8;
            label1.Text = "Title";
            // 
            // BlogForm_UC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cBoxRating);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(txtUrl);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "BlogForm_UC";
            Size = new Size(401, 227);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cBoxRating;
        public Button btnSave;
        public Label label3;
        public TextBox txtUrl;
        public Label label2;
        public TextBox txtTitle;
        public Label label1;
    }
}
