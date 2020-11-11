using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovApp3DimScore
{
    abstract class Answer
    {
        protected Answer(string questionId)
        {
            QuestionId = questionId;
        }

        public string QuestionId { get; }
    }
}
