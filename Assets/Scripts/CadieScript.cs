using System;
using UnityEngine;

// it spawns with start tile
public class CadieScript : MonoBehaviour
{
        public GameObject highLight;
        private void Start()
        {
                // spawn the first ball
                highLight = GameManagerScript.me.highLight;
                ServeBall();
                
        }
        private void Update()
        {
                if (!GameManagerScript.me.currentBall)
                {
                        ServeBall();
                }
                if(Input.GetKeyDown(KeyCode.B))
                {
                        ServeBall();
                }
        }

        private void ServeBall()
        {
                var newBall = ObjectPoolerScript.me.BallPool.Get();
                newBall.transform.position = transform.position;
                newBall.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                newBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                newBall.GetComponent<BallScript>().highLight = highLight;
                GameManagerScript.me.AssignCurrentBall(newBall);
        }
}