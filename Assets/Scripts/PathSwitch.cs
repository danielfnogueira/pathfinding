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
        enter = 5,
        exit = 6
    }
    
    public GameObject blockPath;
    public GameObject redPath;
    public GameObject greenPath;
    public GameObject bluePath;
    public GameObject inPath;
    public GameObject outPath;
    
    private bool canClick = true; 
    private float clickCooldown = 0.3f; 


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
            case pathType.enter:
                inPath.SetActive(true);
                break;
            case pathType.exit:
                outPath.SetActive(true);
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
