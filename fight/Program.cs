// gör mig kunna använda Regex för att ta reda på att om ett svar har ett nummer i sig
using System.Text.RegularExpressions;

int heroHp;
int villanHp;
int heroDmg;
int villanDmg;
int accuracy;
int randomIndex;
int randomChoice;

string attackChoice;
string heroName;
string villanName;
string keepPlaying = "ja";

string[] villanNames = ["Jax", "Tim", "Bob"];
string[] acceptable = ["a", "b", "1", "2"];

Random generator = new Random();

// checkar att texten man skirver in har siffor i sig, om den har det så säts den på true och om inte så sätts den på false
bool ContainsNumbers(string input)
{
    return Regex.IsMatch(input, @"\d");
}


// ==================== FIGHT START ======================

while (keepPlaying == "ja")
{
    heroHp = 100;
    villanHp = 100;
    randomIndex = generator.Next(villanNames.Length);
    villanName = villanNames[randomIndex];

    Console.Clear();
    Console.WriteLine("Välj namn för din kämpe (3-7 långt utan nummer): ");
    heroName = Console.ReadLine();

    while (heroName.Length < 3 || heroName.Length > 7 || ContainsNumbers(heroName))
    {   
        // om namnet är kortare än 3 ber den dig att försöka igen
        if (heroName.Length < 3)
        {
            Console.WriteLine("Namnet är för kort, försök igen");
            heroName = Console.ReadLine();
        }
        // om namnet är längre än 7 ber den dig att försöka igen
        else if (heroName.Length > 7)
        {
            Console.WriteLine("Namnet är för långt, försök igen");
            heroName = Console.ReadLine();
        }
        // om namnet har nummer i sig så ber den dig att försöka igen
        else if (ContainsNumbers(heroName))
        {
            Console.WriteLine("Namnet har nummer i sig, försök igen");
            heroName = Console.ReadLine();
        }
    }


    // =========================== NEW ROUND =========================

    while (heroHp > 0 && villanHp > 0)
    {
        Console.Clear();
        Console.WriteLine("======== NY RUNDA ========");
        Console.WriteLine($"{heroName}: {heroHp} Hp  {villanName}: {villanHp} Hp\n");

        // låter användaren välja om de vill göra en heavy attack eller light attack
        Console.WriteLine("--- Välj attack typ ---\na) Light Attack: 5-20 Dmg, 90% Accuracy\nb) Heavy Attack: 10-40 Dmg, 40% Accuracy");
        attackChoice = Console.ReadLine();

        // om svaret man sätter inte är a, b, 1 eller 2 så ber den dig att försöka igen
        while (!acceptable.Contains(attackChoice))
        {
            Console.WriteLine("Okänt Svar, försök igen\n");
            attackChoice = Console.ReadLine();
        }


        // ==================== HERO ATTACK =====================

        accuracy = generator.Next(1, 101);

        // om man väljer a eller 1 försöker användaren göra en light attack
        if (attackChoice == "a" || attackChoice == "1")
        {

            if (accuracy > 91)
            {
                Console.WriteLine($"{heroName} missade sin attack");
            }
            else
            {
                heroDmg = generator.Next(5, 21);
                villanHp -= heroDmg;
                villanHp = Math.Max(0, villanHp);
                Console.WriteLine($"{heroName} använder light attack!\n{heroName} gör {heroDmg} skada på {villanName}");
            }
        }
        // om man väljer b eller 2 försöker användaren föra en heavy attack
        else if (attackChoice == "b" || attackChoice == "2")
        {

            if (accuracy > 41)
            {
                Console.WriteLine($"{heroName} missade sin attack");
            }
            else
            {
                heroDmg = generator.Next(15, 41);
                villanHp -= heroDmg;
                villanHp = Math.Max(0, villanHp);
                Console.WriteLine($"{heroName} använder heavy attack!\n{heroName} gör {heroDmg} skada på {villanName}");
            }
        }


        //  ==================== VILLAN ATTACK ========================

        // ger villan en random attack typ
        randomChoice = generator.Next(2);
        accuracy = generator.Next(1, 101);

        if (randomChoice == 0) {

            if (accuracy > 91)
            {
                Console.WriteLine($"{heroName} missade sin attack");
            }
            else
            {
                villanDmg = generator.Next(5, 21);
                heroHp -= villanDmg;
                heroHp = Math.Max(0, heroHp);
                Console.WriteLine($"{villanName} använder light attack!\n{villanName} gör {villanDmg} skada på {heroName}");
            }
        }
        else if (randomChoice == 1)
        {

            if (accuracy > 41)
            {
                Console.WriteLine($"{villanName} missade sin attack");
            }
            else
            {
                villanDmg = generator.Next(15, 41);
                heroHp -= villanDmg;
                heroHp = Math.Max(0, heroHp);
                Console.WriteLine($"{villanName} använder heavy attack!\n{villanName} gör {villanDmg} skada på {heroName}");
            }
            
        }


        // ============== ROUND END =====================

        // för att fortsätta fighten klicka på vilken knapp som man vill
        Console.WriteLine("Tryck på valfri knapp för att fortsätta");
        Console.ReadKey();
    }


    // ======================== FIGHT END ========================

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

    // om man svarar ja så börjar koden om igen från rad 29
    Console.WriteLine("Om du vill starta om spelet skriv: ja. Lämna det tomt om inte");
    keepPlaying = Console.ReadLine();

}