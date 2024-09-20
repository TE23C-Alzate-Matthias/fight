int heroHp;
int villanHp;
int heroDmg;
int villanDmg;

string choice = " ";
string heroName;
string villanName;
string keepPlaying = "ja";

Random generator = new Random();

while (keepPlaying == "ja")
{
    heroHp = 100;
    villanHp = 100;
    villanName = "Villan";

    Console.Clear();
    Console.WriteLine("Välj namn för din kämpe: ");
    heroName = Console.ReadLine();

    while (heroName.Length < 3) {
        Console.WriteLine("Namnet är för kort, försök igen");
        heroName = Console.ReadLine();
    }

    while (heroHp > 0 && villanHp > 0)
    {
        Console.Clear();
        Console.WriteLine("======== NY RUNDA ========");
        Console.WriteLine($"{heroName}: {heroHp} Hp  {villanName}: {villanHp} Hp\n");

        while (choice == " ") {
        Console.WriteLine("Välj attack typ. a) Light Attack  b) Heavy Attack");
        choice = Console.ReadLine();
        
        if (choice == "a") {
            heroDmg = generator.Next(5, 20);
            villanHp -= heroDmg;
            villanHp = Math.Max(0, villanHp);
            Console.WriteLine($"{heroName} gör {heroDmg} skada på {villanName}");
        }
        else if (choice == "b") {
            heroDmg = generator.Next(10, 40);
            villanHp -= heroDmg;
            villanHp = Math.Max(0, villanHp);
            Console.WriteLine($"{heroName} gör {heroDmg} skada på {villanName}");
        }
        else {
            choice = " ";
            Console.WriteLine("Okänt Svar, försök igen\n");
        }
        }

        choice = " ";
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
