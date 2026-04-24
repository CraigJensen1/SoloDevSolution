namespace SaveLogic
{
    public class Player
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public List<Item> Inventory { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        // public (int, int) MapPosition { get; set; }
        public int MapPositionRow { get; set; }
        public int MapPositionColumn { get; set; }

        public Player() { }

        public Player(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
            Inventory = new();
            MaxHealth = 20;
            CurrentHealth = 20;
            Strength = 5;
            Defense = 1;
            // MapPosition = (3, 7);
            MapPositionRow = 3;
            MapPositionColumn= 7;
        }

        public Player GetInfo()
        {
            return new Player
            {
                Name = Name,
                Gender = Gender,
                Inventory = Inventory,
                MaxHealth = MaxHealth,
                CurrentHealth = CurrentHealth,
                Defense = Defense,
                // MapPosition = MapPosition,
                MapPositionRow = MapPositionRow,
                MapPositionColumn = MapPositionColumn,
                Strength = Strength,
            };
        }

        public int Attack()
        {
            return Strength;
        }

        public int GetAttacked(int damageReceived)
        {
            int damageTaken = Math.Clamp((damageReceived - Defense), 0, int.MaxValue);
            CurrentHealth = Math.Clamp((CurrentHealth - damageTaken), 0, MaxHealth);
            return damageTaken;
        }

        public void MovePlayer(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                {
                    // MapPosition = (MapPosition.Item1 - 1, MapPosition.Item2);
                    MapPositionRow--;
                    break;
                }
                case Direction.Down:
                {
                    // MapPosition = (MapPosition.Item1 + 1, MapPosition.Item2);
                    MapPositionRow++;
                    break;
                }
                case Direction.Right:
                {
                    // MapPosition = (MapPosition.Item1, MapPosition.Item2 + 1);
                    MapPositionColumn++;
                    break;
                }
                case Direction.Left:
                {
                    // MapPosition = (MapPosition.Item1, MapPosition.Item2 - 1);
                    MapPositionColumn--;
                    break;
                }
                default:
                {
                    break;
                }
            }
        }
    }

    public enum Gender
    {
        Female,
        Male,
        Non_Binary,
    }

    public enum Direction
    {
        Up,
        Down,
        Right, // -->
        Left, // <--
    }
}
