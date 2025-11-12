using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubManagerScript : MonoBehaviour
{
        #region SINGLETON
        public static ClubManagerScript me;
        #endregion
        public float minForce; // min force to apply to ball
        public float maxForce; // max force
        public float holdToForceRatio; // hold time to force boost mod
        public Rigidbody rbToMove;
        private Isometric3DInputManagerScript _inputMan;
        public FloatRefSO force;
        
        // debug
        public float forceDebug;

        private void Awake()
        {
                me = this;
        }
        private void Start()
        {
                _inputMan = Isometric3DInputManagerScript.me;
        }

        private void Update()
        {
                if (Input.GetMouseButtonUp(0))
                {
                        Strike();
                }
                forceDebug = CalculateForce();
        }

        public float CalculateForce()
        {
                force.value = minForce + _inputMan.mouseDragDuration * holdToForceRatio;
                force.value  = Mathf.Clamp(force.value, minForce, maxForce);
                return force.value;
        }

        private void Strike()
        {
                // rotate
                transform.rotation = Quaternion.Euler(0, 0, -UtilityFuncManagerScript.me.ConvertV3ToAngle(_inputMan.mouseDragDir));
                // move
                rbToMove.AddForce(-_inputMan.mouseDragDir * CalculateForce(), ForceMode.Impulse);
        }
}