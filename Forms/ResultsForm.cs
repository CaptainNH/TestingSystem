using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystem.Models;

namespace TestingSystem.Forms
{
    public partial class ResultsForm : Form
    {

        public ResultsForm(List<Question> wrongAnswers, string score, int rightAnswersCount)
        {
            InitializeComponent();
            labelScore.Text = $"Ваша оценка: {score}";
            labelCountWrongAnswers.Text = $"Кол-во правильных ответов: {rightAnswersCount}";
            listViewWrongAnswers.View = View.Details;
            listViewWrongAnswers.Columns.Add("Вопрос:");
            listViewWrongAnswers.Columns.Add("Правильный ответ:");
            listViewWrongAnswers.Columns[0].Width = listViewWrongAnswers.ClientSize.Width / 2;
            listViewWrongAnswers.Columns[1].Width = listViewWrongAnswers.ClientSize.Width / 2;
            listViewWrongAnswers.Resize += (s, ev) =>
            {
                listViewWrongAnswers.Columns[0].Width = listViewWrongAnswers.ClientSize.Width / 2;
                listViewWrongAnswers.Columns[1].Width = listViewWrongAnswers.ClientSize.Width / 2;
            };
            foreach (Question question in wrongAnswers) 
            {
                listViewWrongAnswers.Items.Add(question.Name).SubItems.Add(question.correctAnswer);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
