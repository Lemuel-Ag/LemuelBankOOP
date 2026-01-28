using System.Reflection.Emit;
using Week1_Homework_Project;

class Program
{
    static void Main()
    {
        Player player = new Player("Lemuel", 100, 5);
        Villain villain = new Villain("Thanos", 75, "Giant");

        player.DisplayInfo();
        player.Attack();

        villain.DisplayInfo();
        villain.Taunt();

        Console.ReadLine();
    }
}