using System.Diagnostics;
using System.IO;
using System.Xml;

namespace TicTacToeLibrary
{
    public class XML
    {
        protected string FilePath { get; set; }

        public XML(string filePath)
        {
            FilePath = filePath;
        }

        public Player[] ReadPlayers()
        {
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader(FilePath);
                int PlayerId = 0, number = 0, x = 0, o = 0, totalGames = 0; string role = "";
                Player[] PlayersData = new Player[2];

                xmlTextReader.Read();
                while (xmlTextReader.Read())
                {
                    xmlTextReader.MoveToElement();
                    switch (xmlTextReader.Name)
                    {
                        case "Player":
                            {
                                if(number != 0 && x != 0 && o != 0 && totalGames != 0 && role != "")
                                {
                                    PlayersData[PlayerId] = new Player(number, role, x, o, totalGames);
                                    PlayerId++;
                                }
                                   
                                break;
                            }
                        case "Number":
                            {
                                number = Int32.Parse(xmlTextReader.ReadString());
                                break;
                            }
                        case "Role":
                            {
                                role = xmlTextReader.ReadString();
                                break;
                            }
                        case "Rating": break;
                        case "X":
                            {
                                x = Int32.Parse(xmlTextReader.ReadString());
                                break;
                            }
                        case "O":
                            {
                                o = Int32.Parse(xmlTextReader.ReadString());
                                break;
                            }
                        case "TotalGames":
                            {
                                totalGames = Int32.Parse(xmlTextReader.ReadString());
                                break;
                            }
                    }
                }

                return PlayersData;
            } 
            catch (Exception ex)
            {
                // Console.WriteLine($"Error! Message: {ex.Message}.\n");
                return new Player[2];
            }
        }

        public void WritePlayers(Player[] Players)
        {
            try
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(FilePath, System.Text.Encoding.UTF8);
                xmlTextWriter.WriteStartDocument(true);

                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.Indentation = 2;

                xmlTextWriter.WriteStartElement("Players");

                foreach (Player player in Players)
                    AddPlayer(player, xmlTextWriter);

                xmlTextWriter.WriteEndElement();

                xmlTextWriter.WriteEndDocument();
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Error! Message: {ex.Message}.\n");
                return;
            }
        }

        public static void AddPlayer(Player player, XmlTextWriter xmlTextWriter)
        {
            xmlTextWriter.WriteStartElement("Player");

            xmlTextWriter.WriteStartElement("Number");
            xmlTextWriter.WriteString(player.GetNumber().ToString());
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("Role");
            xmlTextWriter.WriteString(player.GetRole());
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("Rating");

            xmlTextWriter.WriteStartElement("X");
            xmlTextWriter.WriteString(player.GetRating("X").ToString());
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("O");
            xmlTextWriter.WriteString(player.GetRating("O").ToString());
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("TotalGames");
            xmlTextWriter.WriteString(player.GetRating("TotalGames").ToString());
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement();
        }
    }
}
