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

    }
} 