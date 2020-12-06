using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public Dictionary<string, string[,,]> words = new Dictionary<string, string[,,]>();
    public Dictionary<char, string[,,]> characters = new Dictionary<char, string[,,]>();

    public Data() {
        LoadChar();
        LoadWords();
    }

    public void LoadWords()
    {
        words.Add("ተማሪ", new string[,,] { { { "GHLLL", "A", "08" }, { "A", null, null }, { "LQBQQ", "B", "11" } }, { { "AAAAA", "A", "09" }, { "A", null, null }, { "CCCCC", "A", "09" } } });
        words.Add("ነች",   new string[,,] { { { "ABBBB", "I", "00" }, { "A", null, null }, { "CIAAA", "J", "14" } }, { { "AAAAA", "I", "00" }, { "A", null, null }, { "CIAAA", "K", "20" } } });
    }

    public void LoadChar()
    {
        characters.Add('ሀ', new string[,,] { { { "RBBBB", "H", "10" }, { "F", null, null }, { "RBBBB", "H", "08" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        //characters.Add('ሁ', new string[,,] { { { "BKBBB", "F", "10" }, { "B", null, null }, { "BKBBB", "F", "20" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        // characters.Add('ሀ', new string[,,] { { { "RBBBB", "I", "10" }, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሁ', new string[,,] { { { "RBBBB", "H", "14" }, { "B", null, null }, { "RBBBB", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሂ', new string[,,] { { { "RBBBB", "H", "02"}, { "A", null, null }, { "RBBBB", "H", "14" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሃ', new string[,,] { { { "RBBBB", "H", "10"}, { "A", null, null }, { "RBBBB", "H", "08" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሄ', new string[,,] { { { "RBBBB", "H", "02"}, { "C", null, null }, { "RBBBB", "H", "14" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ህ', new string[,,] { { { "RBBBB", "H", "10" }, { "F", null, null }, { "RBBBB", "H", "08" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሆ', new string[,,] { { { "RBBBB", "H", "08"}, { "G", null, null }, { "RBBBB", "B", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ለ', new string[,,] { { { "GQIBA", "H", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሉ', new string[,,] { { { "GQIBA", "H", "06"}, { "B", null, null }, { "GQIBA", "H", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሊ', new string[,,] { { { "GQIBA", "H", "06"}, { "A", null, null }, { "GQIBA", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ላ', new string[,,] { { { "GQIBA", "H", "06"}, { "A", null, null }, { "GQIBA", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሌ', new string[,,] { { { "GQIBA", "H", "06"}, { "C", null, null }, { "GQIBA", "H", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ል', new string[,,] { { { "GQIBA", "H", "06"}, { "F", null, null }, { "GQIBA", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሎ', new string[,,] { { { "GQIBA", "H", "06"}, { "G", null, null }, { "GQIBA", "B", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ሐ', new string[,,] { { { "LQBQQ", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሑ', new string[,,] { { { "LQBQQ", "E", "06"}, { "B", null, null }, { "LQBQQ", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሒ', new string[,,] { { { "LQBQQ", "E", "06"}, { "A", null, null }, { "LQBQQ", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሓ', new string[,,] { { { "LQBQQ", "E", "06"}, { "A", null, null }, { "LQBQQ", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሔ', new string[,,] { { { "LQBQQ", "E", "06"}, { "C", null, null }, { "LQBQQ", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሕ', new string[,,] { { { "LQBQQ", "E", "06"}, { "F", null, null }, { "LQBQQ", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሖ', new string[,,] { { { "LQBQQ", "E", "06"}, { "G", null, null }, { "LQBQQ", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('መ', new string[,,] { { { "LCCDD", "D", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሙ', new string[,,] { { { "LCCDD", "D", "06"}, { "B", null, null }, { "LCCDD", "D", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሚ', new string[,,] { { { "LCCDD", "D", "06"}, { "A", null, null }, { "LCCDD", "D", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ማ', new string[,,] { { { "LCCDD", "D", "06"}, { "A", null, null }, { "LCCDD", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሜ', new string[,,] { { { "LCCDD", "D", "06"}, { "C", null, null }, { "LCCDD", "D", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ም', new string[,,] { { { "LCCDD", "D", "06"}, { "F", null, null }, { "LCCDD", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሞ', new string[,,] { { { "LCCDD", "D", "06"}, { "G", null, null }, { "LCCDD", "G", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ሠ', new string[,,] { { { "GJAAA", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሡ', new string[,,] { { { "GJAAA", "E", "06"}, { "B", null, null }, { "GJAAA", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሢ', new string[,,] { { { "GJAAA", "E", "06"}, { "A", null, null }, { "GJAAA", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሣ', new string[,,] { { { "GJAAA", "E", "06"}, { "A", null, null }, { "GJAAA", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሤ', new string[,,] { { { "GJAAA", "E", "06"}, { "C", null, null }, { "GJAAA", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሥ', new string[,,] { { { "GJAAA", "E", "06"}, { "F", null, null }, { "GJAAA", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሦ', new string[,,] { { { "GJAAA", "E", "06"}, { "G", null, null }, { "GJAAA", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ረ', new string[,,] { { { "NBBFF", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሩ', new string[,,] { { { "NBBFF", "E", "06"}, { "B", null, null }, { "NBBFF", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሪ', new string[,,] { { { "NBBFF", "E", "06"}, { "A", null, null }, { "NBBFF", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ራ', new string[,,] { { { "NBBFF", "E", "06"}, { "A", null, null }, { "NBBFF", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሬ', new string[,,] { { { "NBBFF", "E", "06"}, { "C", null, null }, { "NBBFF", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ር', new string[,,] { { { "NBBFF", "E", "06"}, { "F", null, null }, { "NBBFF", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሮ', new string[,,] { { { "NBBFF", "E", "06"}, { "G", null, null }, { "NBBFF", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ሰ', new string[,,] { { { "LBBBG", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሱ', new string[,,] { { { "LBBBG", "E", "06"}, { "B", null, null }, { "LBBBG", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሲ', new string[,,] { { { "LBBBG", "E", "06"}, { "A", null, null }, { "LBBBG", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሳ', new string[,,] { { { "LBBBG", "E", "06"}, { "A", null, null }, { "LBBBG", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሴ', new string[,,] { { { "LBBBG", "E", "06"}, { "C", null, null }, { "LBBBG", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ስ', new string[,,] { { { "LBBBG", "E", "06"}, { "F", null, null }, { "LBBBG", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሶ', new string[,,] { { { "LBBBG", "E", "06"}, { "G", null, null }, { "LBBBG", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ሸ', new string[,,] { { { "BBBBB", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሹ', new string[,,] { { { "BBBBB", "E", "06"}, { "B", null, null }, { "BBBBB", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሺ', new string[,,] { { { "BBBBB", "E", "06"}, { "A", null, null }, { "BBBBB", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሻ', new string[,,] { { { "BBBBB", "E", "06"}, { "A", null, null }, { "BBBBB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሼ', new string[,,] { { { "BBBBB", "E", "06"}, { "C", null, null }, { "BBBBB", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሽ', new string[,,] { { { "BBBBB", "E", "06"}, { "F", null, null }, { "BBBBB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ሾ', new string[,,] { { { "BBBBB", "E", "06"}, { "G", null, null }, { "BBBBB", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ቀ', new string[,,] { { { "HBHLL", "H", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቁ', new string[,,] { { { "HBHLL", "H", "06"}, { "B", null, null }, { "HBHLL", "H", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቂ', new string[,,] { { { "HBHLL", "H", "06"}, { "A", null, null }, { "HBHLL", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቃ', new string[,,] { { { "HBHLL", "H", "06"}, { "A", null, null }, { "HBHLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቄ', new string[,,] { { { "HBHLL", "H", "06"}, { "C", null, null }, { "HBHLL", "H", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቅ', new string[,,] { { { "HBHLL", "H", "06"}, { "F", null, null }, { "HBHLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቆ', new string[,,] { { { "HBHLL", "H", "06"}, { "G", null, null }, { "HBHLL", "B", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('በ', new string[,,] { { { "JBBLL", "H", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቡ', new string[,,] { { { "JBBLL", "H", "06"}, { "B", null, null }, { "JBBLL", "H", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቢ', new string[,,] { { { "JBBLL", "H", "06"}, { "A", null, null }, { "JBBLL", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ባ', new string[,,] { { { "JBBLL", "H", "06"}, { "A", null, null }, { "JBBLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቤ', new string[,,] { { { "JBBLL", "H", "06"}, { "C", null, null }, { "JBBLL", "H", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ብ', new string[,,] { { { "JBBLL", "H", "06"}, { "F", null, null }, { "JBBLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቦ', new string[,,] { { { "JBBLL", "H", "06"}, { "G", null, null }, { "JBBLL", "B", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ተ', new string[,,] { { { "LDLLL", "H", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቱ', new string[,,] { { { "LDLLL", "H", "06"}, { "B", null, null }, { "LDLLL", "H", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቲ', new string[,,] { { { "LDLLL", "H", "06"}, { "A", null, null }, { "LDLLL", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ታ', new string[,,] { { { "LDLLL", "H", "06"}, { "A", null, null }, { "LDLLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቴ', new string[,,] { { { "LDLLL", "H", "06"}, { "C", null, null }, { "LDLLL", "H", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ት', new string[,,] { { { "LDLLL", "H", "06"}, { "F", null, null }, { "LDLLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቶ', new string[,,] { { { "LDLLL", "H", "06"}, { "G", null, null }, { "LDLLL", "B", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ቸ', new string[,,] { { { "LJJLL", "H", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቹ', new string[,,] { { { "LJJLL", "H", "06"}, { "B", null, null }, { "LJJLL", "H", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቺ', new string[,,] { { { "LJJLL", "H", "06"}, { "A", null, null }, { "LJJLL", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቻ', new string[,,] { { { "LJJLL", "H", "06"}, { "A", null, null }, { "LJJLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቼ', new string[,,] { { { "LJJLL", "H", "06"}, { "C", null, null }, { "LJJLL", "H", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ች', new string[,,] { { { "LJJLL", "H", "06"}, { "F", null, null }, { "LJJLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቾ', new string[,,] { { { "LJJLL", "H", "06"}, { "G", null, null }, { "LJJLL", "B", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ኀ', new string[,,] { { { "IBHJJ", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኁ', new string[,,] { { { "IBHJJ", "E", "06"}, { "B", null, null }, { "IBHJJ", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኂ', new string[,,] { { { "IBHJJ", "E", "06"}, { "A", null, null }, { "IBHJJ", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኃ', new string[,,] { { { "IBHJJ", "E", "06"}, { "A", null, null }, { "IBHJJ", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኄ', new string[,,] { { { "IBHJJ", "E", "06"}, { "C", null, null }, { "IBHJJ", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኅ', new string[,,] { { { "IBHJJ", "E", "06"}, { "F", null, null }, { "IBHJJ", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኆ', new string[,,] { { { "IBHJJ", "E", "06"}, { "G", null, null }, { "IBHJJ", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ነ', new string[,,] { { { "BBLLL", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኑ', new string[,,] { { { "BBLLL", "E", "06"}, { "B", null, null }, { "BBLLL", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኒ', new string[,,] { { { "BBLLL", "E", "06"}, { "A", null, null }, { "BBLLL", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ና', new string[,,] { { { "BBLLL", "E", "06"}, { "A", null, null }, { "BBLLL", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኔ', new string[,,] { { { "BBLLL", "E", "06"}, { "C", null, null }, { "BBLLL", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ን', new string[,,] { { { "BBLLL", "E", "06"}, { "F", null, null }, { "BBLLL", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኖ', new string[,,] { { { "BBLLL", "E", "06"}, { "G", null, null }, { "BBLLL", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ኘ', new string[,,] { { { "BBBLL", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኙ', new string[,,] { { { "BBBLL", "E", "06"}, { "B", null, null }, { "BBBLL", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኚ', new string[,,] { { { "BBBLL", "E", "06"}, { "A", null, null }, { "BBBLL", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኛ', new string[,,] { { { "BBBLL", "E", "06"}, { "A", null, null }, { "BBBLL", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኜ', new string[,,] { { { "BBBLL", "E", "06"}, { "C", null, null }, { "BBBLL", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኝ', new string[,,] { { { "BBBLL", "E", "06"}, { "F", null, null }, { "BBBLL", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኞ', new string[,,] { { { "BBBLL", "E", "06"}, { "G", null, null }, { "BBBLL", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('አ', new string[,,] { { { "IFFFF", "H", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኡ', new string[,,] { { { "IFFFF", "H", "06"}, { "B", null, null }, { "IFFFF", "H", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኢ', new string[,,] { { { "IFFFF", "H", "06"}, { "A", null, null }, { "IFFFF", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኣ', new string[,,] { { { "IFFFF", "H", "06"}, { "A", null, null }, { "IFFFF", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኤ', new string[,,] { { { "IFFFF", "H", "06"}, { "C", null, null }, { "IFFFF", "H", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('እ', new string[,,] { { { "IFFFF", "H", "06"}, { "F", null, null }, { "IFFFF", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኦ', new string[,,] { { { "IFFFF", "H", "06"}, { "G", null, null }, { "IFFFF", "B", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ከ', new string[,,] { { { "KBDBB", "D", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኩ', new string[,,] { { { "KBDBB", "D", "06"}, { "B", null, null }, { "KBDBB", "D", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኪ', new string[,,] { { { "KBDBB", "D", "06"}, { "A", null, null }, { "KBDBB", "D", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ካ', new string[,,] { { { "KBDBB", "D", "06"}, { "A", null, null }, { "KBDBB", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኬ', new string[,,] { { { "KBDBB", "D", "06"}, { "C", null, null }, { "KBDBB", "D", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ክ', new string[,,] { { { "KBDBB", "D", "06"}, { "F", null, null }, { "KBDBB", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኮ', new string[,,] { { { "KBDBB", "D", "06"}, { "G", null, null }, { "KBDBB", "G", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ኸ', new string[,,] { { { "KBDDB", "D", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኹ', new string[,,] { { { "KBDDB", "D", "06"}, { "B", null, null }, { "KBDDB", "D", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኺ', new string[,,] { { { "KBDDB", "D", "06"}, { "A", null, null }, { "KBDDB", "D", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኻ', new string[,,] { { { "KBDDB", "D", "06"}, { "A", null, null }, { "KBDDB", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኼ', new string[,,] { { { "KBDDB", "D", "06"}, { "C", null, null }, { "KBDDB", "D", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኽ', new string[,,] { { { "KBDDB", "D", "06"}, { "F", null, null }, { "KBDDB", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ኾ', new string[,,] { { { "KBDDB", "D", "06"}, { "G", null, null }, { "KBDDB", "G", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ወ', new string[,,] { { { "LJILL", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዉ', new string[,,] { { { "LJILL", "E", "06"}, { "B", null, null }, { "LJILL", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዊ', new string[,,] { { { "LJILL", "E", "06"}, { "A", null, null }, { "LJILL", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዋ', new string[,,] { { { "LJILL", "E", "06"}, { "A", null, null }, { "LJILL", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዌ', new string[,,] { { { "LJILL", "E", "06"}, { "C", null, null }, { "LJILL", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ው', new string[,,] { { { "LJILL", "E", "06"}, { "F", null, null }, { "LJILL", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዎ', new string[,,] { { { "LJILL", "E", "06"}, { "G", null, null }, { "LJILL", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ዐ', new string[,,] { { { "GELLL", "H", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዑ', new string[,,] { { { "GELLL", "H", "06"}, { "B", null, null }, { "GELLL", "H", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዒ', new string[,,] { { { "GELLL", "H", "06"}, { "A", null, null }, { "GELLL", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዓ', new string[,,] { { { "GELLL", "H", "06"}, { "A", null, null }, { "GELLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዔ', new string[,,] { { { "GELLL", "H", "06"}, { "C", null, null }, { "GELLL", "H", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዕ', new string[,,] { { { "GELLL", "H", "06"}, { "F", null, null }, { "GELLL", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዖ', new string[,,] { { { "GELLL", "H", "06"}, { "G", null, null }, { "GELLL", "B", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ዘ', new string[,,] { { { "FBFFB", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዙ', new string[,,] { { { "FBFFB", "E", "06"}, { "B", null, null }, { "FBFFB", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዚ', new string[,,] { { { "FBFFB", "E", "06"}, { "A", null, null }, { "FBFFB", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዛ', new string[,,] { { { "FBFFB", "E", "06"}, { "A", null, null }, { "FBFFB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዜ', new string[,,] { { { "FBFFB", "E", "06"}, { "C", null, null }, { "FBFFB", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዝ', new string[,,] { { { "FBFFB", "E", "06"}, { "F", null, null }, { "FBFFB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዞ', new string[,,] { { { "FBFFB", "E", "06"}, { "G", null, null }, { "FBFFB", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ዠ', new string[,,] { { { "FBFBB", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዡ', new string[,,] { { { "FBFBB", "E", "06"}, { "B", null, null }, { "FBFBB", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዢ', new string[,,] { { { "FBFBB", "E", "06"}, { "A", null, null }, { "FBFBB", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዣ', new string[,,] { { { "FBFBB", "E", "06"}, { "A", null, null }, { "FBFBB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዤ', new string[,,] { { { "FBFBB", "E", "06"}, { "C", null, null }, { "FBFBB", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዥ', new string[,,] { { { "FBFBB", "E", "06"}, { "F", null, null }, { "FBFBB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዦ', new string[,,] { { { "FBFBB", "E", "06"}, { "G", null, null }, { "FBFBB", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('የ', new string[,,] { { { "LBDLL", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዩ', new string[,,] { { { "LBDLL", "E", "06"}, { "B", null, null }, { "LBDLL", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዪ', new string[,,] { { { "LBDLL", "E", "06"}, { "A", null, null }, { "LBDLL", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ያ', new string[,,] { { { "LBDLL", "E", "06"}, { "A", null, null }, { "LBDLL", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዬ', new string[,,] { { { "LBDLL", "E", "06"}, { "C", null, null }, { "LBDLL", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ይ', new string[,,] { { { "LBDLL", "E", "06"}, { "F", null, null }, { "LBDLL", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዮ', new string[,,] { { { "LBDLL", "E", "06"}, { "G", null, null }, { "LBDLL", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ደ', new string[,,] { { { "LLLLL", "D", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዱ', new string[,,] { { { "LLLLL", "D", "06"}, { "B", null, null }, { "LLLLL", "D", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዲ', new string[,,] { { { "LLLLL", "D", "06"}, { "A", null, null }, { "LLLLL", "D", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዳ', new string[,,] { { { "LLLLL", "D", "06"}, { "A", null, null }, { "LLLLL", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዴ', new string[,,] { { { "LLLLL", "D", "06"}, { "C", null, null }, { "LLLLL", "D", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ድ', new string[,,] { { { "LLLLL", "D", "06"}, { "F", null, null }, { "LLLLL", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ዶ', new string[,,] { { { "LLLLL", "D", "06"}, { "G", null, null }, { "LLLLL", "G", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ጀ', new string[,,] { { { "CHGGD", "D", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጁ', new string[,,] { { { "CHGGD", "D", "06"}, { "B", null, null }, { "CHGGD", "D", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጂ', new string[,,] { { { "CHGGD", "D", "06"}, { "A", null, null }, { "CHGGD", "D", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጃ', new string[,,] { { { "CHGGD", "D", "06"}, { "A", null, null }, { "CHGGD", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጄ', new string[,,] { { { "CHGGD", "D", "06"}, { "C", null, null }, { "CHGGD", "D", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጅ', new string[,,] { { { "CHGGD", "D", "06"}, { "F", null, null }, { "CHGGD", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጆ', new string[,,] { { { "CHGGD", "D", "06"}, { "G", null, null }, { "CHGGD", "G", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ገ', new string[,,] { { { "IBBBB", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጉ', new string[,,] { { { "IBBBB", "E", "06"}, { "B", null, null }, { "IBBBB", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጊ', new string[,,] { { { "IBBBB", "E", "06"}, { "A", null, null }, { "IBBBB", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጋ', new string[,,] { { { "IBBBB", "E", "06"}, { "A", null, null }, { "IBBBB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጌ', new string[,,] { { { "IBBBB", "E", "06"}, { "C", null, null }, { "IBBBB", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ግ', new string[,,] { { { "IBBBB", "E", "06"}, { "F", null, null }, { "IBBBB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጎ', new string[,,] { { { "IBBBB", "E", "06"}, { "G", null, null }, { "IBBBB", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ጠ', new string[,,] { { { "CDDDI", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጡ', new string[,,] { { { "CDDDI", "E", "06"}, { "B", null, null }, { "CDDDI", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጢ', new string[,,] { { { "CDDDI", "E", "06"}, { "A", null, null }, { "CDDDI", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጣ', new string[,,] { { { "CDDDI", "E", "06"}, { "A", null, null }, { "CDDDI", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጤ', new string[,,] { { { "CDDDI", "E", "06"}, { "C", null, null }, { "CDDDI", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጥ', new string[,,] { { { "CDDDI", "E", "06"}, { "F", null, null }, { "CDDDI", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጦ', new string[,,] { { { "CDDDI", "E", "06"}, { "G", null, null }, { "CDDDI", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ጨ', new string[,,] { { { "EDDDB", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጩ', new string[,,] { { { "EDDDB", "E", "06"}, { "B", null, null }, { "EDDDB", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጪ', new string[,,] { { { "EDDDB", "E", "06"}, { "A", null, null }, { "EDDDB", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጫ', new string[,,] { { { "EDDDB", "E", "06"}, { "A", null, null }, { "EDDDB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጬ', new string[,,] { { { "EDDDB", "E", "06"}, { "C", null, null }, { "EDDDB", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጭ', new string[,,] { { { "EDDDB", "E", "06"}, { "F", null, null }, { "EDDDB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጮ', new string[,,] { { { "EDDDB", "E", "06"}, { "G", null, null }, { "EDDDB", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ጰ', new string[,,] { { { "GJJJB", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጱ', new string[,,] { { { "GJJJB", "E", "06"}, { "B", null, null }, { "GJJJB", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጲ', new string[,,] { { { "GJJJB", "E", "06"}, { "A", null, null }, { "GJJJB", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጳ', new string[,,] { { { "GJJJB", "E", "06"}, { "A", null, null }, { "GJJJB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጴ', new string[,,] { { { "GJJJB", "E", "06"}, { "C", null, null }, { "GJJJB", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጵ', new string[,,] { { { "GJJJB", "E", "06"}, { "F", null, null }, { "GJJJB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ጶ', new string[,,] { { { "GJJJB", "E", "06"}, { "G", null, null }, { "GJJJB", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ጸ', new string[,,] { { { "EBBJJ", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });  
        characters.Add('ጹ', new string[,,] { { { "EBBJJ", "E", "06"}, { "B", null, null }, { "EBBJJ", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });  
        characters.Add('ጺ', new string[,,] { { { "EBBJJ", "E", "06"}, { "A", null, null }, { "EBBJJ", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });  
        characters.Add('ጻ', new string[,,] { { { "EBBJJ", "E", "06"}, { "A", null, null }, { "EBBJJ", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });  
        characters.Add('ጼ', new string[,,] { { { "EBBJJ", "E", "06"}, { "C", null, null }, { "EBBJJ", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });  
        characters.Add('ጽ', new string[,,] { { { "EBBJJ", "E", "06"}, { "F", null, null }, { "EBBJJ", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });  
        characters.Add('ጾ', new string[,,] { { { "EBBJJ", "E", "06"}, { "G", null, null }, { "EBBJJ", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });  

        characters.Add('ፈ', new string[,,] { { { "EBJJJ", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፉ', new string[,,] { { { "EBJJJ", "E", "06"}, { "B", null, null }, { "EBJJJ", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፊ', new string[,,] { { { "EBJJJ", "E", "06"}, { "A", null, null }, { "EBJJJ", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፋ', new string[,,] { { { "EBJJJ", "E", "06"}, { "A", null, null }, { "EBJJJ", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፌ', new string[,,] { { { "EBJJJ", "E", "06"}, { "C", null, null }, { "EBJJJ", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፍ', new string[,,] { { { "EBJJJ", "E", "06"}, { "F", null, null }, { "EBJJJ", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፎ', new string[,,] { { { "EBJJJ", "E", "06"}, { "G", null, null }, { "EBJJJ", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ፀ', new string[,,] { { { "EJJJJ", "H", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፁ', new string[,,] { { { "EJJJJ", "H", "06"}, { "B", null, null }, { "EJJJJ", "H", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፂ', new string[,,] { { { "EJJJJ", "H", "06"}, { "A", null, null }, { "EJJJJ", "H", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፃ', new string[,,] { { { "EJJJJ", "H", "06"}, { "A", null, null }, { "EJJJJ", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፄ', new string[,,] { { { "EJJJJ", "H", "06"}, { "C", null, null }, { "EJJJJ", "H", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፅ', new string[,,] { { { "EJJJJ", "H", "06"}, { "F", null, null }, { "EJJJJ", "H", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፆ', new string[,,] { { { "EJJJJ", "H", "06"}, { "G", null, null }, { "EJJJJ", "B", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ፐ', new string[,,] { { { "JBDLL", "D", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፑ', new string[,,] { { { "JBDLL", "D", "06"}, { "B", null, null }, { "JBDLL", "D", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፒ', new string[,,] { { { "JBDLL", "D", "06"}, { "A", null, null }, { "JBDLL", "D", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፓ', new string[,,] { { { "JBDLL", "D", "06"}, { "A", null, null }, { "JBDLL", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፔ', new string[,,] { { { "JBDLL", "D", "06"}, { "C", null, null }, { "JBDLL", "D", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፕ', new string[,,] { { { "JBDLL", "D", "06"}, { "F", null, null }, { "JBDLL", "D", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ፖ', new string[,,] { { { "JBDLL", "D", "06"}, { "G", null, null }, { "JBDLL", "G", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });

        characters.Add('ቨ', new string[,,] { { { "JBBFB", "E", "06"}, { null, null, null }, { null, null, null } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቩ', new string[,,] { { { "JBBFB", "E", "06"}, { "B", null, null }, { "JBBFB", "E", "10" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቪ', new string[,,] { { { "JBBFB", "E", "06"}, { "A", null, null }, { "JBBFB", "E", "02" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቫ', new string[,,] { { { "JBBFB", "E", "06"}, { "A", null, null }, { "JBBFB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቬ', new string[,,] { { { "JBBFB", "E", "06"}, { "C", null, null }, { "JBBFB", "E", "01" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቭ', new string[,,] { { { "JBBFB", "E", "06"}, { "F", null, null }, { "JBBFB", "E", "05" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
        characters.Add('ቮ', new string[,,] { { { "JBBFB", "E", "06"}, { "G", null, null }, { "JBBFB", "H", "06" } }, { { null, null, null }, { null, null, null }, { null, null, null } } });
    }
}
