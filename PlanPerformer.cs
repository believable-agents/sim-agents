using Ei.Agents.Sims;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanPerformer : MonoBehaviour {
    public abstract void Perform(GameObject agent, SimAction action, Action successCallback, Action failedCallback); 
}
