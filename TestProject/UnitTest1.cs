using System.Text.Json;
using SaveLogic;
using static ClassLibrary.Astrid;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1() { }
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
            Assert.Equal(0, TestSave.StoryProgress);
            Assert.Equal([], TestSave.MapSecretsDiscovered);

            // Assert.Equal(3, TestSave.Player.MapPosition.Item1);
            // Assert.Equal(7, TestSave.Player.MapPosition.Item2);

            // Assert.Equal(3, TestSave2.Player.MapPosition.Item1);
            // Assert.Equal(7, TestSave2.Player.MapPosition.Item2);

            var o = new JsonSerializerOptions { IncludeFields = true };
            (int, int) numbers = (4, 5);
            string json = JsonSerializer.Serialize(numbers, o);
            numbers = JsonSerializer.Deserialize<(int, int)>(json);
            // Assert.Equal((4, 5), numbers);
            // Assert.Equal((4,5), JsonSerializer.Serialize((4,5), options));
            // Console.WriteLine(JsonSerializer.Serialize((4,5), options));
        }

        [Fact]
        public void Test2()
        {
            Player player = TestPlayer.GetInfo();
            Assert.Equal("Test", player.Name);
            Assert.Equal(Gender.Non_Binary, player.Gender);
            // Assert.Equal(3, player.MapPosition.Item1);
            // Assert.Equal(7, player.MapPosition.Item2);
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

        [Fact]
        public void MapTests()
        {
            var mapLines = File.ReadAllLines("./ClassLibrary/AstridClasses/Maps/StartMap.txt");
            Map = new char[mapLines.Length][];
            for (int i = 0; i < mapLines.Length; i++)
            {
                Map[i] = mapLines[i].ToCharArray();
            }
            string expectedMapRow = "█......☐....................   ..............|";
            Assert.Equal(expectedMapRow, mapLines[3]);
            Assert.Equal(expectedMapRow.ToCharArray(), mapLines[3].ToCharArray());
            Assert.Equal(expectedMapRow.ToCharArray(), Map[3]);
            Assert.Equal(expectedMapRow.ToCharArray()[0], Map[3][0]);
            // Assert.Equal(
            //     expectedMapRow.ToCharArray().ToString(),
            //     mapLines[3].ToCharArray().ToString()
            // );
            Assert.Equal(expectedMapRow, Map[3]);
            char[] characters = [',', '.', 'i'];
            Assert.Equal(",.i", characters); // This test passes. How? I thought these were different things.
            Assert.Equal(12, Map.Length);
            Assert.Equal(12, Map.GetLength(0));
            // Assert.Equal(47, Map.GetLength(1));
            Assert.Equal(46, Map[0].Length);
            Assert.Equal(46, Map[1].Length);
            Assert.Equal(46, Map[3].Length);
        }
    }
}
