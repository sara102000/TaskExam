using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    internal class Program
    {
        static void Main(string[] args)

        {
            var mathSubject = new Subject("Math");
            var osSubject = new Subject("OS");



            Exam<TrueOrFalse> exam = null;

            do
            {
                Console.WriteLine("Choose Exam Type: 1 => Practice, 2 => Final");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    exam = new PracticeExam<TrueOrFalse>("Math Practice", 60, 5, mathSubject);
                    break;
                }
                else if (choice == "2")
                {
                    exam = new FinalExam<TrueOrFalse>("Math Final", 60, 5, osSubject);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, choose 1 or 2 only");
                }

            }while(exam == null);
            Student s1 = new Student("Sara");
            Student s2 = new Student("Ahmed");

            exam.students.Add(s1);
            exam.students.Add(s2);

            
            exam.ExamFired += student => student.notify(exam.ExamName);

           
            var q1 = new TrueOrFalse("JS is loosely typed language?", "JS", 2, true);
            var q2 = new TrueOrFalse("Logical error easier than compiler error", "C#", 2, false);

            QuestionList file = new QuestionList("ExamData");

            exam.Questions.Add(q1, q1.Answers);
            exam.Questions.Add(q2, q2.Answers);

            file.Add(q1);
            file.Add(q2);
            //file.Read();

            //exam.showExam();

    
            exam.StartExam();


            foreach (var student in exam.students)
            {
                Console.WriteLine($"\n{student.Name}'s Exam");
                int score = 0;

                foreach (var item in exam.Questions)
                {
                    var q = item.Key;            
                    var answers = item.Value;    

                    q.Dispaly();

                    Console.Write("Answer: ");
                    int ans = int.Parse(Console.ReadLine());

                    bool correct = false;

                    if (ans > 0 && ans < answers.Count)
                    {
                        if (answers[ans-1].IsCorrect)
                        {
                            correct = true;
                        }
                    }

                    if (correct)
                    {
                        Console.WriteLine("Correct \n");
                        score += q.Marks;
                    }
                    else
                    {
                        Console.WriteLine("Wrong \n");
                    }
                }

                Console.WriteLine($"{student.Name}'s Score = {score}\n");
            }

            Console.WriteLine("=== Exam Finished ===");

        }
    }

}
        
    

