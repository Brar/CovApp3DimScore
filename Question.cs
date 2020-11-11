using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovApp3DimScore
{
    class Question
    {
        public string Id { get; set; }
        public QuestionType Type { get; set; }
        [JsonPropertyName("question")]
        public string QuestionText { get; set; }
        public string? Comment { get; set; }
        public List<AnswerOption> Answers { get; set; }
        public Dependency? Depends { get; set; }
    }
}
