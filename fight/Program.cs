// skapar slump generator
// Random generator = new Random();

// nya rad i början i stringen \n räknas som enter
// mycket bättre att använda en Console.WriteLine(" ");
// Console.WriteLine("\n----- ===== NY RUNDA ===== -----");
// Console.WriteLine($"{heroName}: {heroHp}  {villainName}: {villainHp}\n");

// Next ger dig ett nytt slump tal upp till siffran i () - 1, altså i detta exempel 19
// int heroDamage = generator.Next(20);

//  tar två ints och ger oss det högsta av det, kommer aldrig vara under 0
// villainHp = Math.Max(0, villainHp);

int heroHp = 100;
int villanHp = 100;

string heroName = "Hero";
string villanName = "Villan";
string keepPlaying = "ja";

Random generator = new Random();

while (keepPlaying == "ja")
{
    heroHp = 100;
    villanHp = 100;

    while (heroHp > 0 && villanHp > 0)
    {
        Console.Clear();
        Console.WriteLine("======== NY RUNDA ========");
        Console.WriteLine($"{heroName}: {heroHp}  {villanName}: {villanHp}\n");

        int heroDmg = generator.Next(20);
        villanHp -= heroDmg;
        villanHp = Math.Max(0, villanHp);
        Console.WriteLine($"{heroName} gör {heroDmg} skada på {villanName}");

        int villanDmg = generator.Next(20);
        heroHp -= villanDmg;
        heroHp = Math.Max(0, heroHp);
        Console.WriteLine($"{villanName} gör {villanDmg} skada på {heroName}");

        Console.WriteLine("Tryck på valfri knapp för att fortsätta");
        Console.ReadKey();
    }

    Console.WriteLine("\n======== STRIDEN ÄR ÖVER ========");

    if (heroHp == 0 && villanHp == 0)
    {
        Console.WriteLine("BÅDA SVIMMADE, DET ÄR OAVGJORT");
    }
    else if (heroHp == 0)
    {
        Console.WriteLine($"{heroName} svimmade, {villanName} vann!");
    }
    else
    {
        Console.WriteLine($"{villanName} svimmade, {heroName} vann!");
    }

    Console.WriteLine(" ");
    Console.WriteLine("Om du vill starta om spelet skriv: ja. Lämna det tomt om inte");
    keepPlaying = Console.ReadLine();

}
