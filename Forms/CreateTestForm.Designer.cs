namespace TestingSystem.Forms
{
    partial class CreateTestForm
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
            splitContainer2 = new SplitContainer();
            listViewTests = new ListView();
            listViewQuestions = new ListView();
            splitContainer3 = new SplitContainer();
            buttonDeleteTest = new Button();
            textBoxTestName = new TextBox();
            labelTestName = new Label();
            buttonSaveTest = new Button();
            label2 = new Label();
            buttonDeleteQuestion = new Button();
            buttonAddQuestion = new Button();
            textBoxAnswer3 = new TextBox();
            radioButton3 = new RadioButton();
            textBoxAnswer2 = new TextBox();
            radioButton2 = new RadioButton();
            textBoxAnswer1 = new TextBox();
            textBoxQuestionName = new TextBox();
            radioButton1 = new RadioButton();
            label1 = new Label();
            comboBoxDifficulty = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer3);
            splitContainer1.Size = new Size(800, 561);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(listViewTests);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(listViewQuestions);
            splitContainer2.Size = new Size(266, 561);
            splitContainer2.SplitterDistance = 135;
            splitContainer2.TabIndex = 0;
            // 
            // listViewTests
            // 
            listViewTests.Dock = DockStyle.Fill;
            listViewTests.Location = new Point(0, 0);
            listViewTests.Name = "listViewTests";
            listViewTests.Size = new Size(135, 561);
            listViewTests.TabIndex = 0;
            listViewTests.UseCompatibleStateImageBehavior = false;
            // 
            // listViewQuestions
            // 
            listViewQuestions.Dock = DockStyle.Fill;
            listViewQuestions.Location = new Point(0, 0);
            listViewQuestions.Name = "listViewQuestions";
            listViewQuestions.Size = new Size(127, 561);
            listViewQuestions.TabIndex = 0;
            listViewQuestions.UseCompatibleStateImageBehavior = false;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(buttonDeleteTest);
            splitContainer3.Panel1.Controls.Add(textBoxTestName);
            splitContainer3.Panel1.Controls.Add(labelTestName);
            splitContainer3.Panel1.Controls.Add(buttonSaveTest);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(label3);
            splitContainer3.Panel2.Controls.Add(comboBoxDifficulty);
            splitContainer3.Panel2.Controls.Add(label2);
            splitContainer3.Panel2.Controls.Add(buttonDeleteQuestion);
            splitContainer3.Panel2.Controls.Add(buttonAddQuestion);
            splitContainer3.Panel2.Controls.Add(textBoxAnswer3);
            splitContainer3.Panel2.Controls.Add(radioButton3);
            splitContainer3.Panel2.Controls.Add(textBoxAnswer2);
            splitContainer3.Panel2.Controls.Add(radioButton2);
            splitContainer3.Panel2.Controls.Add(textBoxAnswer1);
            splitContainer3.Panel2.Controls.Add(textBoxQuestionName);
            splitContainer3.Panel2.Controls.Add(radioButton1);
            splitContainer3.Panel2.Controls.Add(label1);
            splitContainer3.Panel2.Enabled = false;
            splitContainer3.Size = new Size(530, 561);
            splitContainer3.SplitterDistance = 180;
            splitContainer3.TabIndex = 0;
            // 
            // buttonDeleteTest
            // 
            buttonDeleteTest.Location = new Point(11, 100);
            buttonDeleteTest.Margin = new Padding(5);
            buttonDeleteTest.Name = "buttonDeleteTest";
            buttonDeleteTest.RightToLeft = RightToLeft.No;
            buttonDeleteTest.Size = new Size(127, 40);
            buttonDeleteTest.TabIndex = 2;
            buttonDeleteTest.Text = "Удалить тест";
            buttonDeleteTest.UseVisualStyleBackColor = true;
            buttonDeleteTest.Click += buttonDeleteTest_Click;
            // 
            // textBoxTestName
            // 
            textBoxTestName.Location = new Point(195, 27);
            textBoxTestName.Name = "textBoxTestName";
            textBoxTestName.Size = new Size(323, 27);
            textBoxTestName.TabIndex = 1;
            // 
            // labelTestName
            // 
            labelTestName.AutoSize = true;
            labelTestName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTestName.Location = new Point(11, 23);
            labelTestName.Name = "labelTestName";
            labelTestName.Size = new Size(178, 31);
            labelTestName.TabIndex = 0;
            labelTestName.Text = "Название теста:";
            // 
            // buttonSaveTest
            // 
            buttonSaveTest.Location = new Point(391, 100);
            buttonSaveTest.Margin = new Padding(5);
            buttonSaveTest.Name = "buttonSaveTest";
            buttonSaveTest.RightToLeft = RightToLeft.No;
            buttonSaveTest.Size = new Size(127, 40);
            buttonSaveTest.TabIndex = 0;
            buttonSaveTest.Text = "Сохранить тест";
            buttonSaveTest.UseVisualStyleBackColor = true;
            buttonSaveTest.Click += buttonSaveTest_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(11, 64);
            label2.Name = "label2";
            label2.Size = new Size(207, 31);
            label2.TabIndex = 13;
            label2.Text = "Варианты ответов:";
            // 
            // buttonDeleteQuestion
            // 
            buttonDeleteQuestion.Location = new Point(11, 323);
            buttonDeleteQuestion.Margin = new Padding(5);
            buttonDeleteQuestion.Name = "buttonDeleteQuestion";
            buttonDeleteQuestion.RightToLeft = RightToLeft.No;
            buttonDeleteQuestion.Size = new Size(136, 40);
            buttonDeleteQuestion.TabIndex = 12;
            buttonDeleteQuestion.Text = "Удалить вопрос";
            buttonDeleteQuestion.UseVisualStyleBackColor = true;
            buttonDeleteQuestion.Click += buttonDeleteQuestion_Click;
            // 
            // buttonAddQuestion
            // 
            buttonAddQuestion.Location = new Point(376, 323);
            buttonAddQuestion.Margin = new Padding(5);
            buttonAddQuestion.Name = "buttonAddQuestion";
            buttonAddQuestion.RightToLeft = RightToLeft.No;
            buttonAddQuestion.Size = new Size(142, 40);
            buttonAddQuestion.TabIndex = 2;
            buttonAddQuestion.Text = "Добавить вопрос";
            buttonAddQuestion.UseVisualStyleBackColor = true;
            buttonAddQuestion.Click += buttonAddQuestion_Click;
            // 
            // textBoxAnswer3
            // 
            textBoxAnswer3.Location = new Point(34, 199);
            textBoxAnswer3.Name = "textBoxAnswer3";
            textBoxAnswer3.Size = new Size(484, 27);
            textBoxAnswer3.TabIndex = 11;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(11, 204);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(17, 16);
            radioButton3.TabIndex = 10;
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // textBoxAnswer2
            // 
            textBoxAnswer2.Location = new Point(34, 154);
            textBoxAnswer2.Name = "textBoxAnswer2";
            textBoxAnswer2.Size = new Size(484, 27);
            textBoxAnswer2.TabIndex = 9;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(11, 159);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(17, 16);
            radioButton2.TabIndex = 8;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBoxAnswer1
            // 
            textBoxAnswer1.Location = new Point(34, 112);
            textBoxAnswer1.Name = "textBoxAnswer1";
            textBoxAnswer1.Size = new Size(484, 27);
            textBoxAnswer1.TabIndex = 7;
            // 
            // textBoxQuestionName
            // 
            textBoxQuestionName.Location = new Point(113, 16);
            textBoxQuestionName.Name = "textBoxQuestionName";
            textBoxQuestionName.Size = new Size(405, 27);
            textBoxQuestionName.TabIndex = 6;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(11, 117);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(17, 16);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(11, 12);
            label1.Name = "label1";
            label1.Size = new Size(96, 31);
            label1.TabIndex = 2;
            label1.Text = "Вопрос:";
            // 
            // comboBoxDifficulty
            // 
            comboBoxDifficulty.FormattingEnabled = true;
            comboBoxDifficulty.Location = new Point(243, 241);
            comboBoxDifficulty.Name = "comboBoxDifficulty";
            comboBoxDifficulty.Size = new Size(151, 28);
            comboBoxDifficulty.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(11, 235);
            label3.Name = "label3";
            label3.Size = new Size(226, 31);
            label3.TabIndex = 15;
            label3.Text = "Уровень сложности:";
            // 
            // CreateTestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 561);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CreateTestForm";
            Text = "Создание теста";
            Load += CreateTestForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ListView listViewTests;
        private ListView listViewQuestions;
        private SplitContainer splitContainer3;
        private Label labelTestName;
        private Button buttonSaveTest;
        private TextBox textBoxTestName;
        private Label label1;
        private RadioButton radioButton1;
        private Button buttonDeleteQuestion;
        private Button buttonAddQuestion;
        private TextBox textBoxAnswer3;
        private RadioButton radioButton3;
        private TextBox textBoxAnswer2;
        private RadioButton radioButton2;
        private TextBox textBoxAnswer1;
        private TextBox textBoxQuestionName;
        private Label label2;
        private Button buttonDeleteTest;
        private Label label3;
        private ComboBox comboBoxDifficulty;
    }
}