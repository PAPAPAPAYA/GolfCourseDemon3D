using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatRefSO : ScriptableObject
{
        public float value;
        public bool resetOnStart;
        private void OnEnable()
        {
                if (resetOnStart) value = 0;
        }
}
