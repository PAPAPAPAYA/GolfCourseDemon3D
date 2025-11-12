using System;
using UnityEngine;

public class Isometric3DInputManagerScript : MonoBehaviour
{
        #region GENERAL
        public bool mouseDown = false; // if mouse is held down
        public Vector3 mouseDownPos = Vector3.zero; // mouse held down position
        public Vector3 mouseDragDir = Vector3.zero; // mouse dragged direction
        public float mouseDragDuration = 0; // how long mouse held down
        public float mouseDragDegree;
        #endregion
        #region SINGLETON
        public static Isometric3DInputManagerScript me;
        private void Awake()
        {
                me = this;
        }
        #endregion
        public Transform mousePositionProjectPlaneCenter;
        private void Update()
        {
                // mouse status tracking
                mouseDown = Input.GetMouseButton(0); // updates if dragging
                // record mouse drag duration
                if (mouseDown) // mouse hold
                {
                        mouseDragDuration += Time.deltaTime;
                }
                if (Input.GetMouseButtonUp(0)) // mouse up frame
                {
                        mouseDragDuration = 0;
                }
                // project mouse position to a plane, hitPoint being the projected pos
                // this creates a horizontal plane passing through this object's center
                var plane = new Plane(Vector3.up, mousePositionProjectPlaneCenter.transform.position);
                // create a ray from the mousePosition
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // plane.Raycast returns the distance from the ray start to the hit point
                if (plane.Raycast(ray, out var distance))
                {
                        // some point of the plane was hit - get its coordinates
                        var hitPoint = ray.GetPoint(distance);
                        if (Input.GetMouseButtonDown(0))
                        {
                                mouseDownPos = hitPoint;
                        }
                        if (mouseDown)
                        {
                                // get mouse drag dir
                                mouseDragDir = (hitPoint - mouseDownPos).normalized;
                        }
                }
                mouseDragDegree = UtilityFuncManagerScript.me.ConvertV3ToAngle(mouseDragDir);
                // debug
                Debug.DrawLine(mouseDownPos, mouseDragDir * 100f, Color.blue);
        }
}
