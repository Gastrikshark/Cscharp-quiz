using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace quiz_opdracht
{
    internal class Program
    {
        // dit zijn de vraagen van de quiz
        static string[] vragen = { "Did anything important happen on June 4 1989", "is taiwan a country", "do you have rizz", "Walter Walter", "A", "who is the fighting game player that told his haters to kill them selfes", 
            "Whats 9+10", "Omae wa mou shindeiru", "tsugi ni omae wa to iu", "that is the longest fight in anime history", 
            "Can you beat kirby in a fight", "how many episodes of naruto and naruto shippuden are there in total", "are capybaras great animals", "is it gay to smash a homey", "are Ai vtubers good", "will you subcome to the swarm", "milk and cereal or cereal and milk", "are we on the cealing or the floor","was eren in the wrong in attack on titan", "is ohio real"};
        static string[] antwoorden = { "no", "no", "no","put your d away Walter", "Please stop", "lowTierGod", "21", "nani", "toiu",
            "luffy vs Katakuri", "no", "720","yes","you mean like playing smash bros", "yes", "yes","cereal then milk", "were on both on the same time", "no eren is extremly based and did nothing wrong ","yes"};
        static int lives = 3;
        static List<string> allQuestions = new List<string>(vragen);
        static List<string> askedQuestions = new List<string>(allQuestions);
        static int questionsAnsers;
        static int questionsRight;
        static int i = 0;
        static string name = "John Doe";
        static void Main(string[] args)
        {// hier vraagt hij om je naam en pakt hij de list met vragen
            List<string> list = new List<string>(vragen);
            Console.WriteLine("whats your name");
            name = Console.ReadLine();
            if (name == "")
            {
                name = "John Doe";
            }

            stelVraag();

            Console.ReadLine();
    
        }
        static void RandomQuestion()
        {//zorgt er voor dat de vraagen random zijn en dat de vraagen zich niet herallen
            if(questionsAnsers == vragen.Length)
            {// als alle vragen beantwoord zijn eindiged hij het spell
                EndGame();
            }
            else
            {
                Random rnd = new Random();
                i = rnd.Next(0, vragen.Length);
                if (askedQuestions.Contains(vragen[i]))
                {
                    stelVraag();
                }
                else
                {
                    RandomQuestion();

                }
            }
        }
        static void stelVraag()
        {// deze funtie vraagt kijkt of je de antwoord good hebt heb je hem good dan gaat questionsRight omhoge .
         // heb je hem fout dan verlieze je een leven
            Console.WriteLine();
            Console.WriteLine(name + ",");
            Console.WriteLine(vragen[i]);
            //Console.WriteLine("wat is hierop je antwoord");
            string invoer = Console.ReadLine();
            questionsAnsers++;
            if (invoer == antwoorden[i])
            {
                questionsRight++;
                Console.WriteLine("goedzo");
            }
            else
            {
                Console.WriteLine("fout");
                lives -= 1;
                if(lives <= 0)
                {
                    EndGame();
                }
                Console.WriteLine(antwoorden[i]);
                Console.WriteLine(lives);
            }
            askedQuestions.Remove(vragen[i]);
            RandomQuestion();
        }
        static void EndGame()
        {// kijkt hoe veel vraagen je hebt beantwoord en hoeveel levens je hebt en hoeveel je er goed hebt
            Console.WriteLine("You answered " + questionsAnsers + " Questions");
            Console.WriteLine("you get " + questionsRight + " questions right");
            int i = 3 - lives;
            Console.WriteLine("You lost " + i + " Lives");
            startover();
        }

        static void startover()
        {// deze is so dat de quiz op new start inplaats van dat het zich zelf afsluit als de quiz voorbij is
            Console.WriteLine();
            Console.WriteLine("Type o for options");
            Console.WriteLine("Would you like to Play Again?");
            Console.WriteLine("y/n");
            string playerAnswer = Console.ReadLine();
            if (playerAnswer == "Y" || playerAnswer == "y")
            {
                askedQuestions.Clear();
                askedQuestions.AddRange(allQuestions);
                questionsAnsers = 0;
                questionsRight = 0;
                lives = 3;
                RandomQuestion();
            }
            else if (playerAnswer == "N" || playerAnswer == "n")
            {
                Console.WriteLine("Goodbye , " + name);
                Environment.Exit(0);
            }
            else if (playerAnswer == "o" || playerAnswer == "O")
            {
                Options();
            }
            else
            {
                Console.WriteLine("Sorry , I didnt quite get that");
                startover();
            }
        }
        static void Options()
        { // de optie menu voor wanneer je klaar bent met de quiz en dingen wilt beijken
            Console.WriteLine();
            Console.WriteLine("----------");
            Console.WriteLine("Type B to go back");
            Console.WriteLine("Type N to change name");
            Console.WriteLine("Type Q to change the amount of questions you need to answer");
            Console.WriteLine("Type C for the credits");
            string playerAnswer = Console.ReadLine();
            Console.WriteLine("----------");
            if (playerAnswer == "B" || playerAnswer == "b")
            {
                startover();
            }
            else if (playerAnswer == "N" || playerAnswer == "n")
            {
                ChangeName();
            }
            else if (playerAnswer == "C" || playerAnswer == "c")
            {
                Credits();
            }
            else
            {
                Console.WriteLine("Sorry , I didnt quite get that");
                Options();
            }
        }
        static void ChangeName()
        {// geeft de optie om je naam te veranderen als je dat will
            Console.WriteLine();
            Console.WriteLine("----------");
            Console.WriteLine("What would you like to be your new name Player?");
            name = Console.ReadLine();
            Console.WriteLine("----------");
            Options();
        }
        static void Credits()
        {// dit is de credits menu hier credit ik de mensen die heben geholpen met de quiz
            Console.WriteLine("Marlon");
            Console.WriteLine("Rudo");
            Console.ReadLine();
            Options();
        }
    }

}