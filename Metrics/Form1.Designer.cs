namespace Metrics
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EvaluateJilbBtn = new System.Windows.Forms.Button();
            this.JilbMetricTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConditionalStatementCountTxt = new System.Windows.Forms.TextBox();
            this.ConditionalCountLbl = new System.Windows.Forms.Label();
            this.StatementCountTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EvaluateMyersBtn = new System.Windows.Forms.Button();
            this.MyersMetricTxt = new System.Windows.Forms.TextBox();
            this.CyclomaticComplexityTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LoadSourceBtn = new System.Windows.Forms.Button();
            this.SourceFileTxt = new System.Windows.Forms.TextBox();
            this.SourceFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.SourceCodeViewTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ConditionalNestingTxt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConditionalNestingTxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.EvaluateJilbBtn);
            this.groupBox1.Controls.Add(this.JilbMetricTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ConditionalStatementCountTxt);
            this.groupBox1.Controls.Add(this.ConditionalCountLbl);
            this.groupBox1.Controls.Add(this.StatementCountTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jilb metric";
            // 
            // EvaluateJilbBtn
            // 
            this.EvaluateJilbBtn.Enabled = false;
            this.EvaluateJilbBtn.Location = new System.Drawing.Point(10, 153);
            this.EvaluateJilbBtn.Name = "EvaluateJilbBtn";
            this.EvaluateJilbBtn.Size = new System.Drawing.Size(75, 23);
            this.EvaluateJilbBtn.TabIndex = 6;
            this.EvaluateJilbBtn.Text = "Evaluate";
            this.EvaluateJilbBtn.UseVisualStyleBackColor = true;
            this.EvaluateJilbBtn.Click += new System.EventHandler(this.EvaluateJilbBtn_Click);
            // 
            // JilbMetricTxt
            // 
            this.JilbMetricTxt.Location = new System.Drawing.Point(165, 118);
            this.JilbMetricTxt.Name = "JilbMetricTxt";
            this.JilbMetricTxt.ReadOnly = true;
            this.JilbMetricTxt.Size = new System.Drawing.Size(56, 20);
            this.JilbMetricTxt.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Metric evaluation:";
            // 
            // ConditionalStatementCountTxt
            // 
            this.ConditionalStatementCountTxt.Location = new System.Drawing.Point(165, 58);
            this.ConditionalStatementCountTxt.Name = "ConditionalStatementCountTxt";
            this.ConditionalStatementCountTxt.ReadOnly = true;
            this.ConditionalStatementCountTxt.Size = new System.Drawing.Size(56, 20);
            this.ConditionalStatementCountTxt.TabIndex = 3;
            // 
            // ConditionalCountLbl
            // 
            this.ConditionalCountLbl.AutoSize = true;
            this.ConditionalCountLbl.Location = new System.Drawing.Point(8, 61);
            this.ConditionalCountLbl.Name = "ConditionalCountLbl";
            this.ConditionalCountLbl.Size = new System.Drawing.Size(141, 13);
            this.ConditionalCountLbl.TabIndex = 2;
            this.ConditionalCountLbl.Text = "Conditional statement count:";
            // 
            // StatementCountTxt
            // 
            this.StatementCountTxt.Location = new System.Drawing.Point(165, 29);
            this.StatementCountTxt.Name = "StatementCountTxt";
            this.StatementCountTxt.ReadOnly = true;
            this.StatementCountTxt.Size = new System.Drawing.Size(56, 20);
            this.StatementCountTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total statement count:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EvaluateMyersBtn);
            this.groupBox2.Controls.Add(this.MyersMetricTxt);
            this.groupBox2.Controls.Add(this.CyclomaticComplexityTxt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Myers metric";
            // 
            // EvaluateMyersBtn
            // 
            this.EvaluateMyersBtn.Enabled = false;
            this.EvaluateMyersBtn.Location = new System.Drawing.Point(12, 85);
            this.EvaluateMyersBtn.Name = "EvaluateMyersBtn";
            this.EvaluateMyersBtn.Size = new System.Drawing.Size(75, 23);
            this.EvaluateMyersBtn.TabIndex = 4;
            this.EvaluateMyersBtn.Text = "Evaluate";
            this.EvaluateMyersBtn.UseVisualStyleBackColor = true;
            this.EvaluateMyersBtn.Click += new System.EventHandler(this.EvaluateMyersBtn_Click);
            // 
            // MyersMetricTxt
            // 
            this.MyersMetricTxt.Location = new System.Drawing.Point(128, 56);
            this.MyersMetricTxt.Name = "MyersMetricTxt";
            this.MyersMetricTxt.ReadOnly = true;
            this.MyersMetricTxt.Size = new System.Drawing.Size(92, 20);
            this.MyersMetricTxt.TabIndex = 3;
            // 
            // CyclomaticComplexityTxt
            // 
            this.CyclomaticComplexityTxt.Location = new System.Drawing.Point(164, 25);
            this.CyclomaticComplexityTxt.Name = "CyclomaticComplexityTxt";
            this.CyclomaticComplexityTxt.ReadOnly = true;
            this.CyclomaticComplexityTxt.Size = new System.Drawing.Size(56, 20);
            this.CyclomaticComplexityTxt.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Metric evaluation:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cyclomatic complexity:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 509);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(262, 422);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 87);
            this.panel2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LoadSourceBtn);
            this.groupBox3.Controls.Add(this.SourceFileTxt);
            this.groupBox3.Location = new System.Drawing.Point(13, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 63);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source code";
            // 
            // LoadSourceBtn
            // 
            this.LoadSourceBtn.Location = new System.Drawing.Point(373, 23);
            this.LoadSourceBtn.Name = "LoadSourceBtn";
            this.LoadSourceBtn.Size = new System.Drawing.Size(50, 23);
            this.LoadSourceBtn.TabIndex = 4;
            this.LoadSourceBtn.Text = "Load";
            this.LoadSourceBtn.UseVisualStyleBackColor = true;
            this.LoadSourceBtn.Click += new System.EventHandler(this.LoadSourceBtn_Click);
            // 
            // SourceFileTxt
            // 
            this.SourceFileTxt.Location = new System.Drawing.Point(18, 25);
            this.SourceFileTxt.Name = "SourceFileTxt";
            this.SourceFileTxt.ReadOnly = true;
            this.SourceFileTxt.Size = new System.Drawing.Size(338, 20);
            this.SourceFileTxt.TabIndex = 3;
            // 
            // SourceCodeViewTxt
            // 
            this.SourceCodeViewTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SourceCodeViewTxt.Location = new System.Drawing.Point(275, 13);
            this.SourceCodeViewTxt.Multiline = true;
            this.SourceCodeViewTxt.Name = "SourceCodeViewTxt";
            this.SourceCodeViewTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SourceCodeViewTxt.Size = new System.Drawing.Size(438, 395);
            this.SourceCodeViewTxt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Conditional nesting depth:";
            // 
            // ConditionalNestingTxt
            // 
            this.ConditionalNestingTxt.Location = new System.Drawing.Point(165, 87);
            this.ConditionalNestingTxt.Name = "ConditionalNestingTxt";
            this.ConditionalNestingTxt.ReadOnly = true;
            this.ConditionalNestingTxt.Size = new System.Drawing.Size(56, 20);
            this.ConditionalNestingTxt.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 509);
            this.Controls.Add(this.SourceCodeViewTxt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Metrics";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ConditionalStatementCountTxt;
        private System.Windows.Forms.Label ConditionalCountLbl;
        private System.Windows.Forms.TextBox StatementCountTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EvaluateJilbBtn;
        private System.Windows.Forms.TextBox JilbMetricTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button EvaluateMyersBtn;
        private System.Windows.Forms.TextBox MyersMetricTxt;
        private System.Windows.Forms.TextBox CyclomaticComplexityTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button LoadSourceBtn;
        private System.Windows.Forms.TextBox SourceFileTxt;
        private System.Windows.Forms.OpenFileDialog SourceFileDlg;
        private System.Windows.Forms.TextBox SourceCodeViewTxt;
        private System.Windows.Forms.TextBox ConditionalNestingTxt;
        private System.Windows.Forms.Label label5;
    }
}

