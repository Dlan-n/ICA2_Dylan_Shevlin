using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionPortalController : MonoBehaviour
{
    public GameObject targetPortal;
    public GameObject[] objectsToHide;

    private bool isVisible = true;

    void Start()
    {
        // Disable objects that are initially hidden
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player enters the trigger, hide the objects
        if (other.gameObject.tag == "Player")
        {
            isVisible = false;
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the player exits the trigger, show the objects
        if (other.gameObject.tag == "Player")
        {
            isVisible = true;
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(true);
            }
        }
    }

    void Update()
    {
        // If the target portal is visible, show the objects
        if (targetPortal.GetComponent<OcclusionPortal>().open && !isVisible)
        {
            isVisible = true;
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(true);
            }
        }
    }
}