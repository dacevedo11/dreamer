using System;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // The object to be activated by the pressure plate
    public List<GameObject> targetObjects = new List<GameObject>();
    private bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            ActivatePressurePlate();
            Debug.Log("Pressure Plate activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isPressed)
        {
            isPressed = false;
            DeactivatePressurePlate();
            Debug.Log("Pressure Plate deactivated");
        }
    }

    private void ActivatePressurePlate()
    {
        // Loop through all target objects and activate each one
        foreach (GameObject target in targetObjects)
        {
            if (target != null)
            {
                target.SetActive(true);  // Activate each individual GameObject
            }
        }
    }

    private void DeactivatePressurePlate()
    {
        // Loop through all target objects and deactivate each one
        foreach (GameObject target in targetObjects)
        {
            if (target != null)
            {
                target.SetActive(false);  // Deactivate each individual GameObject
            }
        }
    }
}
