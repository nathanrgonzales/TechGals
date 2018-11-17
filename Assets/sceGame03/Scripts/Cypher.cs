using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Cypher")]
[System.Serializable]
public class Cypher : ScriptableObject
{
    [SerializeField] Key[] keys;
    [TextArea(10, 14)] [SerializeField] string codeDescription;
    [TextArea(10, 14)] [SerializeField] string codeText;
    [SerializeField] string codeType;
    [SerializeField] Cypher nextCypher;

    public List<int> times = new List<int>();
    static System.Random random = new System.Random();

    public Key[] GetKeys()
    {
        return keys;
    }

    public string GetCodeDescription()
    {
        return codeDescription;
    }

    public string GetCodeType()
    {
        return codeType;
    }

    public Cypher GetNextCypher()
    {
        return nextCypher;
    }

    public string EncodedText()
    {
        return Encode(codeText);
    }

    public string Encode(string text)
    {
        StringBuilder sb = new StringBuilder();
        var encodedText = "";

        switch (codeType)
        {
            case "ASCII":
                sb = new StringBuilder();
                foreach (var c in text)
                {
                    if (Char.IsLetter(c))
                    {
                        sb.Append(Convert.ToInt32(c)).Append(" ");
                    }
                    else
                    {
                        sb.Append(c);
                        if (c == ' ') sb.Append(" ");
                    }
                }

                encodedText = sb.ToString();
                break;
            case "ThirdLetter":
                sb = new StringBuilder();
                foreach (var c in text)
                {
                    if (Char.IsLetter(c))
                    {
                        int num1 = random.Next(0, 26);
                        char let1 = (char)('A' + num1);
                        int num2 = random.Next(0, 26);
                        char let2 = (char)('A' + num2);

                        sb.Append(let1).Append(let2).Append(c.ToString().ToUpper());
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }

                encodedText = sb.ToString();
                break;
            default:
                foreach (var c in text)
                {
                    var key = Array.Find(keys, element => element.key == c.ToString().ToUpper());
                    if (key != null)
                    {
                        sb.Append(key.value);
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                encodedText = sb.ToString();
                break;
        }

        return encodedText;
    }

    public bool CheckAnswer(string answer)
    {
        if (codeText == answer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

[Serializable]
public class Key
{
    public string key;
    public string value;
}
