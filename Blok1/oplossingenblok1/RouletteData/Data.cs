using System;


namespace RouletteData
{
    public class Data
    {
        public void JSONSerializerDemo2(Player player)
        {
            Console.WriteLine("Serializing students to string in memory... (indented, using System.text.Json) \n");

            string json = System.Text.Json.JsonSerializer.Serialize();
            json = System.Text.Json.JsonSerializer.Serialize(player,

                                                             new JsonSerializerOptions
                                                             {
                                                                 WriteIndented = true
                                                             });
            Console.WriteLine(json);

            var studentenKopie = System.Text.Json.JsonSerializer.Deserialize<List<Student>>(json);
            Console.WriteLine();
        }
    }
}
