using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.People
{
    public class Person
    {
        public Eyes eyes;
        public Mouth mouth;
        public Nose nose;
        public SkinColor skinColor;
        public Hair hair;
        public string firstName;
        public string lastName;

        public Person(Random rand,string fullName)
        {
            List<HairType> hairTypes = Enum.GetValues(typeof(HairType)).Cast<HairType>().ToList();
            List<NoseType> noseTypes = Enum.GetValues(typeof(NoseType)).Cast<NoseType>().ToList();
            List<MouthType> mouthTypes = Enum.GetValues(typeof(MouthType)).Cast<MouthType>().ToList();
            List<EyeType> eyeTypes = Enum.GetValues(typeof(EyeType)).Cast<EyeType>().ToList();
            List<SkinColorType> skinTypes = Enum.GetValues(typeof(SkinColorType)).Cast<SkinColorType>().ToList();

            this.hair = new Hair{hairType = hairTypes[rand.Next(hairTypes.Count())] };
            this.nose = new Nose { noseType = noseTypes[rand.Next(noseTypes.Count())] };
            this.mouth = new Mouth { mouthType = mouthTypes[rand.Next(mouthTypes.Count())] };
            this.eyes = new Eyes { eyeType = eyeTypes[rand.Next(eyeTypes.Count())] };
            this.skinColor = new SkinColor { skinType = skinTypes[rand.Next(skinTypes.Count())] };
            this.firstName = fullName.Split(' ')[0];
            this.lastName = fullName.Split(" ")[1];

        }
    }
}
