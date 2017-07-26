using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrajicaApp.Properties;

namespace BrajicaApp
{
    class Sentence
    {
        private List<Letter> list;

        public static Dictionary<string,string> rjecnik;
        private int type;

        private List<List<String>> value=new List<List<string>>();

        public Sentence(List<Letter>list,int type=1)
        {
            this.type = type;
            this.list = new List<Letter>(list);
            foreach(var letter in this.list)
            {
                List<String> possible_answer = new List<string>();
                possible_answer = Sentence.getSolution(letter.getMask(type));
                Console.WriteLine(letter.getMask(type));
                if (possible_answer == null) continue;
                if(possible_answer.Count!=0)
                    value.Add(possible_answer);
                //System.Windows.MessageBox.Show(possible_answer[0]);
            }
        }
        ///<summary>
        ///Get the num-th letter of the sentence.
        ///</summary>
        public Letter getLetter(int num)
        {
            return this.list[num];
        }
        override
        public String ToString()
        {
            string ans = "";
            bool caps = false;
            bool num = false;
            for(int i=0;i<value.Count;++i)
            {
                //System.Windows.Forms.MessageBox.Show(value[i][0]);
                if (value[i][0] == "°") { num = false;continue; }
                if (value[i][0]=="^")
                {
                    caps = true;
                    continue;
                }
                if (value[i][0] == "$") { num = true; continue; }
                int kol = value[i].Count;
                if (kol == 1)
                {
                    num = false;
                    if (caps)
                    {
                        value[i][0] = value[i][0].Substring(0, 1).ToUpper() + value[i][0].Substring(1);
                        caps = false;
                    }
                    ans += value[i][0];
                }
                else
                {
                    if (num)
                    {
                        for (int j = 0; j < value[i].Count(); ++j)
                        {
                            int p;
                            if (int.TryParse(value[i][j], out p) == true)
                            {
                                ans += value[i][j];
                                break;
                            }

                        }
                    }
                    else
                    {
                        for (int j = 0; j < value[i].Count(); ++j)
                        {
                            int p = 0;
                            if (int.TryParse(value[i][j], out p) == false)
                            {
                                if (caps)
                                {
                                    value[i][j] = value[i][j].Substring(0, 1).ToUpper() + value[i][j].Substring(1);
                                    caps = false;
                                }
                                ans += value[i][j];
                                break;
                            }

                        }
                    }
                }
            }
            return ans;
        }
        /// <summary>
        /// C
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool Compare(Sentence A,Sentence B)
        {
            return A.ToString().CompareTo(B.ToString())==0;
            
        }
        private static List<String> getSolution(String mask)
        {
            List<String> answer = new List<string>();
            foreach(var value in rjecnik)
            {
                if (value.Value.CompareTo(mask) == 0)
                    answer.Add(value.Key);
            }
            return answer;
        }
        public int getHowHardIs()
        {
            return 0;
        }
    }
}
