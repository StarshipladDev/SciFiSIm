using SciFiSim.Logic.Models.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTestApp.Tests
{
    internal class PersonTest
    {
        public static void TestPeopleCreation()
        {
            List<Person> peopleList = new List<Person>();
            string[] listOfNames = {
                "Amir Al-Farsi",
                "Leyla Hassani",
                "Tariq Al-Najjar",
                "Yasmin Shirazi",
                "Farid Mostafa",
                "Nour El-Din",
                "Sanaa Al-Rashid",
                "Malik Al-Khalil",
                "Dalia Al-Saad",
                "Samir Zahedi"
            };
            Random rand = new Random();
            for (int personIt = 0; personIt < listOfNames.Length; personIt++)
            {
                peopleList.Add(new Person(rand, listOfNames[personIt]));
            }
            for (int personIt = 0; personIt < listOfNames.Length; personIt++)
            {
                Console.WriteLine($"{peopleList[personIt].firstName} has the following details:" +
                    $"\n Hair : {peopleList[personIt].hair.hairType}" +
                    $"\n Eyes : {peopleList[personIt].eyes.eyeType}" +

                    $"\n Nose : {peopleList[personIt].nose.noseType}" +
                    $"\n Mouth : {peopleList[personIt].mouth.mouthType}" +
                    $"\n SkinTone : {peopleList[personIt].skinColor.skinType}"
                     );
            }

        }

    }
}
