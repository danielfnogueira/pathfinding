using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathCreator : MonoBehaviour
{
    [SerializeField] private GameObject pathBase;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private GameObject pathParent;
    [SerializeField] private Text xText;
    [SerializeField] private Text yText;

    private int maxX;
    private int maxY;
    private int x;
    private int y;

    public void Create()
    {
        // Delete all children of pathParent
        foreach (Transform child in pathParent.transform)
        {
            if(child.gameObject != pathBase)
                Destroy(child.gameObject);
        }

        // Detect the pathParent size x and y, and divide it by pathBase size x and y
        Vector3 pathParentSize = pathParent.GetComponent<Renderer>().bounds.size;
        Vector3 pathBaseSize = pathBase.GetComponent<Renderer>().bounds.size;
        maxX = Mathf.FloorToInt(pathParentSize.x / pathBaseSize.x);
        maxY = Mathf.FloorToInt(pathParentSize.y / pathBaseSize.y);
        
        x = Mathf.Min(int.Parse(xText.text), maxX);
        y = Mathf.Min(int.Parse(yText.text), maxY);

        // Create pathPrefabs based on x and y
        for (int i = 1; i <= x; i++)
        {
            for (int j = 1; j <= y; j++)
            {
                GameObject path = Instantiate(pathPrefab, pathParent.transform);
                path.name = $"x{i}y{j}";
                path.transform.position = new Vector3(
                    pathBase.transform.position.x + (pathBaseSize.x * (i - 1)),
                    pathBase.transform.position.y + (pathBaseSize.y * (j - 1)),
                    pathBase.transform.position.z
                );
                path.transform.localScale = new Vector3(
                    pathBase.transform.localScale.x,
                    pathBase.transform.localScale.y,
                    pathBase.transform.localScale.z
                );
            }
        }
    }
}