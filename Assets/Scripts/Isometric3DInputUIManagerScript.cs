using UnityEngine;

public class Isometric3DInputUIManagerScript : MonoBehaviour
{
        public GameObject dirIndicator;
        public float forceToIndicatorLengthRatio = 1f;
        private Isometric3DInputManagerScript _inputMan;
        public FloatRefSO force;
        public Vector3 dirIndicatorSize = new(0.1f, 0.1f, 0.1f);
        public GameObject currentBall;
        
        private void Start()
        {
                _inputMan = Isometric3DInputManagerScript.me;
        }
        private void Update()
        {
                UpdateDirIndicator();
        }
        private void UpdateDirIndicator()
        {
                var ogPos = currentBall.transform.position;
                if (Input.GetMouseButtonDown(0))
                {
                        ogPos = dirIndicator.transform.position;
                }
                if (_inputMan.mouseDown)
                {
                        // show indicator
                        dirIndicator.transform.localScale = dirIndicatorSize;
                        // offset based on strike force
                        var offset = -_inputMan.mouseDragDir * (force.value * forceToIndicatorLengthRatio);
                        dirIndicator.transform.position = ogPos + offset;
                        //print(ogPos + offset);
                        //print("dirindicator pos: "+dirIndicator.transform.position);
                        // change indicator direction, opposite of drag dir
                        dirIndicator.transform.rotation = Quaternion.Euler(
                                0, 
                                UtilityFuncManagerScript.me.ConvertV3ToAngle(_inputMan.mouseDragDir), 
                                0);
                }
                if (!_inputMan.mouseDown || _inputMan.mouseDragDir.magnitude <= 0)
                {
                        // hide indicator
                        dirIndicator.transform.localScale = new Vector3(0, 0, 0);
                }
        }
}
