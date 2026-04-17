using SaveLogic;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }

    public class UnitTestAstrid
    {
        public static Player TestPlayer = new Player("Test", Gender.Non_Binary);
        public static Save TestSave = new Save(TestPlayer);
        [Fact]
        public void Test1()
        {
            TestSave.SaveProgress(2, true);
        }
    }
}
