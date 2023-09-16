using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidatePath : MonoBehaviour
{
    private GameObject pathParent;
    [SerializeField]
    public bool IsValid => _hasInPath() && _hasOutPath();
    
    void Start()
    {
        pathParent = gameObject;
    }
    
    private bool _hasInPath()
    {
        IList<GameObject> inChildren = new List<GameObject>();
        // loop through all children of pathParent and add the ones with inPath active to inChildren
        foreach (Transform child in pathParent.transform)
        {
            if (child.gameObject.GetComponent<PathSwitch>().Type() == PathSwitch.pathType.enter)
                inChildren.Add(child.gameObject);
        }
        
        if (inChildren.Count == 0)
        {
            Debug.LogError("There is no inPath. It must be one.\n You can turn on the inPath by clicking on the path.");
            return false;
        }
        
        if (inChildren.Count > 1)
        {
            Debug.LogError("There is more than one inPath. It should be only one.");
            return false;
        }
        
        return true;
    }
    
    private bool _hasOutPath()
    {
        IList<GameObject> outChildren = new List<GameObject>();
        // loop through all children of pathParent and add the ones with outPath active to outChildren
        foreach (Transform child in pathParent.transform)
        {
            if (child.gameObject.GetComponent<PathSwitch>().Type() == PathSwitch.pathType.exit)
                outChildren.Add(child.gameObject);
        }
        
        if (outChildren.Count == 0)
        {
            Debug.LogError("There is no outPath. It must be one.\n You can turn on the outPath by clicking on the path.");
            return false;
        }
        
        if (outChildren.Count > 1)
        {
            Debug.LogError("There is more than one outPath. It should be only one.");
            return false;
        }
        
        return true;
    }
}
