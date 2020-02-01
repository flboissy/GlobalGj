using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    public enum ActionType
    {
        Electrochoc,
        Firewall,
        Quarantine,
        Drone,
        Push
    }

    [CreateAssetMenu]
    public class Action : ScriptableObject
    {
        public ActionType Type;
        public String Description;
        public float Cooldown;
        public int EnergyCost;
        public bool Available;
        public Sprite sprite;
        public float duration;

    }
}
