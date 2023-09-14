using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathSwitch : MonoBehaviour, IPointerClickHandler
{
    public enum pathType : int
    {
        walk = 0,
        block = 1,
        red = 2,
        green = 3,
        blue = 4,
    }
    
    public GameObject blockPath;
    public GameObject redPath;
    public GameObject greenPath;
    public GameObject bluePath;

    public void AddPath(int type)
    {
        AddPath((pathType)type);
    }
    
    private void AddPath(pathType type)
    {
        switch (type)
        {
            case pathType.block:
                blockPath.SetActive(true);
                break;
            case pathType.red:
                redPath.SetActive(true);
                break;
            case pathType.green:
                greenPath.SetActive(true);
                break;
            case pathType.blue:
                bluePath.SetActive(true);
                break;
        }
    }
    
    public void RemovePath(pathType type)
    {
        switch (type)
        {
            case pathType.block:
                blockPath.SetActive(false);
                break;
            case pathType.red:
                redPath.SetActive(false);
                break;
            case pathType.green:
                greenPath.SetActive(false);
                break;
            case pathType.blue:
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
    }
    
    public bool IsBlocked()
    {
        return blockPath.activeSelf;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Write your code here for what you want to happen
        Debug.Log("You clicked the square!");
        
        if (blockPath.activeSelf)
        {
            blockPath.SetActive(false);
        }
        else
        {
            blockPath.SetActive(true);
        }
    }
    
}
