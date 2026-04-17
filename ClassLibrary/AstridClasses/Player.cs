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
        }

        public Player GetInfo()
        {
            return new Player();
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
    }

    public enum Gender
    {
        Female,
        Male,
        Non_Binary,
    }
}
