using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardsLibrary.Card;

namespace CardsLibrary
{
    public interface IDeckFormat
    {
        public IEnumerable<Suit> Suits { get; }
        public IEnumerable<Rank> Ranks { get; }
        public int JokerCount { get; } 

    }
}
