using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrajicaApp
{
    /*
     * This class will represent one letter in the Braille's alphabet and all of his atributes. 
     */
    class Letter
    {
        private Boolean[,] mask = new Boolean[3, 2];

        public Letter(Boolean[,] _mask)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 2; ++j)
                    mask[i, j] = _mask[i, j];
            }
        }

        public char getChar()
        {
            return 'a';      
        }
    }
}
