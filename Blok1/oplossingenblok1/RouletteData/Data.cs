using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Globals;
using Newtonsoft.Json;

namespace RouletteData
{
    public class Data
    {
        public static string StreamReader()
        {
            Console.WriteLine("The content of file TestFile.txt\n");
            StreamReader sr = null;
            string line = "";
            try
            {
                string filePath = @"..\..\..\..\RouletteData\player.json";
                if (File.Exists(filePath))
                {
                    sr = new StreamReader(filePath);
                    while (!sr.EndOfStream)
                    {
                        line += sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be read:{e.Message}");
            }
            finally
            {
                if (sr != null) sr.Dispose();
            }
            Console.WriteLine();
            return line;
        }
        public static void JSONSerializerAndWriter(List<Player> players)
        {
            Console.WriteLine("Serializing students to JSON Stream in memory... (using Newtonsoft Json.Net) \n");

            string prevInfo = StreamReader();
            List<Player> prevPlayers;
            List<Player> allPlayers = players;
            Player presentPlayer;
            if (prevInfo != "")
            {
                prevPlayers = System.Text.Json.JsonSerializer.Deserialize<List<Player>>(prevInfo);
                foreach (Player prevPlayer in prevPlayers)
                {
                    bool playerPresent = false;
                    foreach (Player player in players)
                    {
                        if (prevPlayer.Equals(player))
                        {
                            playerPresent = true;
                        }
                    }
                    if (!playerPresent)
                    {
                        allPlayers.Add(prevPlayer);
                    }
                }
            }


            string json = JsonConvert.SerializeObject(allPlayers);
            Console.WriteLine(json);
            File.WriteAllText(@"..\..\..\..\RouletteData\player.json", json);


            /*
            using var reader = new StreamReader(stream);
            // To Deserialize:
            //var studentenKopie = (List<Student>)formatter.Deserialize(reader, typeof(List<Student>));

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
            Console.WriteLine();*/
            }
            public static void JSONSerializerDemo2(Player player)
        {
            Console.WriteLine("Serializing students to string in memory... (indented, using System.text.Json) \n");

            string json = System.Text.Json.JsonSerializer.Serialize(player);
            json = System.Text.Json.JsonSerializer.Serialize(player,

                                                             new JsonSerializerOptions
                                                             {
                                                                 WriteIndented = true
                                                             });
            Console.WriteLine(json);
            File.WriteAllText(@".\RouletteData\player.json", json);
            /*using FileStream createStream = File.Create(@"D:\path.json");
            await JsonSerializer.SerializeAsync(createStream, _data*/

            /*var studentenKopie = System.Text.Json.JsonSerializer.Deserialize<List<Player>>(json);
            Console.WriteLine();*/
        }

        
    }
}
