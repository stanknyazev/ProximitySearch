using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psLib
{
    public class SimpleIndexProximitySearch : IProximitySearch
    {
        IList<IndexedWord> indexedwords;
        public int CountInstances(string keyword, string keywordTwo, int proximity)
        {
            int count = 0;
            foreach (IndexedWord w in indexedwords.Where(w=>w.word== keyword)) {
                int ub = w.index + proximity; int lb = w.index - proximity;
                count += indexedwords.Where(ww => ww.word == keywordTwo && ww.index < ub && ww.index > lb).Count();
            }
            return count;
        }
        public void SetSearcheableText(string text)
        {
            int wordIndex = 1;
            indexedwords =
            (from word in text.Split(' ')
            select new IndexedWord { index = wordIndex++, word=word }).ToList();
    
        }
    }
}
