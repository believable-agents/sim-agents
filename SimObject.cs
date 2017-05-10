using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ei.Agents.Sims
{
    public class SimObject : MonoBehaviour
    {
        public string Name {
            get { return this.gameObject.name; }
            set { this.gameObject.name = value; }
        }
        public string Icon;

        public SimAction[] Actions;
        public SeedInfo Seed;

        public SimObject() {
            this.Seed = new SeedInfo();
            this.Actions = new SimAction[0];
        }
    }
}
