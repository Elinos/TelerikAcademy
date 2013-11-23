using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace BattleSity
{
    public static class Data
    {
        private static int windowWidth = Console.LargestWindowWidth * 2 / 3;
        private static int windowHeight = Console.LargestWindowHeight * 2 / 3;

        private static int elementDimention = 3;

        private static string settingsPath = "settings.txt";

        public static Element[,] GetLevel(uint number)
        {
            Element[,] elements;
            string path = "Levels\\level" + number.ToString() + ".city";
            BinaryFormatter serializer = new BinaryFormatter();

            using (FileStream stream = File.OpenRead(path))
            {
                elements = (Element[,])serializer.Deserialize(stream);
            }

            return elements;
        }

        public static void SaveLevel(Element[,] elements)
        {
            int levelNumber = GetNumberOfLevels() + 1;

            SetNumberOfLevels(levelNumber);

            Directory.CreateDirectory("Levels");
            string path = "Levels\\level" + levelNumber.ToString() + ".city";
            BinaryFormatter serializer = new BinaryFormatter();

            using (FileStream stream = File.OpenWrite(path))
            {
                serializer.Serialize(stream, elements);
            }
        }

        private static List<string> ReadSetings()
        {
            List<string> settings = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(settingsPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string str = reader.ReadLine();
                        settings.Add(str);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                settings.Add("0");
                SaveSettings(settings);
            }
            

            return settings;
        }

        private static void SaveSettings(List<string> setings)
        {
            using (StreamWriter writer = new StreamWriter(settingsPath))
            {
                for (int row = 0; row < setings.Count; row++)
                {
                    writer.WriteLine(setings[row]);
                }
            }
        }

        public static int GetNumberOfLevels()
        {
            List<string> setings = ReadSetings();

            string str = setings[0];

            int levels = int.Parse(str);

            return levels;
        }

        public static void SetNumberOfLevels(int levels)
        {
            List<string> setings = ReadSetings();

            setings[0] = levels.ToString();

            SaveSettings(setings);
        }

        public static int GetWindowWidth()
        {
            return windowWidth;
        }

        public static int GetWindowHeight()
        {
            return windowHeight;
        }

        public static int GetElementDimention()
        {
            return elementDimention;
        }
    }
}
