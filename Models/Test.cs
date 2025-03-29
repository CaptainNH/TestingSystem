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
            int answeredCount = 0;
            correctAnswersCount = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                // Проверяем, что на вопрос был дан ответ (не пустая строка)
                if (!string.IsNullOrEmpty(answers[i]))
                {
                    answeredCount++;
                    if (questions[i].isAnswerCorrect(answers[i]))
                    {
                        correctAnswersCount++;
                    }
                }
            }

            // Если не было отвеченных вопросов, возвращаем минимальную оценку
            if (answeredCount == 0)
                return Score.Unsatisfactory;

            double correctRatio = (double)correctAnswersCount / answeredCount;

            if (correctRatio >= 0.85)
                return Score.Excellent;
            else if (correctRatio >= 0.6)
                return Score.Good;
            else if (correctRatio >= 0.35)
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