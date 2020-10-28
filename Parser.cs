using System;
using System.IO;

namespace Test
{
    public class Parser
    {
        public void Start(string sourceFile)
        {
            //read source text
            string text = null;
            try
            {
                using (StreamReader sr = new StreamReader(sourceFile))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            int flag = 0;
            string buff = "";
            int lengthText = text.Length;
            //results file: 1 row = 1 parameter
            using (StreamWriter sw = new StreamWriter(@"../../../fields.txt", false,
                System.Text.Encoding.Default))
            {
                for (int i = 0; i < lengthText; i++)
                {
                    if (flag % 2 == 1)
                    {
                        buff += text[i];
                    }
                    
                    if (flag < 2)
                    {
                        switch (flag)
                        {
                            case 0 when text[i] == '№':
                                flag = 1;
                                continue;
                            case 1 when text[i] == '\n':
                                flag = 2;
                                sw.WriteLine(buff.Substring(1, buff.Length - 2));
                                buff = null;
                                continue;
                        }
                    }

                    if (1 < flag && flag < 4)
                    {
                        switch (flag)
                        {
                            case 2 when text[i] == '.':
                                flag = 3;
                                continue;
                            case 3 when text[i] == ' ' && text[i + 1] == ' ':
                                flag = 4;
                                sw.WriteLine(buff.Substring(1));
                                buff = null;
                                continue;
                        }
                    }

                    if (3 < flag && flag < 6)
                    {
                        switch (flag)
                        {
                            case 4 when text[i] == '«':
                                buff += text[i];
                                flag = 5;
                                continue;
                            case 5 when text.Substring(i+2, 2) == "р.":
                                flag = 6;
                                sw.WriteLine(buff);
                                buff = null;
                                continue;
                        }
                    }

                    if (5 < flag && flag < 8)
                    {
                        switch (flag)
                        {
                            case 6 when text.Substring(i - 6, 5) == "особі":
                                buff += text[i];
                                flag = 7;
                                continue;
                            case 7 when text[i + 1] == ',':
                                flag = 8;
                                sw.WriteLine(buff);
                                buff = null;
                                continue;
                        }
                    }

                    if (7 < flag && flag < 10)
                    {
                        switch (flag)
                        {
                            case 8 when text.Substring(i-9, 9) == "підставі ":
                                buff += text[i];
                                flag = 9;
                                continue;
                            case 9 when text[i + 1] == ',':
                                flag = 10;
                                sw.WriteLine(buff);
                                buff = null;
                                continue;
                        }
                    }

                    if (9 < flag && flag < 12)
                    {
                        switch (flag)
                        {
                            case 10 when text.Substring(i-7, 2) == "та":
                                flag = 11;
                                continue;
                            case 11 when text.Substring(i + 1, 3) == " (і":
                                flag = 12;
                                sw.WriteLine(buff);
                                buff = null;
                                continue;
                        }
                    }

                    if (11 < flag && flag< 14)
                    {
                        switch (flag)
                        {
                            case 12 when text.Substring(i-6, 6) == "особі ":
                                buff += text[i];
                                flag = 13;
                                continue;
                            case 13 when text[i + 1] == ',':
                                flag = 14;
                                sw.WriteLine(buff);
                                buff = null;
                                continue;
                        }
                    }

                    if (13 < flag && flag < 16)
                    {
                        switch (flag)
                        {
                            case 14 when text.Substring(i-9, 9) == "підставі ":
                                buff += text[i];
                                flag = 15;
                                continue;
                            case 15 when text[i + 1] == ',':
                                flag = 16;
                                sw.WriteLine(buff);
                                buff = null;
                                continue;
                        }
                    }

                    if (15 < flag && flag < 18)
                    {
                        switch (flag)
                        {
                            case 16 when text.Substring(i-7, 7) == "строки ":
                                buff += text[i];
                                flag = 17;
                                continue;
                            case 17 when text.Substring(i+1, 6) == " відпо":
                                flag = 18;
                                sw.WriteLine(buff);
                                buff = null;
                                continue;
                        }
                    }
                    
                    if (17 < flag && flag < 20)
                    {
                        switch (flag)
                        {
                            case 18 when text.Substring(i-3, 3) == "ДК ":
                                buff += text[i];
                                flag = 19;
                                continue;
                            case 19 when text.Substring(i+1, 8) == " (надалі":
                                flag = 20;
                                sw.WriteLine(buff);
                                buff = null;
                                continue;
                        }
                    }

                    if (flag > 19)
                    {
                        switch (flag)
                        {
                            case 20 when text[i] == '№':
                                flag = 21;
                                continue;
                            case 21 when (text[i + 1] == '»' || text[i + 1] == ' ') && text[i - 1] != '№':
                                flag = 20;
                                sw.WriteLine(buff.Substring(1));
                                buff = null;
                                continue;
                        }
                    }
                }
            }
        }
    }
}