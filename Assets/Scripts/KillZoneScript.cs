using System;
using UnityEngine;

public class KillZoneScript : MonoBehaviour
{
        
        private void OnCollisionEnter(Collision other)
        {
                if (other.transform.CompareTag("Ball"))
                {
                        ObjectPoolerScript.me.BallPool.Release(other.gameObject);
                        GameManagerScript.me.currentBall = null;
                }
        }
}
