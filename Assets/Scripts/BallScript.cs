using System;
using UnityEngine;
using UnityEngine.UIElements;

public class BallScript : MonoBehaviour
{
        private Rigidbody _myRb;
        public GameObject highLight;
        private bool _stopped;
        public bool _mouseHovering;
        private void OnEnable()
        {
                _myRb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
                if (Mathf.Abs(_myRb.linearVelocity.x) < .7f && 
                    Mathf.Abs(_myRb.linearVelocity.z) < .7f &&
                    Mathf.Abs(_myRb.linearVelocity.y) < .1f &&
                    _myRb.angularVelocity.magnitude < .7f)
                {
                        _myRb.linearVelocity = Vector3.zero;
                        _myRb.angularVelocity = Vector3.zero;
                        _stopped = true;
                }
                else
                {
                        _stopped = false;
                }
        }

        private void OnMouseEnter()
        {
                if (_stopped)
                {
                        highLight.SetActive(true);
                        highLight.transform.position = transform.position + new Vector3(0,-0.05f,0);
                        _mouseHovering = true;
                }
        }

        private void OnMouseExit()
        {
                highLight.SetActive(false);
                _mouseHovering = false;
        }

        private void OnMouseDown()
        {
                if (_mouseHovering)
                {
                        GameManagerScript.me.currentBall = gameObject;
                }
        }
}
