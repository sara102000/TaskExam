using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    enum ExamMode { Queued, Starting, Finished }
    internal abstract class Exam<T> : ICloneable, IComparable<Exam<T>> where T:Question
    {
        public string ExamName { get;}
        public int ExamTime { get;}
        public int NumOfQues { get; }

        public Dictionary<Question ,AnswerList> Questions { get; set; }
        public List<Student> students {  get; set; }=new List<Student>();
        public Subject subject { get; set; }
        
        public ExamMode Mode { get; private set; }

        public event Action <Student> ExamFired;

        public void StartExam()
        {
            Mode = ExamMode.Starting;
            foreach (var student in students)
                ExamFired?.Invoke(student);
        }
        protected Exam(string _ExamName, int _ExamTime, int _NumOfQues,Subject _subject )
        {
            ExamName= _ExamName;
            ExamTime= _ExamTime;
            NumOfQues= _NumOfQues;
            Questions = new Dictionary<Question ,AnswerList>();
            subject = _subject;
        }
        public object Clone()
        {
            var clone = (Exam<T>)this.MemberwiseClone();
            clone.Questions = new Dictionary<Question, AnswerList>(this.Questions);
            return clone;
        }

        public int CompareTo(Exam<T> other)
        {
            return this.NumOfQues.CompareTo(other.NumOfQues); 
        }

        public override string ToString() => $"{ExamName} ({NumOfQues} Questions, {ExamTime}-min)";
        public override bool Equals(object obj)
        {
            if (obj is Exam<T> e) return ExamName == e.ExamName && ExamTime == e.ExamTime;
            return false;
        }
        public override int GetHashCode() => ExamName?.GetHashCode() ?? 0;

        public abstract void showExam();
    }

    class PracticeExam<T> : Exam<T> where T :Question
    {
        public PracticeExam(string _ExamName, int _ExamTime, int _NumOfQues, Subject _subject)
            : base(_ExamName, _ExamTime, _NumOfQues, _subject) { }
        public override void showExam()
        {
            Console.WriteLine("Practice Exam");
            foreach (var item in Questions)
            {
                item.Key.Dispaly();
                item.Value.Display();
            }
                
                    
        }
    }
    class FinalExam<T> : Exam<T> where T : Question
    {
        public FinalExam(string _ExamName, int _ExamTime, int _NumOfQues, Subject _subject)
            : base(_ExamName, _ExamTime, _NumOfQues, _subject) { }
        public override void showExam()
        {
            Console.WriteLine("Final Exam");
            foreach (var item in Questions) 
            {
                item.Key.Dispaly();

            }

        }

    }
    class Subject
    {
        public string SubjName { get; set; }

        public Subject(string _SubjName)
        {
            SubjName = _SubjName;
        }
        public override string ToString()
        {

            return SubjName;
        }
    }
    class Student
    {
        public string Name { get; set; }
        public Student(string _Name)
        {
         Name = _Name;
        }
        public void notify(string examName)
        {
            Console.WriteLine($"{Name} notified- Exam {examName} has started");
        }
    }
}