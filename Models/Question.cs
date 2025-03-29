using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TestingSystem.Models
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

    public class Question
    {
        public string Name { get; set; }
        public List<string> answers;
        public string correctAnswer;
        public DifficultyLevel Difficulty { get; set; }

        public Question(string name, List<string> answers, int correctAnswerNumber, DifficultyLevel difficulty = DifficultyLevel.Easy)
        {
            this.Name = name;
            this.answers = answers;
            this.correctAnswer = answers[correctAnswerNumber];
            this.Difficulty = difficulty;
        }

        public void ChangeCorrectAnswer(int correctAnswerNumber)
        {
            this.correctAnswer = answers[correctAnswerNumber];
        }

        public bool isAnswerCorrect(string answer)
        {
            return this.correctAnswer.Equals(answer);
        }

        public List<string> GetAnswers()
        {
            return this.answers;
        }

    }
}
