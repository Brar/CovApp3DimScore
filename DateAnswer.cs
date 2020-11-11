using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovApp3DimScore
{
    class DateAnswer : Answer
    {
        public DateAnswer(string questionId, DateTime value) : base(questionId)
        {
            Value = value;
        }

        public DateTime Value { get; }
    }
}
