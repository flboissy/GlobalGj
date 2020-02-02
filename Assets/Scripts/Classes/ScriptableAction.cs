using Assets.Scripts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public class ScriptableAction: ScriptableObject
    {
        public ActionType Type;
        public int EnergyCost;
        public Sprite Sprite;
        public float Duration;
        public float Cooldown;
        public String inputName;
    }
}
