using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
        #region GENERAL
        public bool mouseDown = false; // if mouse is held down
        public Vector3 mouseScreenPos = Vector3.zero; // mouse position
        public Vector3 mouseWorldPos = Vector3.zero; // mouse position in 3d
        public Vector3 mouseDownPos = Vector3.zero; // mouse held down position
        public Vector3 mouseDownWorldPos = Vector3.zero; // mouse held down position in 3d
        public Vector3 mouseDragDir = Vector3.zero; // mouse dragged direction
        public float mouseDragDuration = 0; // how long mouse held down
        public float distFromCamera = 10f;
        public float mouseDragDegree;
        #endregion
        #region SINGLETON
        public static InputManagerScript me;
        private void Awake()
        {
                me = this;
        }
        #endregion
	
        void Update()
        {
                // mouse status tracking
                mouseDown = Input.GetMouseButton(0); // updates if dragging
                // get mouse 3d position
                mouseScreenPos = Input.mousePosition; // updates mouse pos
                mouseScreenPos.z = distFromCamera;
                mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
                // get mouse down 3d position
                if (Input.GetMouseButtonDown(0)) // mouse down frame
                {
                        mouseDownPos = mouseScreenPos;
                        mouseDownPos.z = distFromCamera;
                        mouseDownWorldPos =  Camera.main.ScreenToWorldPoint(mouseDownPos);
                        // reset drag duration
                        mouseDragDuration = 0;
                }
                // record mouse drag duration
                if (mouseDown) // mouse hold
                {
                        mouseDragDuration += Time.deltaTime;
                }
                if (Input.GetMouseButtonUp(0)) // mouse up frame
                {
                        mouseDragDuration = 0;
                }
                // get mouse drag dir
                mouseDragDir = (mouseWorldPos - mouseDownWorldPos).normalized;
                mouseDragDegree = UtilityFuncManagerScript.me.ConvertV3ToAngle(mouseDragDir);
                // debug
                Debug.DrawLine(mouseDownWorldPos, mouseDragDir * 100f, Color.blue);
        }
}