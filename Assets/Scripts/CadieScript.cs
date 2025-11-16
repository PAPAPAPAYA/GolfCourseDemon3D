using System;
using UnityEngine;

public class CadieScript : MonoBehaviour
{
        public GameObject hightLight;
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
                newBall.GetComponent<BallScript>().highLight = hightLight;
                GameManagerScript.me.AssignCurrentBall(newBall);
        }
}