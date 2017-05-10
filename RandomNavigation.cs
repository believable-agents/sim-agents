using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ei.Agents.Core.Behaviours
{
    [DisplayName("Random Navigation")]
    public class RandomNavigation : EiBehaviour, IUpdates
    {
        private LinearNavigation navigation;
 
        public int X { get; set; }
        public int Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public void Start() {
            this.navigation = GetComponent<LinearNavigation>();
        }

        public void Update() {
            if (!this.navigation.Navigating) {
                var x = (float) (this.X + UnityEngine.Random.Range(0, this.Width));
                var y = (float) (this.Y + UnityEngine.Random.Range(0, this.Height));

                this.navigation.MoveToDestination(x, y);
            }
        }
    }
}
