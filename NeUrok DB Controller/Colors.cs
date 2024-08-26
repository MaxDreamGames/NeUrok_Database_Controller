using System.Collections.Generic;
using System.Diagnostics;

namespace NeUrok_DB_Controller
{
    internal class Colors
    {
        public enum Color
        {
            NONE, GREEN, RED, ORANGE, BLUE, PINK, LIGHTBLUE, WHITE
        }

        public static Dictionary<string, System.Drawing.Color> colorMatching = new Dictionary<string, System.Drawing.Color>() { };

        public static Color currentColor = Color.NONE;
        public static Dictionary<string, Color> colors = new Dictionary<string, Color>();

        public static void SetColors()
        {
            currentColor = Color.NONE;
            colorMatching.Clear();
            colorMatching.Add("GREEN", System.Drawing.Color.Green);
            colorMatching.Add("RED", System.Drawing.Color.Red);
            colorMatching.Add("ORANGE", System.Drawing.Color.Orange);
            colorMatching.Add("BLUE", System.Drawing.Color.Blue);
            colorMatching.Add("PINK", System.Drawing.Color.Pink);
            colorMatching.Add("LIGHTBLUE", System.Drawing.Color.LightBlue);
            colorMatching.Add("WHITE", System.Drawing.Color.White);
        }

        public static void Insert(string id, Color color)
        {
            colors[id] = color;
        }

        public void Remove(string id) { }

        public static void Print()
        {
            foreach (var item in colors)
            {
                Debug.Print(item.Key + ": " + item.Value);
            }
        }
    }
}
