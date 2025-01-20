using Newtonsoft.Json;
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
    public partial class PassTestForm : Form
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tests.json");
        List<Test> tests = new List<Test>();
        private Test currentTest;
        private List<RadioButton> radioButtons = new List<RadioButton>();
        private int questionNumber = 0;

        public PassTestForm()
        {
            InitializeComponent();
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
            //foreach (var rb in radioTextMap.Keys)
            //{
            //    rb.CheckedChanged += RadioButton_CheckedChanged;
            //}
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
                    Console.WriteLine("Settings loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Tests file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading settings: " + ex.Message);
            }
        }

        private void ListViewTests_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                currentTest = tests.FirstOrDefault(test => test.Name == e.Item.Text);
                SetQuestionWithAnswers();
                splitContainer1.Panel2.Enabled = true;
            }
        }

        private void SetQuestionWithAnswers()
        {
            var questions = currentTest.GetQuestions();
            labelQuestion.Text = questions[questionNumber].Name;
            if (questions != null)
            {
                for (int i = 0; i < questions[questionNumber].answers.Count; i++)
                {
                    radioButtons[i].Text = questions[questionNumber].answers[i];
                }
            }
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
            currentTest.SetAnswer(answer, questionNumber);
            var questionsCount = currentTest.GetQuestionsCount();
            var dic = new Dictionary<Score, string>
            {
                {Score.Excellent, "Отлично"},
                {Score.Good, "Хорошо" },
                {Score.Satisfactory, "Удовлетворительно" },
                {Score.Unsatisfactory, "Неудовлетворительно" }

            };
            if (questionNumber >= questionsCount - 1)
            {
                var wrongAnswers = currentTest.GetWrongAnswers();
                var score = currentTest.CalculateScore();
                var resultForm = new ResultsForm(wrongAnswers, dic[score], questionsCount - wrongAnswers.Count);
                resultForm.ShowDialog();
            }
            else
            {                
                questionNumber++;
                SetQuestionWithAnswers();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var questionsCount = currentTest.GetQuestionsCount();
            if(questionNumber <= 0)
            {
                return;
            }
            else
            {
                questionNumber--;
                SetQuestionWithAnswers();
            }
        }
    }
}
