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
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using System.Xml.Linq;

namespace TestingSystem.Forms
{
    public partial class CreateTestForm : Form
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tests.json");

        List<Test> tests = new List<Test>();
        private Dictionary<RadioButton, TextBox> radioTextMap;
        private Test currentTest;

        public CreateTestForm()
        {
            InitializeComponent();
            this.FormClosing += CreateTestForm_FormClosing;
        }

        private void CreateTestForm_Load(object sender, EventArgs e)
        {
            listViewTests.View = View.Details;
            listViewTests.FullRowSelect = true;
            listViewTests.Columns.Add("Тесты");
            listViewTests.Columns[0].Width = listViewTests.ClientSize.Width;
            listViewTests.Resize += (s, ev) =>
            {
                listViewTests.Columns[0].Width = listViewTests.ClientSize.Width;
            };

            listViewQuestions.View = View.Details;
            listViewQuestions.FullRowSelect = true;
            listViewQuestions.Columns.Add("Вопросы");
            listViewQuestions.Columns[0].Width = listViewQuestions.ClientSize.Width;
            listViewQuestions.Resize += (s, ev) =>
            {
                listViewQuestions.Columns[0].Width = listViewQuestions.ClientSize.Width;
            };

            listViewTests.ItemSelectionChanged += ListViewTests_ItemSelectionChanged;
            listViewQuestions.ItemSelectionChanged += ListViewQuestions_ItemSelectionChanged;
            radioTextMap = new Dictionary<RadioButton, TextBox>
            {
                { radioButton1, textBoxAnswer1 },
                { radioButton2, textBoxAnswer2 },
                { radioButton3, textBoxAnswer3 }
            };
            radioButton1.Tag = 0;
            radioButton2.Tag = 1;
            radioButton3.Tag = 2;
            foreach (var rb in radioTextMap.Keys)
            {
                rb.CheckedChanged += RadioButton_CheckedChanged;
            }

            AddTestsToListView();

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
                textBoxTestName.Text = currentTest.Name;
                listViewQuestions.Items.Clear();
                var questions = currentTest.GetQuestions();
                if (questions != null)
                {
                    foreach (var question in currentTest.GetQuestions())
                    {
                        listViewQuestions.Items.Add(question.Name);
                    }
                }
                splitContainer3.Panel2.Enabled = true;
            }
        }

        private void ListViewQuestions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var currentQuestionsList = currentTest.GetQuestions();
                int currentQuestionNumber = e.ItemIndex;
                var currentQuestion = currentQuestionsList[currentQuestionNumber];
                textBoxQuestionName.Text = currentQuestion.Name;
                var answersTBList = radioTextMap.Values.ToList();
                for (int i = 0; i < answersTBList.Count; i++)
                {
                    answersTBList[i].Text = currentQuestion.GetAnswers()[i];
                }
                var rbList = radioTextMap.Keys.ToList();
                for (int i = 0;i < rbList.Count; i++)
                {
                    if (currentQuestion.isAnswerCorrect(radioTextMap[rbList[i]].Text))
                    {
                        rbList[i].Checked = true;
                        break;
                    }
                }
            }
        }

        private void buttonSaveTest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTestName.Text))
            {
                var test = new Test(textBoxTestName.Text);
                listViewTests.Items.Add(test.Name);
                tests.Add(test);
                //splitContainer3.Panel2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Необходимо ввести название теста!");
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (currentTest.GetQuestionsCount() > 0)
            {
                if (sender is RadioButton rb && rb.Checked)
                {
                    if(listViewQuestions.SelectedItems != null && listViewQuestions.SelectedItems.Count > 0)
                        currentTest.GetQuestions()[listViewQuestions.SelectedItems[0].Index].ChangeCorrectAnswer((int)rb.Tag);
                }
            }
        }

        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            var questionName = textBoxQuestionName.Text;
            List<string> answers = new List<string>
            {textBoxAnswer1.Text,  textBoxAnswer2.Text, textBoxAnswer3.Text};
            int correctAnswer = 0;
            foreach (var rb in radioTextMap.Keys)
            {
                if (rb.Checked)
                    correctAnswer = (int)rb.Tag;
            }
            currentTest.AddQuestion(questionName, answers, correctAnswer);
            listViewQuestions.Items.Add(questionName);
            textBoxAnswer1.Text = "";
            textBoxAnswer2.Text = "";
            textBoxAnswer3.Text = "";
            textBoxQuestionName.Text = "";
            radioButton1.Checked = true;
        }

        private void buttonDeleteQuestion_Click(object sender, EventArgs e)
        {
            if(currentTest != null && currentTest.GetQuestionsCount() > 0)
            {
                currentTest.RemoveQuestion(listViewQuestions.SelectedItems[0].Index);
                listViewQuestions.Items.Remove(listViewQuestions.SelectedItems[0]);
            }
        }

        private void buttonDeleteTest_Click(object sender, EventArgs e)
        {
            if (currentTest != null)
            {
                var questions = currentTest.GetQuestions();
                listViewQuestions.Items.Clear();
                for (int i = 0; i < questions.Count; i++)
                {
                    currentTest.RemoveQuestion(i);
                }
                tests.Remove(currentTest);
                listViewTests.Items.Remove(listViewTests.SelectedItems[0]);
                splitContainer3.Panel2.Enabled = false;
            }
        }

        private void CreateTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var test in tests)
            {
                test.SaveTest();
            }
            string json = JsonConvert.SerializeObject(tests, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }
    }
}
