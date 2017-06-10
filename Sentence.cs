using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrajicaApp
{
    class Sentence
    {
        private List<Letter> list;

        public Sentence(List<Letter>list)
        {
            this.list = new List<Letter>(list);
        }
        ///<summary>
        ///Get the num-th letter of the sentence.
        ///</summary>
        public Letter getLetter(int num)
        {
            return this.list[num];
        }

        public static List<Boolean> Compare(Sentence A,Sentence B)
        {
            return null;
        }
        public int getHowHardIs()
        {
            return 0;
        }
    }
}
