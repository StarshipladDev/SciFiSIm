using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SciFiSim.Logic.Models.System.Logic
{
    public class Simulation
    {
        public Time currentTime = null;
        private int currentTimeIndex = 0;
        public List<Time> timeSlots = new List<Time>();
        private Timer timer;
        public void RunSimulation(List<Time> timeSlots)
        {
            this.timeSlots = timeSlots;
            timer = new Timer(2000); // Set the interval to 2 seconds

            // Subscribe to the Elapsed event
            timer.Elapsed += this.OnTick;

            // Enable the timer
            timer.Enabled = true;

            Console.WriteLine("Timer started. Press enter to exit.");
            Console.ReadLine();
        }
        private void OnTick(Object source, ElapsedEventArgs e)
        {
            // Update the currentValue with the next item from the list
            currentTime = this.timeSlots[currentTimeIndex];

            // Print the current value for demonstration
            Console.WriteLine($"Current Value: {currentTime.timeName}");

            // Increment the index for the next call
            currentTimeIndex++;

            // Reset the index if it exceeds the number of items in the list
            if (currentTimeIndex >= timeSlots.Count)
            {
                currentTimeIndex = 0;
            }
        }
    }
}
