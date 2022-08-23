using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyse(string className,string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className,pattern);

            if(result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly(); 
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch(ArgumentNullException)
                {
                    throw new CustomExpection(CustomExpection.ExpectionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new CustomExpection(CustomExpection.ExpectionType.NO_SUCH_METHOD, "Constructor is not Found");
            }
        }

        public static object CreateMoodAnalyserwithParameterConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new CustomExpection(CustomExpection.ExpectionType.NO_SUCH_METHOD, "constructor is not found");
                }
            }
            else
            {
                throw new CustomExpection(CustomExpection.ExpectionType.NO_SUCH_CLASS, "class is not found");
            }
        }
        public static string InvokeAnalyseMood(string message,string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerProblem.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyserwithParameterConstructor("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch(NullReferenceException)
            {
                throw new CustomExpection(CustomExpection.ExpectionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }

    }
}
