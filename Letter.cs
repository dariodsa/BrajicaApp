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

        public String getMask(int type)
        {
            String maska = "";
            if (type == 1)
                for (int i = 0; i < 3; ++i)
                    for (int j = 1; j >=0;--j)
                        maska += this.mask[i, j] == false ? 0 : 1;
            else
                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j <= 1; ++j)
                        maska += this.mask[i, j] == false ? 0 : 1;
            int poz = 0;
            for (int i = 0; i < maska.Length; ++i)
                if (maska[i] == '1') poz = i;
            maska = maska.Substring(0, poz + 1);
            return maska;
        }
    }
}
