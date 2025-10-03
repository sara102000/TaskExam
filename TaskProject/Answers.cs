using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    internal class Answers
    {
        public string Text { get; set; }
        public bool IsCorrect {  get; set; }
        public Answers(string _text , bool _isCorrect) 
        {
            Text = _text;
            IsCorrect = _isCorrect;
        }
        public override string ToString()
        {
            return $"{Text}-{IsCorrect}";
        }
    }
    class AnswerList : List<Answers>
    {
        public void Display()
        {
            for (var i = 0; i < Count; i++)
            {
                var answer = this[i];
                Console.WriteLine($"{i+1}:{answer}");
            }
        }
    }
}



