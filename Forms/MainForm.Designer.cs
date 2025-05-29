namespace TestingSystem
{
    partial class MainForm
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
            buttonCreateTest = new Button();
            buttonPassTest = new Button();
            SuspendLayout();
            // 
            // buttonCreateTest
            // 
            buttonCreateTest.Location = new Point(12, 47);
            buttonCreateTest.Name = "buttonCreateTest";
            buttonCreateTest.Size = new Size(267, 50);
            buttonCreateTest.TabIndex = 0;
            buttonCreateTest.Text = "Создать тест";
            buttonCreateTest.UseVisualStyleBackColor = true;
            buttonCreateTest.Click += buttonCreateTest_Click;
            // 
            // buttonPassTest
            // 
            buttonPassTest.Location = new Point(12, 126);
            buttonPassTest.Name = "buttonPassTest";
            buttonPassTest.Size = new Size(267, 50);
            buttonPassTest.TabIndex = 1;
            buttonPassTest.Text = "Пройти тест";
            buttonPassTest.UseVisualStyleBackColor = true;
            buttonPassTest.Click += buttonPassTest_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(291, 216);
            Controls.Add(buttonPassTest);
            Controls.Add(buttonCreateTest);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateTest;
        private Button buttonPassTest;
    }
}
