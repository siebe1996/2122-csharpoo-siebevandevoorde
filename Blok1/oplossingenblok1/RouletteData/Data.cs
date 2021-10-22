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
        public static void JSONSerializerDemo(Player player)
        {
            Console.WriteLine("Serializing students to JSON Stream in memory... (using Newtonsoft Json.Net) \n");
            /*var formatter = new Newtonsoft.Json.JsonSerializer();
            using var stream = new MemoryStream();
            using var sr = new StreamWriter(stream);
            formatter.Serialize(sr, player);
            // JSON serializer does not flush its StreamWriter when finished!
            // so do it explicitly
            sr.Flush();
            stream.Seek(0, SeekOrigin.Begin);*/

            string json = JsonConvert.SerializeObject(player);
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

        public void StreamReaderDemo1()
        {
            Console.WriteLine("The content of file TestFile.txt\n");
            StreamReader sr = null;
            try
            {
                string filePath = @"Resources\TestFile.txt";
                if (File.Exists(filePath))
                {
                    sr = new StreamReader(filePath);
                    string line;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
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
        }
    }
}
