using Komodo_Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Console
{
    class ProgramUI
    {
        private  DeveloperDirectory _Dev = new DeveloperDirectory();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            //Create a menu with options matching up to my Repositiory

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                //Change Info below
                Console.WriteLine
                    (
                        "Please enter the number of your selection:\n" +
                        "1. Search developers by name.\n" +
                        "2. Search developers by employee ID.\n" +
                        "3. Verify devolpers Plurasight Access.\n" +
                        "4. View all developers.\n" +
                        "5. Update information for developers.\n" +
                        "6. Remove developer from directory.\n" +
                        "0. Exit"
                    );

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Create new content
                        CreateNewContent();
                        break;
                    case "2":
                        //Show all content
                        ShowAllDevelopers();
                        break;
                    case "3":
                        //Show content by title
                        ShowDeveloperName();
                        break;
                    case "4":
                        //Update content
                        UpdateContent();
                        break;
                    case "5":
                        //Delete content
                        RemoveContentFromRepository();
                        break;
                    case "0":
                        isRunning = false;
                        //Exit
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 0.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                }

            }
        }

        //Creating content 
        private void CreateNewContent()
        {
            Console.Clear();

            Developer developer = new Developer();

            //Name
            Console.WriteLine("Please enter developer's full name:");
            developer.FullName = Console.ReadLine();

            //Id
            Console.WriteLine("Please enter developer's Id number:");
            developer.IdNumber = Convert.ToInt32(Console.ReadLine());


            //Access to Plurasight
            Console.WriteLine("Plurasight Access: \n" +
                "1.Approved\n" +
                "2.Denied\n");

            string accessPlurasightString = Console.ReadLine();
            int accessPlurasightId = int.Parse(accessPlurasightString);
            developer.Plurasight = (PlurasightAccess)accessPlurasightId;

            _Dev.AddContentToDirectory(developer);
        }

        //Read

        //Getting all content
        private void ShowAllDevelopers()
        {
            //Clean slate to work from
            Console.Clear();

            List<Developer> listOfDevelopers = _Dev.GetContents();

            foreach (Developer developer in listOfDevelopers)
            {
                //Using helper method
                DisplayContent(developer);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Getting Specific Content(by developer)
        private void ShowDeveloperName()
        {
            Console.Clear();

            Console.WriteLine("Which developer are you looking for?");
            string name = Console.ReadLine();

            Developer developer = _Dev.GetContentByName(name);
            //Verify that content is in our repository

            if (developer != null)
            {

                //Using helper method
                DisplayContent(developer);

            }
            else
            {
                Console.WriteLine("Unfortunatly that developer has not been added to the system.");
            }

            PressAnyKeyToContinue();
        }


        //Update

        //Updating content
        private void UpdateContent()
        {
            Console.Clear();

            Console.WriteLine("What is the Name of the developer you would like to update:");
            string targetDeveloper = Console.ReadLine();

            Developer targetdeveloper = _Dev.GetContentByName(targetDeveloper);

            if (targetDeveloper == null)
            {
                Console.WriteLine("We are not able to find that developer");
                PressAnyKeyToContinue();
                return;
            }

            Developer updatedDeveloper = new Developer();

            //Name
            Console.WriteLine($"Original name: {targetdeveloper.FullName}\n" +
                $"Please enter a new developer:");
            updatedDeveloper.FullName = Console.ReadLine();

            //IdNumber
            Console.WriteLine($"Original idnumber: {targetdeveloper.IdNumber}");
            Console.WriteLine("Please enter a new Idenetification number:");
            updatedDeveloper.IdNumber = Convert.ToInt32(Console.ReadLine());

   

            //Plurasight Access
            Console.WriteLine($"Original maturity rating: {targetdeveloper.Plurasight}");
            Console.WriteLine("Select access to Plurasight: \n" +
                "1.Approved\n" +
                "2. Denied\n");

            updatedDeveloper.Plurasight = (PlurasightAccess)int.Parse(Console.ReadLine());


            if(_Dev.UpdateExistingDeveloper(targetdeveloper, updatedDeveloper))
            {
                Console.WriteLine("Update successful");
            }
            else
            {
                Console.WriteLine("Update failed!");
            }

            PressAnyKeyToContinue();
        }

        //Delete

        //Deleting content
        private void RemoveContentFromRepository()
        {
            Console.Clear();

            List<Developer> developerList = _Dev.GetContents();

            int index = 1;

            foreach (Developer developer in developerList)
            {
                Console.WriteLine($"{index}. {developer.FullName}");
                index++;
            }

            Console.WriteLine("What developer would you like to remove?");
            int targetTitleId = int.Parse(Console.ReadLine());
            int targetIndex = targetTitleId - 1;

            if (targetIndex >= 0 && targetIndex < developerList.Count)
            {
                Developer targetDeveloper = developerList[targetIndex];

                if (_Dev.DeleteContent(targetDeveloper))
                {
                    Console.WriteLine($"{targetDeveloper.FullName} was successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Oh no, something went wrong!");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid selection.");
            }

            PressAnyKeyToContinue();

        }

        //Helper Methods
        private void DisplayContent(Developer developer)
        {
            Console.WriteLine(
                    $"Developer: {developer.FullName}\n" +
                    $"Description: {developer.IdNumber}\n");
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Pres any key to continue...");
            Console.ReadKey();
        }

    }
}
