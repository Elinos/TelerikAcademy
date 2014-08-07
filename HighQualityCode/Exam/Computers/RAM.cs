namespace Computers
{
    public class RAM
    {
        private int value;

        internal RAM(int amount)
        {
            this.Amount = amount;
        }

        private int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}