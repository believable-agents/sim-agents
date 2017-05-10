// using Glide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ei.Agents.Core.Behaviours
{
    [DisplayName("Linear Navigation")]
    public class LinearNavigation : EiBehaviour, IUpdates
    {
        private float destinationX;
        private float destinationY;

        public bool Navigating { get; private set; }
        public float SpeedPxPerSecond { get; set; }

        private Tweener tween;
        private DateTime startTime;

        public virtual void MoveToDestination(Vector3 position) {
            this.MoveToDestination(position.x, position.y);
        }

        public virtual void MoveToDestination(float x, float y) {
            if (this.SpeedPxPerSecond == 0) {
                return;
            }

            this.destinationX = x;
            this.destinationY = y;

            var distance = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(x, y));
            var time = distance / (this.SpeedPxPerSecond * BehaviourConfiguration.SimulatedDecay);

            this.startTime = DateTime.Now;

            var length = (float) time;
            this.tween = new Tweener(this.transform, this.destinationX, this.destinationY, length);

            // this.tweener.Tween(this.Transform, new { X = x, Y = y }, time, 0);

            this.Navigating = true;

            // Debug.WriteLine($"Starting Navigation to {this.destinationX},{this.destinationY}  in {time} distance {distance}");
        }

        public void Start() {
            if (this.SpeedPxPerSecond == 0) {
                UnityEngine.Debug.LogError(string.Format("{0} is immobile as his speed is set to 0", this.gameObject.name));
            }
        }

        public void Update() {
            if (!this.Navigating) {
                return;
            }

            var xDelta = Math.Abs(this.transform.position.x - this.destinationX);
            var yDelta = Math.Abs(this.transform.position.y - this.destinationY);

            // Debug.WriteLine($"{xDelta} {yDelta}");

            if (xDelta < 0.001 && yDelta < 0.001) {
                this.Navigating = false;

                // Debug.WriteLine($"Finished at '{(Timer.Now - this.startTime).TotalSeconds:0.00}' ${xDelta:0.0},{yDelta:0.0}");
            } else {
                this.tween.Update(Time.deltaTime);
            }
        }
    }
}
