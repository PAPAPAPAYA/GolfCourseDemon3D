using System;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolerScript : MonoBehaviour
{
        #region SINGLETON
        public static ObjectPoolerScript me;
        private void Awake()
        {
                me = this;
        }
        #endregion
        public GameObject ballPrefab;
        public ObjectPool<GameObject> BallPool;
        public GameObject ballParent;

        private void Start()
        {
                BallPool = new ObjectPool<GameObject>
                (
                        InstantiateBall,
                        gameObjectToGet => gameObjectToGet.SetActive(true),
                        gameObjectToGet => gameObjectToGet.SetActive(false),
                        gameObjectToGet => Destroy(gameObjectToGet),
                        true,
                        50,
                        500
                );
        }
        private GameObject InstantiateBall()
        {
                var ballToMake = Instantiate(ballPrefab, ballParent.transform, true);
                return ballToMake;
        }
}
