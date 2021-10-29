using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Globals;
using Newtonsoft.Json;

namespace RouletteData
{
    public class Data: IData
    {
        private string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string filePath;
        public Data()
        {
            filePath = documents + "/player.json";
        }
        public string StreamReader()
        {
            //Console.WriteLine("The content of file player.json\n");
            StreamReader sr = null;
            string line = "";
            try
            {
                //string filePath = @"..\..\..\..\RouletteData\player.json";
                if (File.Exists(filePath))
                {
                    sr = new StreamReader(filePath);
                    while (!sr.EndOfStream)
                    {
                        line += sr.ReadLine();
                        //Console.WriteLine(line + "streamreader");
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
        public void JSONSerializerAndWriter(List<Player> players)
        {

            /*Console.WriteLine("Serializing students to JSON Stream in memory... (using Newtonsoft Json.Net) \n");
            Console.Write("Jsonserialer players : ");
            foreach(Player player in players)
            {
                Console.Write(player+", ");
            }*/
            //Console.WriteLine();
            List<Player> prevPlayers;
            prevPlayers = GetPlayers();
            List<Player> allPlayers = prevPlayers;
            Player presentPlayer;
            allPlayers = players.Union(prevPlayers).ToList();
            
            string json = System.Text.Json.JsonSerializer.Serialize(allPlayers);
            json = System.Text.Json.JsonSerializer.Serialize(allPlayers,

                                                             new JsonSerializerOptions
                                                             {
                                                                 WriteIndented = true
                                                             });
            //Console.WriteLine(json + "writer");
            //File.WriteAllText(@"..\..\..\..\RouletteData\player.json", json);
            File.WriteAllText(filePath, json);


        }

        public List<Player> GetPlayers()
        {
            string prevInfo = StreamReader();
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<List<Player>>(prevInfo);
            }
            catch(Exception e)
            {
                return new List<Player>();
            }

        }


    }
}
