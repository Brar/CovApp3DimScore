using System.Collections.Generic;

namespace CovApp3DimScore
{
    class Dependency
    {
        public string QuestionId { get; set; }
        public string? AnswerId { get; set; }
        public List<Dependency>? Any { get; set; }
    }
}
