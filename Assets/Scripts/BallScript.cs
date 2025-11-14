using System;
using UnityEngine;

public class BallScript : MonoBehaviour
{
        private Rigidbody myRB;
        private void OnEnable()
        {
                myRB = GetComponent<Rigidbody>();
        }
        private void Update()
        {
                if (myRB.linearVelocity.magnitude > .1f)print(myRB.linearVelocity);
                if (myRB.angularVelocity.magnitude > .1f)print(myRB.angularVelocity);
                
                if (Mathf.Abs(myRB.linearVelocity.x) < .7f && 
                    Mathf.Abs(myRB.linearVelocity.z) < .7f &&
                    Mathf.Abs(myRB.linearVelocity.y) < .1f &&
                    myRB.angularVelocity.magnitude < .7f)
                {
                        myRB.linearVelocity = Vector3.zero;
                        myRB.angularVelocity = Vector3.zero;
                }
        }
}
