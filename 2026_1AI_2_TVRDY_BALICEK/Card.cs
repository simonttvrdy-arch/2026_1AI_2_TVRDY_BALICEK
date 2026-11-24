using System;
using System.Collections.Generic;
using System.Text;

namespace _2026_1AI_2_TVRDY_BALICEK
{
    

    public class Card
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Points { get; set; }

        public Card(string name, string icon, int points)
        {
            Name = name;
            Icon = icon;
            Points = points;
        }
    }




    public class Common : Card
    {
        public Common() : base("Obyčajná karta", "⚪", 1)
        {

        }
    }




    public class Rare : Card
    {
        public Rare() : base("Rare karta", "🔵", 5)
        {

        }
    }





    public class Legendary : Card
    {
        public Legendary() : base("Legendárna karta", "🟡", 25)
        {

        }
    }


}
