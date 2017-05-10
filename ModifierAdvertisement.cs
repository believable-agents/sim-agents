using Ei.Agents.Core.Behaviours;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ei.Agents.Sims
{
    [Serializable]
    public class ModifierAdvertisement
    {
        public ModifierType Type;
        public float Delta;
        public PersonalityModifier[] PersonalityModifiers;

        public ModifierAdvertisement() {
            this.PersonalityModifiers = new PersonalityModifier[0];
        }

        public ModifierAdvertisement(float delta, ModifierType type, PersonalityModifier[] modifiers) {
            this.Delta = delta;
            this.Type = type;
            this.PersonalityModifiers = modifiers;
        }
    }
}
