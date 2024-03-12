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
            btnClean = new Button();
            btnTask1 = new Button();
            btnTask2 = new Button();
            rtb_output = new RichTextBox();
            label1 = new Label();
            cb_ConfigureAwaitFalse = new CheckBox();
            SuspendLayout();
            // 
            // btnGetMessage
            // 
            btnGetMessage.Location = new Point(480, 88);
            btnGetMessage.Name = "btnGetMessage";
            btnGetMessage.Size = new Size(126, 23);
            btnGetMessage.TabIndex = 0;
            btnGetMessage.Text = "Get Message Async";
            btnGetMessage.UseVisualStyleBackColor = true;
            btnGetMessage.Click += btnGetMessage_Click;
            // 
            // btnClean
            // 
            btnClean.Location = new Point(12, 325);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(56, 23);
            btnClean.TabIndex = 4;
            btnClean.Text = "Clean";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // btnTask1
            // 
            btnTask1.Location = new Point(480, 265);
            btnTask1.Name = "btnTask1";
            btnTask1.Size = new Size(126, 23);
            btnTask1.TabIndex = 5;
            btnTask1.Text = "Start Task 1";
            btnTask1.UseVisualStyleBackColor = true;
            btnTask1.Click += btnTask1_Click;
            // 
            // btnTask2
            // 
            btnTask2.Location = new Point(480, 294);
            btnTask2.Name = "btnTask2";
            btnTask2.Size = new Size(126, 23);
            btnTask2.TabIndex = 6;
            btnTask2.Text = "Start Task 2";
            btnTask2.UseVisualStyleBackColor = true;
            btnTask2.Click += btnTask2_Click;
            // 
            // rtb_output
            // 
            rtb_output.Location = new Point(12, 49);
            rtb_output.Name = "rtb_output";
            rtb_output.ReadOnly = true;
            rtb_output.Size = new Size(462, 270);
            rtb_output.TabIndex = 7;
            rtb_output.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 8;
            label1.Text = "Output :";
            // 
            // cb_ConfigureAwaitFalse
            // 
            cb_ConfigureAwaitFalse.AllowDrop = true;
            cb_ConfigureAwaitFalse.AutoSize = true;
            cb_ConfigureAwaitFalse.Location = new Point(480, 63);
            cb_ConfigureAwaitFalse.Name = "cb_ConfigureAwaitFalse";
            cb_ConfigureAwaitFalse.Size = new Size(163, 19);
            cb_ConfigureAwaitFalse.TabIndex = 9;
            cb_ConfigureAwaitFalse.Text = "Use ConfigureAwait(false)";
            cb_ConfigureAwaitFalse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 364);
            Controls.Add(cb_ConfigureAwaitFalse);
            Controls.Add(label1);
            Controls.Add(rtb_output);
            Controls.Add(btnTask2);
            Controls.Add(btnTask1);
            Controls.Add(btnClean);
            Controls.Add(btnGetMessage);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetMessage;
        private Button btnClean;
        private Button btnTask1;
        private Button btnTask2;
        private RichTextBox rtb_output;
        private Label label1;
        private CheckBox cb_ConfigureAwaitFalse;
    }
}
