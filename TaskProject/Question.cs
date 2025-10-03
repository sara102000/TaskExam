using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    internal abstract class Question 
    {
        public string Body { get; set; }
        public string Headers { get; set; }

        public int Marks{ get; set; }
        public AnswerList Answers { get; set; }


        protected Question(string _body , string _headers , int _marks )
        {
            Body = _body ;
            Headers = _headers ;    
            Marks = _marks ;
            Answers = new AnswerList();
        }
        public abstract void Dispaly();
        public override string ToString()
        {
            return $"{Body}::{Headers}::{Marks}";
        }

    }

    class TrueOrFalse : Question
    {

        public bool Correct { get; set; }

        public TrueOrFalse(string _body, string _headers, int _marks, bool correct) : base(_body, _headers, _marks)
        {
            Correct = correct;
            Answers.Add(new Answers("true", correct));
            Answers.Add(new Answers("false", !correct));
        }
        public override void Dispaly() 
        {
            Console.WriteLine("True or False");
            Console.WriteLine(Body);
            foreach (var answer in Answers) Console.WriteLine(answer.Text);
        }
    }
    class ChooseOne : Question
    {
        public List<string> Options { get; set; }
        public int CorrectAns { get; set; }

        public ChooseOne(string _body, string _headers, int _marks,List<string> options, int correctAns):base( _body , _headers , _marks)
        {
            Options = options ;
            CorrectAns = correctAns;
            int index = 0;
            foreach(var option in Options)
            {
                index++;
                Answers.Add(new Answers(option,index == correctAns));
            }

        }
        public override void Dispaly() 
        {
            Console.WriteLine($"Choose One");
            Console.WriteLine(Body);
            Answers.Display();
        }
    }
    class ChooseAll : Question
    {
        public List<string> Options { get; set; }
        public List<int> CorrectAns { get; set; }
        public ChooseAll(string _body, string _headers, int _marks , List<string> options , List <int> correctAns):base(_body , _headers , _marks)
        {
            Options = options;
            CorrectAns = correctAns;

        }
        public override void Dispaly() 
        {
            Console.WriteLine($"Choose All");
            Console.WriteLine(Body);
            Answers.Display();
        }
    }
}
