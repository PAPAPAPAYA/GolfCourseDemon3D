using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputUIManagerScript : MonoBehaviour
{
        public GameObject dirIndicator;
        public float forceToIndicatorLengthRatio = 1f;
        private Isometric3DInputManagerScript _inputMan;
        public FloatRefSO force;
        public float camOffset;
        
        private void Start()
        {
                _inputMan = Isometric3DInputManagerScript.me;
        }
        private void Update()
        {
                UpdateDirIndicator();
        }
        public void UpdateDirIndicator()
        {
                Vector3 ogPos = Vector3.zero;
                if (Input.GetMouseButtonDown(0))
                {
                        ogPos = dirIndicator.transform.localPosition;
                }
                if (_inputMan.mouseDown)
                {
                        // show indicator
                        dirIndicator.transform.localScale = new Vector3(1, 1, 1);
                        // change local y based on drag duration
                        //Vector3 offset = _inputMan.mouseDragDir * force.value * forceToIndicatorLengthRatio;
                        Vector3 offset = new Vector3(0, 0, 0);
                        dirIndicator.transform.localPosition = ogPos + offset;
                        // change indicator direction, opposite of drag dir
                        dirIndicator.transform.rotation = Quaternion.Euler(0, 
                                camOffset + UtilityFuncManagerScript.me.ConvertV3ToAngle(_inputMan.mouseDragDir), 
                                0);
                }
                else
                {
                        // hide indicator
                        dirIndicator.transform.localScale = new Vector3(1, 1, 1);
                }
        }
}