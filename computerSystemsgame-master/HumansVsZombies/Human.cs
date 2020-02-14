using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumansVsZombies
{

   public class Human
    {
       
        public int itemsCollected;
        public int humanXLocation { get; set; }
        public int humanYLocation { get; set; }

        public bool alive { get; set; }
        public Human(int _items, int _x, int _y, bool _alive)
        {
            itemsCollected = _items;
            humanXLocation = _x;
            humanYLocation = _y;
            alive = _alive;

        }


    }
}
