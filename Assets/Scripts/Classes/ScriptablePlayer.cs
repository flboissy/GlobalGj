using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    [CreateAssetMenu]
    public class ScriptablePlayer: ScriptableObject
    {
        public float totalEnergy;
        public float totalLifePoint;
        public int totalOfComponents;
    }
}
