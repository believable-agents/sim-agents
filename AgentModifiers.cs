using Ei.Agents.Core;
using System.Diagnostics;
using UnityEngine;

namespace Ei.Agents.Sims
{
    public abstract class Modifier
    {
        private float xValue;
        private float decayRatePerSecond = 1;

        public virtual float DecayRatePerSecond {
            get { return decayRatePerSecond; }
            set { decayRatePerSecond = value; }
        }

        public virtual float XValue {
            get { return this.xValue; }
            set { this.xValue = Mathf.Clamp(value, -100, 100); }
        }

        public float discomfort;


        public void Update(float deltaTime) {
            this.xValue = Mathf.Clamp(this.xValue - deltaTime * this.DecayRatePerSecond * BehaviourConfiguration.SimulatedDecay, -100, 100);
            // Debug.Log("Updating X: " + this.XValue);
            this.UpdateDiscomfort();

        }

        protected void UpdateDiscomfort() {
            this.discomfort = this.CalculateY(this.XValue);
        }
        protected abstract string ModifierName { get; }
        public abstract float CalculateY(float x);
    }

    public class EnergyModifier : Modifier
    {
        protected override string ModifierName { get { return "Energy"; } }
        public override float CalculateY(float x) {
            // Debug.Log("For " + x + " returnning " + ((x * -0.3f) + 30));
            return Mathf.Clamp((x * -0.3f) + 30, 0, 100);
        }
    }

    public class HungerModifier : Modifier
    {
        protected override string ModifierName { get { return "Hunger"; } }
        public override float CalculateY(float x) {
            // Debug.Log("For " + x + " returnning " + ((x * -0.3f) + 30));
            return Mathf.Clamp(3000 / (x + 130), 0, 100);
        }
    }

    public class ThirstModifier : Modifier
    {
        protected override string ModifierName { get { return "Thirst"; } }
        public override float CalculateY(float x) {
            // Debug.Log("For " + x + " returnning " + ((x * -0.3f) + 30));
            return Mathf.Clamp(1000 / (x + 110), 0, 100);
        }
    }

    public class ComfortModifier : Modifier
    {
        protected override string ModifierName { get { return "Comfort"; } }
        public override float CalculateY(float x) {
            return Mathf.Clamp(((x * x) / 250) + 10, 0, 100); ;
        }
    }

    public class FunModifier : Modifier
    {
        protected override string ModifierName { get { return "Fun"; } }
        public override float CalculateY(float x) {
            return Mathf.Clamp(((x * x) / 500) + 10, 0, 100); ;
        }
    }

    public class HygieneModifier : Modifier
    {
        protected override string ModifierName { get { return "Hygiene"; } }
        public override float CalculateY(float x) {
            return Mathf.Clamp((x * -0.2f) + 20, 0, 100); ;
        }
    }

    public class SocialModifier : Modifier
    {
        protected override string ModifierName { get { return "Social"; } }
        public override float CalculateY(float x) {
            return Mathf.Clamp(((x * x) / 220) + 10, 0, 100); ;
        }
    }

    public class RoomModifier : Modifier
    {
        protected override string ModifierName { get { return "Room"; } }
        public override float CalculateY(float x) {
            return Mathf.Clamp(((x * x) / 400) + 10, 0, 100); ;
        }
    }
}
