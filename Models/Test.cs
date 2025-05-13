// Test.cs
using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Extensions;

namespace TestingSystem.Models
{
    internal class Test
    {
        public string Name { get; set; }
        public List<Question> questions { get; set; }
        public List<string> answers { get; set; }
        public int correctAnswersCount = 0;
        private DifficultyLevel currentDifficulty = DifficultyLevel.Easy;
        private int easyCorrect = 0;
        private int mediumCorrect = 0;
        private Dictionary<DifficultyLevel, double> difficultyWeights = new Dictionary<DifficultyLevel, double>
        {
            { DifficultyLevel.Easy, 1.0 },
            { DifficultyLevel.Medium, 1.5 },
            { DifficultyLevel.Hard, 2.0 }
        };

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

        public List<Question> GetQuestionsByDifficulty(DifficultyLevel difficulty)
        {
            return questions.Where(q => q.Difficulty == difficulty).ToList();
        }

        public void AddQuestion(string name, List<string> answers, int correctAnswerNumber, DifficultyLevel difficulty = DifficultyLevel.Easy)
        {
            var question = new Question(name, answers, correctAnswerNumber, difficulty);
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

        public void UpdateDifficulty(bool isAnswerCorrect)
        {
            if (isAnswerCorrect)
            {
                if (currentDifficulty == DifficultyLevel.Easy)
                {
                    easyCorrect++;
                    if (easyCorrect >= GetQuestionsByDifficulty(DifficultyLevel.Easy).Count * 0.2)
                    {
                        currentDifficulty = DifficultyLevel.Medium;
                        easyCorrect = 0;
                    }
                }
                else if (currentDifficulty == DifficultyLevel.Medium)
                {
                    mediumCorrect++;
                    if (mediumCorrect >= GetQuestionsByDifficulty(DifficultyLevel.Medium).Count * 0.2)
                    {
                        currentDifficulty = DifficultyLevel.Hard;
                        mediumCorrect = 0;
                    }
                }
            }
            else
            {
                if (currentDifficulty == DifficultyLevel.Hard)
                {
                    currentDifficulty = DifficultyLevel.Medium;
                }
                else if (currentDifficulty == DifficultyLevel.Medium)
                {
                    currentDifficulty = DifficultyLevel.Easy;
                }
            }
        }

        public Question GetNextQuestion()
        {
            var availableQuestions = GetQuestionsByDifficulty(currentDifficulty)
                .Where(q => !answers.Contains(q.correctAnswer)).ToList();

            if (availableQuestions.Count == 0)
            {
                // Если вопросы текущей сложности закончились, переходим к следующему уровню
                if (currentDifficulty == DifficultyLevel.Easy)
                    currentDifficulty = DifficultyLevel.Medium;
                else if (currentDifficulty == DifficultyLevel.Medium)
                    currentDifficulty = DifficultyLevel.Hard;

                availableQuestions = GetQuestionsByDifficulty(currentDifficulty)
                    .Where(q => !answers.Contains(q.correctAnswer)).ToList();
            }

            if (availableQuestions.Count == 0) return null;

            //var random = new Random();
            return availableQuestions.Shuffle()[0];
        }

        public Score CalculateScore()
        {
            double totalPossibleScore = 0; // Максимально возможный балл (если все ответы правильные)
            double userScore = 0;         // Набранный балл пользователя
            int answeredCount = 0;

            foreach (var question in questions)
            {
                // Находим коэффициент сложности вопроса
                double weight = difficultyWeights[question.Difficulty];

                // Увеличиваем максимальный балл
                totalPossibleScore += weight;

                // Если ответ дан и он правильный, добавляем балл с учётом веса
                int answerIndex = questions.IndexOf(question);
                if (answerIndex < answers.Count && !string.IsNullOrEmpty(answers[answerIndex]))
                {
                    answeredCount++;
                    if (question.isAnswerCorrect(answers[answerIndex]))
                    {
                        userScore += weight;
                    }
                }
            }

            // Если не было отвеченных вопросов, возвращаем "Неудовлетворительно"
            if (answeredCount == 0)
                return Score.Unsatisfactory;

            // Вычисляем процент правильных ответов с учётом весов
            double scoreRatio = userScore / answeredCount;

            // Определяем оценку
            if (scoreRatio >= 0.85)
                return Score.Excellent;
            else if (scoreRatio >= 0.6)
                return Score.Good;
            else if (scoreRatio >= 0.35)
                return Score.Satisfactory;
            else
                return Score.Unsatisfactory;
        }

        public List<Question> GetWrongAnswers()
        {
            var wrongAnswersList = new List<Question>();
            for (int i = 0; i < questions.Count; i++)
            {
                // Учитываем только отвеченные вопросы
                if (!string.IsNullOrEmpty(answers[i]) && !questions[i].isAnswerCorrect(answers[i]))
                {
                    wrongAnswersList.Add(questions[i]);
                }
            }
            return wrongAnswersList;
        }
    }
}