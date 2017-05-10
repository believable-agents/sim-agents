using Ei.Agents.Sims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(SimObject))]
public class SeedInfo: MonoBehaviour
{
    public int Count;
    public int MaxSeedCount;
    public int MinSeedCount;
    public float NextSeed;
    public int SeedPeriodInMinutes;
}
