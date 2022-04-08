using PearlNecklace;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PearlMVC.Models
{
    public class Necklace
    {
        [Key]
        [Column("NecklaceID")]
        public int NecklaceID { get; set; }

        public virtual List<Pearl> _pearls { get; set; } = new List<Pearl>();

        public Pearl this[int idx] => _pearls[idx];

        public int price
        {
            get
            {
                return Price();
            }
            set { }
        }
        public void Sort()
        {
            _pearls.Sort();
        }

        public override string ToString()
        {
            int returnPrice = 0;
            int NumberOfPearls = this._pearls.Count;
            foreach (var item in this._pearls)
            {
                returnPrice += item.Price;
            }
            return $"Necklace {this.NecklaceID}: {NumberOfPearls} Pearls, Price: {returnPrice} SEK";
        }
        public void ShowPearls()
        {
            foreach (var item in this._pearls)
            {
                Console.WriteLine($"{item}");
            }
        }
        public int Price()
        {
            int price = 0;
            if (_pearls == null)
            {
                return 0;
            }
            else
            {
                foreach (var pearl in this._pearls)
                {
                    price += pearl.Price;
                }
            }
            return price;
        }
        public static class Factory
        {
            /// <summary>
            /// Create a randomized necklace with 10 to 51 random pearls.
            /// </summary>
            /// <returns>Necklace object with pearls.</returns>
            public static Necklace CreateRandom()
            {
                var necklace = new Necklace();
                var rndList = new List<Pearl>();
                var rnd = new Random();
                int pearls = rnd.Next(10, 51);
                for (int i = 0; i < pearls; i++)
                {
                    Pearl pearl = Pearl.Factory.CreateRandomPearl();
                    rndList.Add(pearl);
                }
                necklace._pearls = rndList;
                return necklace;
            }

            /// <summary>
            /// Create a randomized necklace with a set amount of pearls.
            /// </summary>
            /// <param name="amount"> Amount of randomized pearls created.</param>
            /// <returns>Necklace object with pearls.</returns>
            public static Necklace CreateRandom(int amount)
            {
                var necklace = new Necklace();
                var rndList = new List<Pearl>();
                for (int i = 0; i < amount; i++)
                {
                    Pearl pearl = Pearl.Factory.CreateRandomPearl();
                    rndList.Add(pearl);
                }
                necklace._pearls = rndList;
                return necklace;
            }
        }
        public Necklace()
        {
        }
    }
}
