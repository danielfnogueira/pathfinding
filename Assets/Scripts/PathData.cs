using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathData : MonoBehaviour
{
    private Guid _id;
    private IList<PathData> _adjacentList;
    [SerializeField]
    private string _name => gameObject.transform.name.ToLower() != "pathsample" ? gameObject.transform.name : "x999999y999999";
    private string _x => _name.ToLower().Split('y')[0].Replace("x", "");
    private string _y => _name.ToLower().Split('y')[1];
    
    public Guid Id => _id;
    public string Name => _name;
    public int X()
    {
        try
        {
            return int.Parse(_x);
        }
        catch (Exception e)
        {
            Debug.LogError(_x + "--" + e);
            return 999;
        }
    }
    public int Y()
    {
        try
        {
            return int.Parse(_y);
        }
        catch (Exception e)
        {
            Debug.LogError(_y + "--" + e);
            return 999;
        }
    }
    public IList<PathData> AdjacentList() => _adjacentList;
    
    public void OnEnable()
    {
        _id = Guid.NewGuid();
        _adjacentList = new List<PathData>();
    }
    
    public void CalculateAdjacentList()
    {
        _adjacentList = new List<PathData>();
        // get parent with tag FieldsContainer
        GameObject fieldsContainer = gameObject.transform.parent.gameObject;
        // get all children of parent
        IList<GameObject> children = new List<GameObject>();
        foreach (Transform child in fieldsContainer.transform)
            children.Add(child.gameObject);
        
        // this is a xy field matrix, based on the x and y of child, we can get the adjacent fields
        foreach (GameObject child in children)
        {
            if (child.GetComponent<PathData>().X() == X() && child.GetComponent<PathData>().Y() == Y() + 1)
                _adjacentList.Add(child.GetComponent<PathData>());
            if (child.GetComponent<PathData>().X() == X() && child.GetComponent<PathData>().Y() == Y() - 1)
                _adjacentList.Add(child.GetComponent<PathData>());
            if (child.GetComponent<PathData>().X() == X() + 1 && child.GetComponent<PathData>().Y() == Y())
                _adjacentList.Add(child.GetComponent<PathData>());
            if (child.GetComponent<PathData>().X() == X() - 1 && child.GetComponent<PathData>().Y() == Y())
                _adjacentList.Add(child.GetComponent<PathData>());
        }
    }

}
