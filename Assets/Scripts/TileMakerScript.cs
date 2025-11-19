using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileMakerScript : MonoBehaviour
{
    public int placedTilesCount = 0;
    public float stepDist;
    public int spawnAmount;
    public int currentAmount = 0;
    public List<GameObject> tilePool;
    public List<GameObject> tilePoolStart;
    public List<GameObject> tilePoolEnd;
    public List<GameObject> tilePoolCurrent;
    public GameObject tileParent;

    public TileScript lastTile;
    public List<EnumManagerScript.Direction> availableDirs;
    public EnumManagerScript.Direction currentMoveDir;
    public EnumManagerScript.Direction lastMoveDir;
    public EnumManagerScript.Direction moveDirToRemove;

    public List<GameObject> availableTiles;
    public Vector3 rayOffset;
    private Ray _upRay = new Ray();
    private RaycastHit _upHitData;
    private Ray _rightRay = new Ray();
    private RaycastHit _rightHitData;
    private Ray _downRay = new Ray();
    private RaycastHit _downHitData;
    private Ray _leftRay = new Ray();
    private RaycastHit _leftHitData;
    public EnumManagerScript.SideType upSituation;
    public EnumManagerScript.SideType rightSituation;
    public EnumManagerScript.SideType downSituation;
    public EnumManagerScript.SideType leftSituation;

    public float spawnInterval;
    public float spawnTimer;
    public bool startSpawn = false;
    
    private void Start()
    {
        //PlaceDownTile();
    }

    private void Update()
    {
        // gather surrounding side infos
        // define rays
        _upRay = new Ray(transform.position + rayOffset, Vector3.forward);
        _rightRay = new Ray(transform.position + rayOffset, Vector3.right);
        _downRay = new Ray(transform.position + rayOffset, Vector3.back);
        _leftRay = new Ray(transform.position + rayOffset, Vector3.left);
        // cast out rays and assign situations
        if (Physics.Raycast(_upRay, out _upHitData, 1))
        {
            if (_upHitData.transform.GetComponent<SideInfoScript>() != null)
            {
                upSituation = _upHitData.transform.GetComponent<SideInfoScript>().thisSideType;
            }
        }
        else
        {
            upSituation = EnumManagerScript.SideType.None;
        }
        if (Physics.Raycast(_rightRay, out _rightHitData, 1))
        {
            if (_rightHitData.transform.GetComponent<SideInfoScript>() != null)
            {
                rightSituation = _rightHitData.transform.GetComponent<SideInfoScript>().thisSideType;
            }
        }
        else
        {
            rightSituation = EnumManagerScript.SideType.None;
        }
        if (Physics.Raycast(_downRay, out _downHitData, 1))
        {
            if (_downHitData.transform.GetComponent<SideInfoScript>() != null)
            {
                downSituation = _downHitData.transform.GetComponent<SideInfoScript>().thisSideType;
            }
        }
        else
        {
            downSituation = EnumManagerScript.SideType.None;
        }
        if (Physics.Raycast(_leftRay, out _leftHitData, 1))
        {
            if (_leftHitData.transform.GetComponent<SideInfoScript>() != null)
            {
                leftSituation = _leftHitData.transform.GetComponent<SideInfoScript>().thisSideType;
            }
        }
        else
        {
            leftSituation = EnumManagerScript.SideType.None;
        }
        // draw rays
        Debug.DrawRay(transform.position + rayOffset, Vector3.forward * 1, Color.red);
        Debug.DrawRay(transform.position + rayOffset, Vector3.right * 1, Color.red);
        Debug.DrawRay(transform.position + rayOffset, Vector3.back * 1, Color.red);
        Debug.DrawRay(transform.position + rayOffset, Vector3.left * 1, Color.red);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            startSpawn = true;
        }
        if (startSpawn)
        {
            if (currentAmount == spawnAmount) return;
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                spawnTimer -= spawnInterval;
                GetAvailableTiles();
                if (availableTiles.Count <= 0) return;
                PlaceDownTile();
                currentAmount++;
                GetAvailableDirs();
                if (availableDirs.Count <= 0) return;
                Step();
            }
        } 
        for (var i = 0; i < spawnAmount; i++)
        {
            
            
        }
        
    }

    private void GetAvailableTiles()
    {
        availableTiles.Clear();
        // decide what tile pool to use
        // check if putting down first tile
        if (placedTilesCount <= 0)
        {
            UtilityFuncManagerScript.me.CopyGameObjectList(tilePoolStart, tilePoolCurrent);
        }
        // check if deciding last tile
        else if (currentAmount == spawnAmount - 1)
        {
            UtilityFuncManagerScript.me.CopyGameObjectList(tilePoolEnd, tilePoolCurrent);
        }
        else // not the first nor last tile, use normal tile pool
        {
            UtilityFuncManagerScript.me.CopyGameObjectList(tilePool, tilePoolCurrent);
        }
        if (tilePoolCurrent.Count <= 0) return;
        foreach (var currentTile in tilePoolCurrent) // get each tiles in tile pool
        {
            var ts = currentTile.GetComponent<TileScript>();
            if ((ts.up == upSituation || upSituation == EnumManagerScript.SideType.None) &&
                (ts.right == rightSituation || rightSituation == EnumManagerScript.SideType.None) &&
                (ts.down == downSituation || downSituation == EnumManagerScript.SideType.None) &&
                (ts.left == leftSituation || leftSituation == EnumManagerScript.SideType.None))
            {
                if (!availableTiles.Contains(currentTile))
                {
                    availableTiles.Add(currentTile);
                }
            }
        }
    }

    private void PlaceDownTile()
    {
        if (availableTiles.Count <= 0) return;
        var tile = availableTiles[Random.Range(0, availableTiles.Count)];
        Instantiate(tile, transform.position, tile.transform.rotation, tileParent.transform);
        lastTile = tile.GetComponent<TileScript>();
        placedTilesCount++;
    }
    
    private void GetAvailableDirs()
    {
        // clear available dirs
        availableDirs.Clear();
        // get available directions
        if (!lastTile || lastTile.up == EnumManagerScript.SideType.WalledPath) 
        {
            availableDirs.Add(EnumManagerScript.Direction.Up);
        }
        if (!lastTile || lastTile.right == EnumManagerScript.SideType.WalledPath)
        {
            availableDirs.Add(EnumManagerScript.Direction.Right);
        }
        if (!lastTile || lastTile.down == EnumManagerScript.SideType.WalledPath)
        {
            availableDirs.Add(EnumManagerScript.Direction.Down);
        }
        if (!lastTile || lastTile.left == EnumManagerScript.SideType.WalledPath)
        {
            availableDirs.Add(EnumManagerScript.Direction.Left);
        }
        // remove opposite dir of last move dir from available dirs to avoid going back
        switch (lastMoveDir)
        {
            case EnumManagerScript.Direction.None:
                moveDirToRemove = EnumManagerScript.Direction.None;
                break;
            case EnumManagerScript.Direction.Up:
                moveDirToRemove = EnumManagerScript.Direction.Down;
                break;
            case EnumManagerScript.Direction.Right:
                moveDirToRemove = EnumManagerScript.Direction.Left;
                break;
            case EnumManagerScript.Direction.Down:
                moveDirToRemove = EnumManagerScript.Direction.Up;
                break;
            case EnumManagerScript.Direction.Left:
                moveDirToRemove = EnumManagerScript.Direction.Right;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        for (var i = availableDirs.Count; i --> 0; )
        {
            //print(availableDirs[i] + " vs " + moveDirToRemove);
            if (availableDirs[i].Equals(moveDirToRemove))
            {
                //print(availableDirs[i] + " " + moveDirToRemove);
                availableDirs.RemoveAt(i);
            }
        }
    }
    private void Step()
    {
        // check if there are available dirs, if not, return
        if (availableDirs.Count == 0)
        {
            return;
        }
        // decide which way to go
        currentMoveDir = availableDirs[Random.Range(0, availableDirs.Count)];
        // move
        switch (currentMoveDir)
        {
            case EnumManagerScript.Direction.Up:
                transform.Translate(Vector3.forward * stepDist);
                break;
            case EnumManagerScript.Direction.Right:
                transform.Translate(Vector3.right * stepDist);
                break;
            case EnumManagerScript.Direction.Down:
                transform.Translate(Vector3.back * stepDist);
                break;
            case EnumManagerScript.Direction.Left:
                transform.Translate(Vector3.left * stepDist);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        lastMoveDir = currentMoveDir;
    }
}
