using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovApp3DimScore
{
    class CheckAnswer : Answer
    {
        public CheckAnswer(string questionId, IEnumerable<string> answerIds) : base(questionId)
        {
            AnswerIds.AddRange(answerIds);
        }

        public List<string> AnswerIds { get; } = new List<string>();
    }
}
