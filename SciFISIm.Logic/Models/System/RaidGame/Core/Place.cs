using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public class Place
    {
        public List<Actor> actorsInPlace;
        public string placeName;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Place> ConnectedPlaces { get; set; }

        public Place(string placeName)
        {
            actorsInPlace = new List<Actor>();
            this.placeName = placeName;
            ConnectedPlaces = new List<Place>();
        }
        

        public void DefinePlaceDimensions(int x, int y, int width, int height)
        {
            X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public void ConnectTo(Place otherPlace)
        {
            if (!ConnectedPlaces.Contains(otherPlace))
            {
                ConnectedPlaces.Add(otherPlace);
                otherPlace.ConnectTo(this);
            }
        }

        public override string ToString()
        {
            return $"Place {placeName} at ({X}, {Y}) with size ({Width}, {Height})";
        }
    }

}
