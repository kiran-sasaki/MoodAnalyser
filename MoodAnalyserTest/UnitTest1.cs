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
    }
}