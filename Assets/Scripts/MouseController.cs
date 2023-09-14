using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    
    /*
     * Detects when mouse is left button pressed
     * when pressed, it will detect the 2D object it is pointing to
     * if it has tag "Respawn" it will access the its PathSwitch script
     * if the IsBlocked is true, it means it is a wall, and it will ClearPath()
     * we have to ensure it is a walkable path, so we check IsOnlyWalk()
     * Being !IsBlocked() and IsOnlyWalk(), we AddPath(pathType.block)
     * other configurations will be ignored by the mouse holding action
     */
    
    private float cooldownTime = 2f;
    private Hashtable cooldownTable = new Hashtable();

    void Update()
    {
        // Detect if the left mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Check if the raycast hit an object with the "Respawn" tag
            if (hit.collider != null && hit.collider.CompareTag("Respawn"))
            {
                // Check if the object is not in cooldown
                if (!cooldownTable.ContainsKey(hit.collider.gameObject) || Time.time - (float)cooldownTable[hit.collider.gameObject] >= cooldownTime)
                {
                    // Access the PathSwitch script on the hit object
                    PathSwitch pathSwitch = hit.collider.GetComponent<PathSwitch>();

                    if (pathSwitch != null)
                    {
                        // Check if the path is blocked (a wall)
                        if (pathSwitch.IsBlocked())
                        {
                            // Clear the path
                            pathSwitch.ClearPath();
                        }
                        // Check if the path is walkable
                        else if (pathSwitch.IsOnlyWalk())
                        {
                            // Add a blocked path
                            pathSwitch.AddPath((int)PathSwitch.pathType.block);
                        }

                        // Update the cooldown table
                        cooldownTable[hit.collider.gameObject] = Time.time;
                    }
                }
            }
        }
    }
   
}
