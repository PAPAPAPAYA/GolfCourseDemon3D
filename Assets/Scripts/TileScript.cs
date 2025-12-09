using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public GameObject asset;
    public List<EnumManagerScript.SideType>  up;
    public List<EnumManagerScript.SideType> right;
    public List<EnumManagerScript.SideType> down;
    public List<EnumManagerScript.SideType> left;

    public SideInfoScript upInfo;
    public SideInfoScript rightInfo;
    public SideInfoScript downInfo;
    public SideInfoScript leftInfo;

    public float rotateAmount;

    private void Start()
    {
        //upInfo.thisSideType = up;
        UtilityFuncManagerScript.me.CopySideInfoList(up, upInfo.thisSideType);
        //rightInfo.thisSideType = right;
        UtilityFuncManagerScript.me.CopySideInfoList(right, rightInfo.thisSideType);
        //downInfo.thisSideType = down;
        UtilityFuncManagerScript.me.CopySideInfoList(down, downInfo.thisSideType);
        //leftInfo.thisSideType = left;
        UtilityFuncManagerScript.me.CopySideInfoList(left, leftInfo.thisSideType);
        var myAsset = Instantiate(asset, transform.position, Quaternion.Euler(0,rotateAmount,0), transform);
    }
}