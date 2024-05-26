using SciFiSim.Logic.Models.Entities.Root;
using SciFiSim.Logic.Models.Entities.Town;
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
        public TownSimulation simulation = null;
        public Simulation(Town? town, List<PersonEntity>? people, List<BuildingEntity>? buildings)
        {
            if (town != null && people != null)
            {
                this.simulation = new TownSimulation(town, people, buildings);
                this.simulation.SetStartLocation();
                this.simulation.CreateTerrorist();
            }
        }
        public void RunSimulation(List<Time> timeSlots, Action<TownSimulation> actionToPreformOnTick)
        {
            this.timeSlots = timeSlots;
            timer = new Timer(1000); // Set the interval to 2 seconds

            // Subscribe to the Elapsed event
            timer.Elapsed += this.OnTick;
            if(actionToPreformOnTick != null)
            {
                timer.Elapsed += (sender,e) => { actionToPreformOnTick(simulation); };
            }

            // Enable the timer
            timer.Enabled = true;
        }
        private void OnTick(Object source, ElapsedEventArgs e)
        {
            // Update the currentValue with the next item from the list
            currentTime = this.timeSlots[currentTimeIndex];

            // Increment the index for the next call
            currentTimeIndex++;

            // Reset the index if it exceeds the number of items in the list
            if (currentTimeIndex >= timeSlots.Count)
            {
                currentTimeIndex = 0;
            }
            if(this.simulation != null)
            {
                this.simulation.OnTick();
            }
        }
    }
}
