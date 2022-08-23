using MoodAnalyzerProblem;

namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        public void GivenSadShouldReturnSAD()
        {
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyser moodAnalyse = new MoodAnalyser(message);

            string mood = moodAnalyse.AnalyseMood();

            Assert.AreEqual(expected, mood);
        }
        [TestMethod]
        [DataRow("I am in Happy mood")]
        [DataRow(null)]
        public void GivenHAPPYMoodShouldReturnHappy(string message)
        {
            string expected = "HAPPY";
            MoodAnalyser moodAnalyse = new MoodAnalyser(message);

            string mood = moodAnalyse.AnalyseMood();

            Assert.AreEqual(expected,mood);
        }
        [TestMethod]
        public void Given_Empty_Mood_Should_throw_CustomExecption_Indicating_EmptyMood()
        {
            try
            {
                string message = "";
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood= moodAnalyse.AnalyseMood();
            }
            catch(CustomExpection e)
            {
                Assert.AreEqual("mood should not be empty",e.Message);
            }
        }
        //3.1
        [TestMethod]
        public void Given_NULL_Empty_Mood_Should_throw_CustomExecption()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch(CustomExpection e)
            {
                Assert.AreEqual("mood should not be null", e.Message);
            }
        }
        //3.2
        [TestMethod]
        public void Given_EmptyMood_Should_Throw_MoodAnalysisException_indicating_Empty_Mood()
        {
            try
            {
                string message = "empty";
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch(CustomExpection e)
            {
                Assert.AreEqual("Mood Should not be empty", e.Message);
            }
        }
        //4.1
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            string className = "MoodAnalyer";
            string constructorName = "AnalyseMood";
            object obj = MoodAnalyserFactory.CreateMoodAnalyse(className, constructorName);
          
        }
        //4.2
        [TestMethod]
        public void Given_ClassName_When_Improper_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string className = "MoodAnalyers";
                string constructorName = "AnalyseMoods";
                object obj = MoodAnalyserFactory.CreateMoodAnalyse(className, constructorName);
            }
            catch(CustomExpection e)
            {
                Assert.AreEqual("Class Not Found",e.Message);
            }
        }

        //5.1
        [TestMethod]
        public void GivenMoodAnalyserClassName_ShouldReturnMoodAnalyserObject_usingParameterizedConructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserwithParameterConstructor("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);
        }
        //6.1
        [TestMethod]
        public void GivenHappyShouldReturnHappy()
        {
            string expected = "Happy";
            string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }
    }
} 