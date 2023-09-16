using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathSwitch : MonoBehaviour, IPointerClickHandler
{
    public GameObject blockPath;
    public GameObject redPath;
    public GameObject greenPath;
    public GameObject bluePath;
    public GameObject inPath;
    public GameObject outPath;

    private bool canClick = true;
    private float clickCooldown = 0.3f;
    
    public IList<PathType> Types()
    {
        List<PathType> types = new List<PathType>();
        if (blockPath.activeSelf)
            types.Add(PathType.block);
        if (redPath.activeSelf)
            types.Add(PathType.red);
        if (greenPath.activeSelf)
            types.Add(PathType.green);
        if (bluePath.activeSelf)
            types.Add(PathType.blue);
        if (inPath.activeSelf)
            types.Add(PathType.enter);
        if (outPath.activeSelf)
            types.Add(PathType.exit);
        return types;
    }

    /**
     * In, Out and block are major types
     * Get type will return one of then or walk
     */
    public PathType Type()
    {
        if (blockPath.activeSelf)
            return PathType.block;
        if (inPath.activeSelf)
            return PathType.enter;
        if (outPath.activeSelf)
            return PathType.exit;
        return PathType.walk;
    }


public void AddPath(int type)
    {
        AddPath((PathType)type);
    }
    
    private void AddPath(PathType type)
    {
        switch (type)
        {
            case PathType.block:
                blockPath.SetActive(true);
                break;
            case PathType.red:
                redPath.SetActive(true);
                break;
            case PathType.green:
                greenPath.SetActive(true);
                break;
            case PathType.blue:
                bluePath.SetActive(true);
                break;
            case PathType.enter:
                inPath.SetActive(true);
                break;
            case PathType.exit:
                outPath.SetActive(true);
                break;
        }
    }
    
    public void RemovePath(PathType type)
    {
        switch (type)
        {
            case PathType.block:
                blockPath.SetActive(false);
                break;
            case PathType.red:
                redPath.SetActive(false);
                break;
            case PathType.green:
                greenPath.SetActive(false);
                break;
            case PathType.blue:
                bluePath.SetActive(false);
                break;
        }
    }
    
    public void ClearPath()
    {
        blockPath.SetActive(false);
        redPath.SetActive(false);
        greenPath.SetActive(false);
        bluePath.SetActive(false);
        inPath.SetActive(false);
        outPath.SetActive(false);
    }
    
    public bool IsBlocked()
    {
        return blockPath.activeSelf;
    }
    
    public bool IsOnlyWalk()
    {
        return !blockPath.activeSelf && !redPath.activeSelf && !greenPath.activeSelf && !bluePath.activeSelf;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!canClick) // If clicking is on cooldown, return early.
            return;
        
        if (blockPath.activeSelf)
        {
            ClearPath();
            inPath.SetActive(true);
        }
        else if (inPath.activeSelf)
        {
            ClearPath();
            outPath.SetActive(true);
        }
        else if (outPath.activeSelf)
        {
            ClearPath();
            outPath.SetActive(false);
        }
        else
        {
            ClearPath();
            blockPath.SetActive(true);
        }

        // Start the cooldown timer.
        StartCoroutine(ClickCooldown());
    }

    private IEnumerator ClickCooldown()
    {
        canClick = false;
        yield return new WaitForSeconds(clickCooldown);
        canClick = true;
    }
    
}
