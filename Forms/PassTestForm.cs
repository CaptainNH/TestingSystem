using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystem.Extensions;
using TestingSystem.Models;

namespace TestingSystem.Forms
{
    public partial class PassTestForm : Form
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tests.json");
        List<Test> tests = new List<Test>();
        private Test currentTest;
        private List<RadioButton> radioButtons = new List<RadioButton>();
        private Question currentDisplayedQuestion;
        private List<Question> answeredQuestions = new List<Question>();

        public PassTestForm()
        {
            InitializeComponent();
            this.listViewTests.BackColor = Color.CornflowerBlue;
        }

        private void PassTestForm_Load(object sender, EventArgs e)
        {
            listViewTests.View = View.Details;
            listViewTests.FullRowSelect = true;
            listViewTests.Columns.Add("Тесты");
            listViewTests.Columns[0].Width = listViewTests.ClientSize.Width;
            listViewTests.Resize += (s, ev) =>
            {
                listViewTests.Columns[0].Width = listViewTests.ClientSize.Width;
            };
            listViewTests.ItemSelectionChanged += ListViewTests_ItemSelectionChanged;
            AddTestsToListView();
            radioButton1.Tag = 0;
            radioButton2.Tag = 1;
            radioButton3.Tag = 2;
            radioButtons.Add(radioButton1);
            radioButtons.Add(radioButton2);
            radioButtons.Add(radioButton3);
        }

        private void AddTestsToListView()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    tests = JsonConvert.DeserializeObject<List<Test>>(json);
                    foreach (var test in tests)
                    {
                        listViewTests.Items.Add(test.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки тестов: " + ex.Message);
            }
        }

        private void ListViewTests_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                currentTest = tests.FirstOrDefault(test => test.Name == e.Item.Text);
                answeredQuestions.Clear();
                SetQuestionWithAnswers();
                splitContainer1.Panel2.Enabled = true;
            }
        }

        private void SetQuestionWithAnswers()
        {
            // Проверяем, все ли легкие вопросы отвечены
            var allEasyQuestions = currentTest.GetQuestionsByDifficulty(DifficultyLevel.Easy);
            var answeredEasy = answeredQuestions.Where(q => q.Difficulty == DifficultyLevel.Easy).Count();

            if (allEasyQuestions.Count > 0 && answeredEasy >= allEasyQuestions.Count)
            {
                FinishTest();
                return;
            }

            currentDisplayedQuestion = currentTest.GetNextQuestion();
            if (currentDisplayedQuestion == null)
            {
                FinishTest();
                return;
            }

            labelQuestion.Text = currentDisplayedQuestion.Name;
            var answers = currentDisplayedQuestion.GetAnswers().Shuffle();
            for (int i = 0; i < answers.Count; i++)
            {
                radioButtons[i].Text = answers[i];
                radioButtons[i].Checked = false;
            }
        }

        private void FinishTest()
        {
            var wrongAnswers = currentTest.GetWrongAnswers();
            var score = currentTest.CalculateScore();
            var dic = new Dictionary<Score, string>
            {
                {Score.Excellent, "Отлично"},
                {Score.Good, "Хорошо"},
                {Score.Satisfactory, "Удовлетворительно"},
                {Score.Unsatisfactory, "Неудовлетворительно"}
            };

            var resultForm = new ResultsForm(
                wrongAnswers,
                dic[score],
                currentTest.GetQuestions().Count(q => !string.IsNullOrEmpty(currentTest.answers[currentTest.GetQuestions().IndexOf(q)]))
            );
            resultForm.ShowDialog();
            this.Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            var answer = "";
            foreach (var rb in radioButtons)
            {
                if (rb.Checked)
                {
                    answer = rb.Text;
                    break;
                }
            }

            if (string.IsNullOrEmpty(answer))
            {
                MessageBox.Show("Пожалуйста, выберите ответ!");
                return;
            }

            bool isCorrect = currentDisplayedQuestion.isAnswerCorrect(answer);
            currentTest.UpdateDifficulty(isCorrect);
            currentTest.SetAnswer(answer, currentTest.GetQuestions().IndexOf(currentDisplayedQuestion));
            answeredQuestions.Add(currentDisplayedQuestion);

            SetQuestionWithAnswers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Можно реализовать навигацию по истории отвеченных вопросов
            // В текущей реализации просто перезагружаем текущий вопрос
            SetQuestionWithAnswers();
        }
    }
}