using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ei.Agents.Sims
{
    [Serializable]
    public class SimAction
    {
        public string Name;
        public int Uses;
        public bool Depleted { get; set; }
        public ModifierAdvertisement[] Modifiers;
        public string[] Plan;
        public float DurationInMinutes;

        public SimAction() {
            this.Plan = new string[0];
            this.Modifiers = new ModifierAdvertisement[0];
        }

        public SimAction(string name, int uses, ModifierAdvertisement[] modifiers, float durationInMinutes, string[] plan) {
            this.Name = name;
            this.Uses = uses;
            this.Modifiers = modifiers;
            this.Plan = plan;
            this.DurationInMinutes = durationInMinutes;
        }
    }
}
