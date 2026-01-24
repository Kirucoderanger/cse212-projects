/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
            if (players.ContainsKey(playerId)) {
                players[playerId] += points;
            } else {
                players[playerId] = points;
            }
        }

        var sortedPlayers = players.OrderByDescending(p => p.Value).Take(10);
        var playerArray = sortedPlayers.ToArray();
        foreach (var player in sortedPlayers) {
            //convert to array and print
            playerArray = sortedPlayers.ToArray();


            //
            Console.WriteLine($"{player.Key}: {player.Value}");
        }
        //convert to array and get top 10 players
        playerArray = sortedPlayers.ToArray();
        Console.WriteLine();
        Console.WriteLine("Top 10 Players:");
        for (var i = 0; i < 10; i++) {
            Console.WriteLine(playerArray[i]);
        }


        var topPlayers = new string[10];
    }
}