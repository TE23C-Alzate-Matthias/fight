// gör mig kunna använda Regex för att ta reda på att om ett svar har ett nummer i sig
using System.Text.RegularExpressions;

int heroHp;
int villanHp;
int heroDmg;
int villanDmg;
int accuracy;
int randomIndex;

string choice;
string heroName;
string villanName;
string keepPlaying = "ja";

string[] villanNames = ["Jax", "Tim", "Bob"];
string[] acceptable = ["a", "b", "1", "2"];

Random generator = new Random();

bool ContainsNumbers(string input)
{
    return Regex.IsMatch(input, @"\d");
}


while (keepPlaying == "ja")
{
    heroHp = 100;
    villanHp = 100;
    randomIndex = generator.Next(villanNames.Length);
    villanName = villanNames[randomIndex];

    Console.Clear();
    Console.WriteLine("Välj namn för din kämpe (3-7 långt utan nummer): ");
    heroName = Console.ReadLine();

    while (heroName.Length < 3 || heroName.Length > 7 || ContainsNumbers(heroName)) {
        if (heroName.Length < 3) {
            Console.WriteLine("Namnet är för kort, försök igen");
            heroName = Console.ReadLine();
        }
        else if (heroName.Length > 7) {
            Console.WriteLine("Namnet är för långt, försök igen");
            heroName = Console.ReadLine();
        }
        else if (ContainsNumbers(heroName)) {
            Console.WriteLine("Namnet har nummer i sig, försök igen");
            heroName = Console.ReadLine();
        }
    }
    

    while (heroHp > 0 && villanHp > 0)
    {
        Console.Clear();
        Console.WriteLine("======== NY RUNDA ========");
        Console.WriteLine($"{heroName}: {heroHp} Hp  {villanName}: {villanHp} Hp\n");

        Console.WriteLine("--- Välj attack typ ---\na) Light Attack: 5-20 Dmg\nb) Heavy Attack: 10-40 Dmg");
        choice = Console.ReadLine();

        while (!acceptable.Contains(choice)) {
            Console.WriteLine("Okänt Svar, försök igen\n");
            choice = Console.ReadLine();
        }

        if (choice == "a" || choice == "1") {

            accuracy = generator.Next(1, 101);

            if (accuracy > 90) {
                Console.WriteLine($"{heroName} missade sin attack");
            }
            else {
                heroDmg = generator.Next(5, 21);
                villanHp -= heroDmg;
                villanHp = Math.Max(0, villanHp);
                Console.WriteLine($"{heroName} använder light attack!\n{heroName} gör {heroDmg} skada på {villanName}");
            }
        }
        else if (choice == "b" || choice == "2") {

            accuracy = generator.Next(1, 101);

            if (accuracy > 50) {
                Console.WriteLine($"{heroName} missade sin attack");
            }
            else {
                heroDmg = generator.Next(10, 41);
                villanHp -= heroDmg;
                villanHp = Math.Max(0, villanHp);
                Console.WriteLine($"{heroName} använder heavy attack!\n{heroName} gör {heroDmg} skada på {villanName}");
            }
        }

        villanDmg = generator.Next(1, 20);
        heroHp -= villanDmg;
        heroHp = Math.Max(0, heroHp);
        Console.WriteLine($"{villanName} gör {villanDmg} skada på {heroName}");

        Console.WriteLine("Tryck på valfri knapp för att fortsätta");
        Console.ReadKey();
    }

    Console.WriteLine("\n======== STRIDEN ÄR ÖVER ========");

    if (heroHp == 0 && villanHp == 0)
    {
        Console.WriteLine("BÅDA SVIMMADE, DET ÄR OAVGJORT\n");
    }
    else if (heroHp == 0)
    {
        Console.WriteLine($"{heroName} svimmade, {villanName} vann!\n");
    }
    else
    {
        Console.WriteLine($"{villanName} svimmade, {heroName} vann!\n");
    }

    Console.WriteLine("Om du vill starta om spelet skriv: ja. Lämna det tomt om inte");
    keepPlaying = Console.ReadLine();

}
