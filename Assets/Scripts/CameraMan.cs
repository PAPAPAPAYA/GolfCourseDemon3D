using UnityEngine;

public class CameraMan : MonoBehaviour
{
        public float camSpeed;
        public Transform camTarget;
        private Vector3 _camTargetPos;
        public Vector3 camOffset;
        private void Update()
        {
                if (!GameManagerScript.me.currentBall)
                {
                        return;
                }
                else
                {
                        camTarget =  GameManagerScript.me.currentBall.transform;
                }
                _camTargetPos = camTarget.position;
                transform.position = Vector3.Lerp(transform.position, _camTargetPos + camOffset, camSpeed*Time.deltaTime);
        }
}
