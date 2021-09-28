using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Developer
{
    public class Developer
    {
        //Developers have names and Id Numbers
        //Identify One Dev(person) from the other
        //Know if Dev(person) has access to Plurasight
        
            public Developer() { }

            public Developer(string fullName, int idNumber, PlurasightAccess accessToPlurasight)
            {
                FullName = fullName;
                IdNumber = idNumber;
                Plurasight = accessToPlurasight;
            }
            public string FullName { get; set; }

            public int IdNumber { get; set; }

            public PlurasightAccess  Plurasight { get; set; }

            public bool HasAccessToPlurasight
            {
                get
                {
                    //switch case 
                    switch (Plurasight)
                    {
                        case PlurasightAccess.Approved:
                            return true;

                        case PlurasightAccess.Denied:
                        default:
                            return false;

                    }
                }
            }

        }

        public enum PlurasightAccess
        {
            Approved = 1,
            Denied,
       
        }
    }


