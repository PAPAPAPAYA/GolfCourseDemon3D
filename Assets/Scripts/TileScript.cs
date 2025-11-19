using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public GameObject asset;
    public EnumManagerScript.SideType up;
    public EnumManagerScript.SideType right;
    public EnumManagerScript.SideType down;
    public EnumManagerScript.SideType left;

    public SideInfoScript upInfo;
    public SideInfoScript rightInfo;
    public SideInfoScript downInfo;
    public SideInfoScript leftInfo;

    public float rotateAmount;

    private void Start()
    {
        upInfo.thisSideType = up;
        rightInfo.thisSideType = right;
        downInfo.thisSideType = down;
        leftInfo.thisSideType = left;
        var myAsset = Instantiate(asset, transform.position, Quaternion.Euler(0,rotateAmount,0), transform);
    }
}