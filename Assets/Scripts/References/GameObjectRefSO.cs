using System;
using UnityEngine;

[CreateAssetMenu]
public class GameObjectRefSO : ScriptableObject
{
        public GameObject goRef;
        public GameObject Value()
        {
                return goRef;
        }
}
