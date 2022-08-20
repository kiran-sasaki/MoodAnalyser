using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class CustomExpection : Exception
    {
        public enum ExpectionType
        {
            NULL_MESSAGE,EMPTY_MESSAGE,
            NO_SUCH_FIELD,NO_SUCH_METHOD,
            NO_SUCH_CLASS,OBJECT_CREATION_ISSUE
        }
        private readonly ExpectionType type;

        public CustomExpection(ExpectionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
}
