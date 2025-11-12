using UnityEngine;

public class Isometric3DInputUIManagerScript : MonoBehaviour
{
        public GameObject dirIndicator;
        public float forceToIndicatorLengthRatio = 1f;
        private Isometric3DInputManagerScript _inputMan;
        public FloatRefSO force;
        public Vector3 dirIndicatorSize = new(0.1f, 0.1f, 0.1f);
        
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
                var ogPos = dirIndicator.transform.position;
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
                        // change indicator direction, opposite of drag dir
                        dirIndicator.transform.rotation = Quaternion.Euler(
                                0, 
                                UtilityFuncManagerScript.me.ConvertV3ToAngle(_inputMan.mouseDragDir), 
                                0);
                }
                else
                {
                        // hide indicator
                        dirIndicator.transform.localScale = new Vector3(0, 0, 0);
                }
        }
}
