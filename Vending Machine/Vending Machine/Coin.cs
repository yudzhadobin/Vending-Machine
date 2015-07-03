namespace Vending_Machine
{
    class Coin
    {
        private int value;

       public int Value
        {
            get
            {
                return this.value;  
            }
        }

        public Coin(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Coin))
            {
                return false;
            }
            else
            {
                Coin another = (Coin)obj;
                return this.value == another.value;
            } 
        }

        public override int GetHashCode()
        {
            return this.value;
        }
    }
}
