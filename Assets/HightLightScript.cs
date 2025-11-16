using UnityEngine;

public class HightLightScript : MonoBehaviour
{
    public Vector3 offset;
    void Update()
    {
        transform.position = transform.parent.position + offset;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
