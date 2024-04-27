using System;
using UnityEngine;

namespace Systems.Events
{
    public static class ResearchEvent
    {
        public static event Action OnInfantryResearched;
        public static event Action OnAPCResearched;
        public static event Action OnTankResearched;
        public static event Action OnHelicopterResearched;
        public static event Action OnPlaneResearched;
        
        public static void ResearchInfantry()
        {
            OnInfantryResearched?.Invoke();
        }
        public static void ResearchAPC()
        {
            OnAPCResearched?.Invoke();
        }
        public static void ResearchTank()
        {
            OnTankResearched?.Invoke();
        }
        public static void ResearchHelicopter()
        {
            OnHelicopterResearched?.Invoke();
        }
        public static void ResearchPlane()
        {
            OnPlaneResearched?.Invoke();
        }
    }
}