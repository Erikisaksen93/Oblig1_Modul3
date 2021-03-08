using System;
using System.Collections.Generic;
using System.Text;
using Oblig1;

namespace Oblig1
{
    public class FamilyApp
    {

        public List<Person> People;
        public string WelcomeMessage = "Kongehuset Norge";
        public string CommandPrompt = "Skriv en kommando(hjelp, liste, vis <tall> \n";

        public FamilyApp(params Person[] family)
        {
            People = new List<Person>(family);
        }

        public string HandleCommand(string input)
        {

            if (input == "hjelp")
            {
                return HelpText();

            }
            else if (input == "liste")
            {
                return ShowList(People);
            }
            else if (input.Contains("vis ")) 
            {
                return GetPersonById(People, input);

            }
            else
            {
                return "Du må skrive 'hjelp', 'liste', eller 'vis <id>' ";
            }
        }

        private static string GetPersonById(List <Person> People, string input)
        {
            int ID = Int32.Parse(input.Substring(input.IndexOf(" ") + 1));
            string text = "";

            List<string> Children = new List<string>();

            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].Id == ID)
                {
                    text += People[i].GetDescription() + "\n";

                }

                if (People[i].Mother != null)
                {
                    if (People[i].Mother.Id == ID)
                    {
                        Children.Add(People[i].FirstName + " (Id=" + People[i].Id + ") Født: " + People[i].BirthYear);
                    }
                }

                if (People[i].Father != null)
                {
                    if (People[i].Father.Id == ID)
                    {
                        Children.Add(People[i].FirstName + " (Id=" + People[i].Id + ") Født: " + People[i].BirthYear);
                    }
                }
            }

           if (Children.Count == 0)
            {
                return text;
            } 
            
            else
            {

                text += " " + " Barn:\n";
                for (int j = 0; j < Children.Count; j++)
                {
                    if (j == Children.Count - 1)
                    {
                        text += "    " + Children[j] + "\n";
                    }
                    else
                    {
                        text += "    " + Children[j] + "\n";
                    }
                }
            }

            return text;
        }



        public static string ShowList(List <Person> People)
        {
            var listText = "";

            for (int i = 0; i < People.Count; i++)
            {
                listText += People[i].GetDescription() + "\n";
            }
            return listText;
        }

























































        public static string HelpText()
        {
            return @"
Kommandoer:

liste
Du kan skrive 'liste' for å få en liste over alle personer

vis <id>
Eksempel: vis 14";
        }
    }

}

