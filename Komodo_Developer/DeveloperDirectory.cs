using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Developer
{
    public class DeveloperDirectory
    {
        //Field
        public readonly List<Developer> _DevDirectory = new List<Developer>();

        Developer developer = new Developer();

        //Create
        public bool AddContentToDirectory(Developer developer)
        {
            int startingCount = _DevDirectory.Count;

            _DevDirectory.Add(developer);

            //Ternary
            bool wasAdded = (_DevDirectory.Count > startingCount) ? true : false;
            return wasAdded;

        }
        //Read
        public List<Developer> GetContents()
        {
            return _DevDirectory;
        }
        //Get by Name
        public Developer GetContentByName(string theNameYouAreLookingFor)
        {
            foreach (Developer developer in _DevDirectory)
            {
                if (developer.FullName.ToLower() == theNameYouAreLookingFor)
                {
                    return developer;
                }

            }
            return null;
        }

        //Update

        //Update
        public bool UpdateExistingDeveloper(Developer existingDeveloper, Developer newDeveloper)
        {
            existingDeveloper.FullName = newDeveloper.FullName;
            existingDeveloper.IdNumber = newDeveloper.IdNumber;
            existingDeveloper.Plurasight = newDeveloper.Plurasight;
            return true;
        }


        //Delete

        //Delete
        public bool DeleteContent(Developer existingDeveloper)
        {
            bool result = _DevDirectory.Remove(existingDeveloper);
            return result;
        }

        //ClassBrace
    }
   
}
