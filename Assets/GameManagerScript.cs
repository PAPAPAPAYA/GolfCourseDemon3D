using System;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
        #region SINGLETON
        public static GameManagerScript me;
        private void Awake()
        {
                me = this;
        }
        #endregion
        public GameObject currentBall;
        private Rigidbody ballRB;
        public Isometric3DInputUIManagerScript inputUIManager;
        public ClubManagerScript clubManager;

        private void Update()
        {
                // only allow player to strike and show strike ui when there is a "selected" ball
                // also, when current ball is not moving
                if (currentBall &&
                    ballRB.linearVelocity.magnitude < 0.1f &&
                    ballRB.angularVelocity.magnitude < 0.1f)
                {
                        inputUIManager.gameObject.SetActive(true);
                        clubManager.gameObject.SetActive(true);
                }
                else
                {
                        inputUIManager.gameObject.SetActive(false);
                        clubManager.gameObject.SetActive(false);
                }
        }

        public void AssignCurrentBall(GameObject ball)
        {
                currentBall = ball;
                ballRB =  ball.GetComponent<Rigidbody>();
        }
}
