using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionPortalController : MonoBehaviour
{
    // An array of GameObjects that should be culled when not visible through the portal
    public GameObject[] objectsToOcclude;

    // The Camera that is rendering the player's view
    public Camera playerCamera;

    void Update()
    {
        // Create a plane representing the portal's orientation and position
        Plane portalPlane = new Plane(transform.forward, transform.position);

        // Create a plane representing the player's view direction and position
        Plane playerPlane = new Plane(playerCamera.transform.forward, playerCamera.transform.position);

        // Test if any of the objects to occlude are visible through the portal
        bool portalVisible = GeometryUtility.TestPlanesAABB(
            new Plane[] { portalPlane },
            objectsToOcclude[0].GetComponent<Renderer>().bounds);

        // Test if any of the objects to occlude are visible to the player
        bool playerVisible = GeometryUtility.TestPlanesAABB(
            new Plane[] { playerPlane },
            objectsToOcclude[0].GetComponent<Renderer>().bounds);

        // If the portal and the player can see the objects, make them visible
        if (portalVisible && playerVisible)
        {
            foreach (GameObject obj in objectsToOcclude)
            {
                obj.SetActive(true);
            }
        }
        // If the portal or the player cannot see the objects, hide them
        else
        {
            foreach (GameObject obj in objectsToOcclude)
            {
                obj.SetActive(false);
            }
        }
    }
}