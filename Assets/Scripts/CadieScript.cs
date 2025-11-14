using System;
using UnityEngine;

public class CadieScript : MonoBehaviour
{
        private void Start()
        {
                // spawn the first ball
                ServeBall();
        }
        private void Update()
        {
                if (!GameManagerScript.me.currentBall)
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
                GameManagerScript.me.AssignCurrentBall(newBall);
        }
}