using System;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
        {
                if (other.CompareTag("Ball"))
                {
                        print("goal");
                        ObjectPoolerScript.me.BallPool.Release(other.gameObject);
                        GameManagerScript.me.currentBall = null;
                }
        }
}
