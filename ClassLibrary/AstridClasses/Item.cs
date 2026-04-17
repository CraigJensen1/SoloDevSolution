namespace SaveLogic
{
    public class Item
    {
        public string Name { get; set; }
        public int Count { get; set; } = 1;
        public string Description { get; set; }
        public ItemType ItemType { get; set; }

        public Item() { }

        public Item DisplayInfo()
        {
            return new Item();
        }
    }

    public enum ItemType
    {
        Story,
        Tool,
        Armor,
        Junk,
    }
}
