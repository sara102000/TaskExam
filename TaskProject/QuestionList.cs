using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    internal class QuestionList: List<Question>
    {
        string FilePath;
        public QuestionList(string _file) 
        {
           FilePath = $"{_file}.txt"; 
        }
        public new void Add(Question q)
        {
            base.Add(q);
            //open file and log the question
            using (TextWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine($"{q}");
            }
        }
        public void Read()
        {
            using (TextReader reader = new StreamReader(FilePath))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
