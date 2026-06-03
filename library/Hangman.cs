namespace Hangman;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Hangman
{
    // Lift of words in danish
    string[] words =
    {
        "abe","and","bord","bil","bog","båd","barn","blomst","bager","bamse",
        "cykel","cirkel","dør","dansk","dreng","due","dukke","dyr","engel","eventyr",
        "fisk","farve","fugl","film","flaske","frugt","glad","glas","gren","gulv",
        "hat","hund","hus","hest","himmel","hjerte","is","idé","jord","juice",
        "kage","kat","kop","ko","kugle","kasse","lampe","leg","luft","løg",
        "mand","mad","måne","mus","maskine","navn","nat","nøgle","nisse","ost",
        "ord","ovn","papir","pen","pose","pige","plante","radio","regn","rose",
        "rum","sol","seng","sko","skov","stol","stjerne","sø","tand","taske",
        "tog","træ","tøj","uge","ur","vand","vase","vej","vind","vogn",
        "øje","ørn","åben","arbejde","alarm","ananas","arm","baby","bad","balle",
        "bank","bar","behov","ben","bjørn","blad","blok","blyant","bold","bro",
        "bus","butik","bølge","dag","dans","del","dyrke","efter","egen","elv",
        "far","fejl","felt","fest","finger","flag","flod","fly","fod","folk",
        "form","foto","fred","fri","frokost","frost","gave","gade","garn","gavn",
        "gebyr","gips","gitter","glimt","gnist","guld","haj","hale","hal","handel",
        "havn","hegn","hej","held","hest","hjelm","hjul","hjem","høj","høst",
        "ide","ild","ind","info","jagt","jordbær","jul","kold","kamp","kant",
        "kaos","karton","klokke","kniv","korn","kraft","krig","krop","kyst","lage",
        "land","legeme","lys","lyd","lær","løb","løn","mål","magt","mail",
        "mappe","mark","maske","metal","mil","mine","mod","motor","mur","myg",
        "nabo","nark","nav","net","niks","niveau","nord","note","nyhed","nytte"
    };
    // Hangman printing
    string[] hangmanStages = new string[]
    {
    @"
    +---+
    |   |
        |
        |
        |
        |
    =========",

    @"
    +---+
    |   |
    O   |
        |
        |
        |
    =========",

    @"
    +---+
    |   |
    O   |
    |   |
        |
        |
    =========",

    @"
    +---+
    |   |
    O   |
    /|   |
        |
        |
    =========",

    @"
    +---+
    |   |
    O   |
    /|\  |
        |
        |
    =========",

    @"
    +---+
    |   |
    O   |
    /|\  |
    /    |
        |
    =========",

    @"
    +---+
    |   |
    O   |
    /|\  |
    / \  |
        |
    ========="
    };

    public void Start()
    {
        var random = new Random();
        string selectedWord = words[random.Next(words.Length)].ToLower();
        char[] shownWord = new string('_', selectedWord.Length).ToCharArray();

        List<char> wrongGuesses = new List<char>();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Word:");
            Console.WriteLine(string.Join(" ", shownWord));
            Console.WriteLine();

            Console.WriteLine("Wrong guesses:");
            foreach (char letter in wrongGuesses)
            {
                Console.Write($"{char.ToUpper(letter)} ");
            }
            Console.WriteLine();
            Console.WriteLine(hangmanStages[wrongGuesses.Count]);

            Console.Write("Enter a letter: ");
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                Console.WriteLine("Please enter exactly one letter.");
                Console.ReadLine();
                continue;
            }

            char guessedLetter = input[0];

            bool found = false;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == guessedLetter)
                {
                    shownWord[i] = guessedLetter;
                    found = true;
                }
            }

            if (!found)
            {
                if (!wrongGuesses.Contains(guessedLetter))
                {
                    wrongGuesses.Add(guessedLetter);
                }
            }

            if (!shownWord.Contains('_'))
            {
                Console.Clear();
                Console.WriteLine("You won!");
                Console.WriteLine(selectedWord);
                Console.ReadLine();
                break;
            }

            if (wrongGuesses.Count >= hangmanStages.Length - 1)
            {
                Console.Clear();
                Console.WriteLine(hangmanStages[wrongGuesses.Count]);
                Console.WriteLine("You lost!");
                Console.WriteLine($"The word was: {selectedWord}");
                Console.ReadLine();
                break;
            }
        }
    }
}