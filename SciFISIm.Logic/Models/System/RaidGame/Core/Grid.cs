using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public class Grid
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private Random Random { get; set; }
        public List<Place> Places { get; set; }
        private int PlaceCounter { get; set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Random = new Random();
            Places = new List<Place>();
            PlaceCounter = 1;
        }

        public void PlaceObject(string placeName)
        {
            int placeWidth = Random.Next(1, 3);
            int placeHeight = Random.Next(1, 3);

            if (Places.Count == 0)
            {
                // Place the first object randomly
                int x = Random.Next(0, Width - placeWidth + 1);
                int y = Random.Next(0, Height - placeHeight + 1);
                AddPlace(x, y, placeWidth, placeHeight, placeName);
            }
            else
            {
                bool placed = false;
                while (!placed)
                {
                    // Pick a random existing place to place the new place adjacent to it
                    Place existingPlace = Places[Random.Next(Places.Count)];
                    (int newX, int newY) = GetAdjacentPosition(existingPlace, placeWidth, placeHeight);

                    if (newX >= 0 && newX <= Width - placeWidth && newY >= 0 && newY <= Height - placeHeight)
                    {
                        Place newPlace = new Place(placeName);
                        newPlace.DefinePlaceDimensions(newX, newY, placeWidth, placeHeight);
                        if (!IsOverlapping(newPlace))
                        {
                            AddPlace(newX, newY, placeWidth, placeHeight, placeName);
                            placed = true;
                        }
                    }
                }
            }
        }

        private void AddPlace(int x, int y, int width, int height, string name)
        {
            Place newPlace = new Place(name);
            newPlace.DefinePlaceDimensions(x, y, width, height);
            Places.Add(newPlace);

            // Connect the new place to adjacent places
            foreach (var place in Places)
            {
                if (place != newPlace && AreAdjacent(place, newPlace))
                {
                    place.ConnectTo(newPlace);
                }
            }
        }

        private (int, int) GetAdjacentPosition(Place place, int newPlaceWidth, int newPlaceHeight)
        {
            List<(int, int)> possiblePositions = new List<(int, int)>
        {
            (place.X - newPlaceWidth, place.Y), // left
            (place.X + place.Width, place.Y),   // right
            (place.X, place.Y - newPlaceHeight),// top
            (place.X, place.Y + place.Height)   // bottom
        };

            // Filter out invalid positions
            possiblePositions.RemoveAll(pos => pos.Item1 < 0 || pos.Item2 < 0 || pos.Item1 + newPlaceWidth > Width || pos.Item2 + newPlaceHeight > Height);

            // Shuffle the list to randomize the selection
            int n = possiblePositions.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                var value = possiblePositions[k];
                possiblePositions[k] = possiblePositions[n];
                possiblePositions[n] = value;
            }

            return possiblePositions.Count > 0 ? possiblePositions[0] : (-1, -1);
        }

        private bool AreAdjacent(Place p1, Place p2)
        {
            bool xAdjacent = (p1.X + p1.Width == p2.X) || (p2.X + p2.Width == p1.X) || (p1.X == p2.X) || (p1.X + p1.Width > p2.X && p1.X < p2.X + p2.Width);
            bool yAdjacent = (p1.Y + p1.Height == p2.Y) || (p2.Y + p2.Height == p1.Y) || (p1.Y == p2.Y) || (p1.Y + p1.Height > p2.Y && p1.Y < p2.Y + p2.Height);
            return xAdjacent && yAdjacent;
        }

        private bool IsOverlapping(Place newPlace)
        {
            foreach (var place in Places)
            {
                if (newPlace.X < place.X + place.Width &&
                    newPlace.X + newPlace.Width > place.X &&
                    newPlace.Y < place.Y + place.Height &&
                    newPlace.Y + newPlace.Height > place.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void DisplayGridWithNames()
        {
            string[,] gridRepresentation = new string[Height, Width];

            // Fill the grid with place names
            foreach (var place in Places)
            {
                for (int i = place.Y; i < place.Y + place.Height; i++)
                {
                    for (int j = place.X; j < place.X + place.Width; j++)
                    {
                        gridRepresentation[i, j] = place.placeName;
                    }
                }
            }

            // Print the grid
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write((gridRepresentation[i, j] ?? ".") + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
