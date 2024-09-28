namespace EnergyTotal.WinForm.Forms.Dialogs
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            richTextBox = new RichTextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            okButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox
            // 
            resources.ApplyResources(richTextBox, "richTextBox");
            richTextBox.AutoWordSelection = true;
            richTextBox.BackColor = Color.White;
            richTextBox.BorderStyle = BorderStyle.FixedSingle;
            richTextBox.ForeColor = Color.Black;
            richTextBox.Name = "richTextBox";
            richTextBox.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(okButton);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // okButton
            // 
            resources.ApplyResources(okButton, "okButton");
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(richTextBox, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // About
            // 
            AcceptButton = okButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            ShowInTaskbar = false;
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button okButton;
        private TableLayoutPanel tableLayoutPanel1;
    }
}