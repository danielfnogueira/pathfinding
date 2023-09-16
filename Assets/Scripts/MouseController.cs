using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private float cooldownTime = 1.0f; // Adjust this to the desired hold duration
    private Hashtable cooldownTable = new Hashtable();
    private bool isMouseHeld = false;
    private float mouseHeldStartTime = 0.0f;

    void Update()
    {
        // Detect if the left mouse button is being held down
        if (Input.GetMouseButtonDown(0))
        {
            isMouseHeld = true;
            mouseHeldStartTime = Time.time;
        }
        
        // Check if the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isMouseHeld = false;
        }

        // Execute when the mouse has been held for the specified duration
        if (isMouseHeld && Time.time - mouseHeldStartTime >= cooldownTime)
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
                            pathSwitch.AddPath((int)PathType.block);
                        }

                        // Update the cooldown table
                        cooldownTable[hit.collider.gameObject] = Time.time;
                    }
                }
            }
        }
    }
}
