using System;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // The object to be activated by the pressure plate
    public List<GameObject> targetObjects = new List<GameObject>();
    private bool isPressed = false;

    public AudioSource audioSource;
    public AudioClip pressurePlateSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            ActivatePressurePlate();
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
        audioSource.Play();
    }
}
