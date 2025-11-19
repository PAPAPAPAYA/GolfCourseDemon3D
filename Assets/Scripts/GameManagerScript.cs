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
        public GameObject highLight;
        private Rigidbody _ballRb;
        public Isometric3DInputUIManagerScript inputUIManager;
        public ClubManagerScript clubManager;
        public Isometric3DInputManagerScript inputManager;

        private void Update()
        {
                // only allow player to strike and show strike ui when there is a "selected" ball
                // also, when current ball is not moving
                if (currentBall)
                {
                        if (_ballRb.linearVelocity.magnitude < 0.1f &&
                            _ballRb.angularVelocity.magnitude < 0.1f)
                        {
                                inputUIManager.gameObject.SetActive(true);
                                inputManager.gameObject.SetActive(true);
                                clubManager.gameObject.SetActive(true);
                        }
                }
                else
                {
                        inputUIManager.gameObject.SetActive(false);
                        clubManager.gameObject.SetActive(false);
                        inputManager.gameObject.SetActive(false);
                }
        }

        public void AssignCurrentBall(GameObject ball)
        {
                currentBall = ball;
                _ballRb =  ball.GetComponent<Rigidbody>();
        }
}
