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
        public void SavingTest()
        {
            TestSave.SaveProgress(2, true);
            
            Save TestSave2 = new();
            TestSave2.LoadProgress(2, true);

            Assert.Equal("Test", TestSave2.Player.Name);
            Assert.Equal(Gender.Non_Binary, TestSave2.Player.Gender);
            // Assert.Equal(new Player("Test", Gender.Non_Binary), TestSave2.Player);
            Assert.Equal(0, TestSave2.StoryProgress);
            Assert.Equal([], TestSave2.MapSecretsDiscovered);
        }
        [Fact]
        public void Test2()
        {
            Player player = TestPlayer.GetInfo();
            Assert.Equal("Test", player.Name);
            Assert.Equal(Gender.Non_Binary, player.Gender);
        }
        [Fact]
        public void Test3()
        {
            Assert.Equal(TestPlayer.Strength, TestPlayer.Attack());
            const int attackDamage1 = 6;
            int damage1Predicted = attackDamage1 - TestPlayer.Defense;
            int damage1Received = TestPlayer.GetAttacked(attackDamage1);
            Assert.Equal(damage1Predicted, damage1Received);
            Assert.Equal(TestPlayer.MaxHealth - damage1Predicted, TestPlayer.CurrentHealth);
        }
    }
}
