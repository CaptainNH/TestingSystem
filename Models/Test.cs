using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Models
{
    internal class Test
    {
        public string Name { get; set; }
        public List<Question> questions { get; set; }
        public List<string> answers { get; set; }
        public int correctAnswersCount = 0;

        public Test(string name)
        {
            this.Name = name;
            questions = new List<Question>();
            answers = new List<string>();
        }

        public int GetQuestionsCount()
        {
            return questions.Count();
        }

        public List<Question> GetQuestions()
        {
            return questions;
        }

        public void AddQuestion(string name, List<string> answers, int correctAnswerNumber)
        {
            var question = new Question(name, answers, correctAnswerNumber);
            questions.Add(question);
        }

        public void RemoveQuestion(int questionNumber) 
        {
            questions.RemoveAt(questionNumber);
        }

        public void SaveTest()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                answers.Add("");
            }
        }

        public void SetAnswer(string answer, int questionNumber)
        {
            answers[questionNumber] = answer;
        }

        public Score CalculateScore()
        {
            for(int i = 0;i < questions.Count;i++)
            {
                if (questions[i].isAnswerCorrect(answers[i]))
                {
                    correctAnswersCount++;
                }
            }
            if (correctAnswersCount / questions.Count >= 0.85)
                return Score.Excellent;
            else if (correctAnswersCount / questions.Count >= 0.6)
                return Score.Good;
            else if (correctAnswersCount / questions.Count >= 0.35)
                return Score.Satisfactory;
            else
                return Score.Unsatisfactory;
        }
    }
}
