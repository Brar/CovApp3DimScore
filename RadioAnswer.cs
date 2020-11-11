using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovApp3DimScore
{
    class RadioAnswer : Answer
    {
        public RadioAnswer(string questionId, string answerId) : base(questionId)
        {
            AnswerId = answerId;
        }

        public string AnswerId { get; }
    }
}
