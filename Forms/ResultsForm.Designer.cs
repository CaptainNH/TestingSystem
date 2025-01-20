namespace TestingSystem.Forms
{
    partial class ResultsForm
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
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            labelScore = new Label();
            labelCountWrongAnswers = new Label();
            splitContainer2 = new SplitContainer();
            listViewWrongAnswers = new ListView();
            buttonOk = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(labelScore);
            splitContainer1.Panel1.Controls.Add(labelCountWrongAnswers);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(461, 493);
            splitContainer1.SplitterDistance = 291;
            splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 251);
            label1.Name = "label1";
            label1.Size = new Size(228, 31);
            label1.TabIndex = 2;
            label1.Text = "Обратите внимание:";
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelScore.Location = new Point(12, 79);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(155, 31);
            labelScore.TabIndex = 1;
            labelScore.Text = "Ваша оценка:";
            // 
            // labelCountWrongAnswers
            // 
            labelCountWrongAnswers.AutoSize = true;
            labelCountWrongAnswers.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelCountWrongAnswers.Location = new Point(12, 21);
            labelCountWrongAnswers.Name = "labelCountWrongAnswers";
            labelCountWrongAnswers.Size = new Size(311, 31);
            labelCountWrongAnswers.TabIndex = 0;
            labelCountWrongAnswers.Text = "Кол-во правильных ответов:";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(listViewWrongAnswers);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(buttonOk);
            splitContainer2.Size = new Size(461, 198);
            splitContainer2.SplitterDistance = 156;
            splitContainer2.TabIndex = 0;
            // 
            // listViewWrongAnswers
            // 
            listViewWrongAnswers.Dock = DockStyle.Fill;
            listViewWrongAnswers.Location = new Point(0, 0);
            listViewWrongAnswers.Name = "listViewWrongAnswers";
            listViewWrongAnswers.Size = new Size(461, 156);
            listViewWrongAnswers.TabIndex = 0;
            listViewWrongAnswers.UseCompatibleStateImageBehavior = false;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(355, 3);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(94, 29);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ок";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 493);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ResultsForm";
            Text = "Результаты";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label labelCountWrongAnswers;
        private SplitContainer splitContainer2;
        private Button buttonOk;
        private ListView listViewWrongAnswers;
        private Label label1;
        private Label labelScore;
    }
}