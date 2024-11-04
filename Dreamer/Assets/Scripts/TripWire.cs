using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripWire : MonoBehaviour
{
    public GameObject floor;
    public AudioClip tripwireSound;
    public AudioClip deactivationSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = tripwireSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateTripwire());
        }
    }

    private IEnumerator ActivateTripwire()
    {
        if (audioSource != null && tripwireSound != null)
        {
            audioSource.Play(); // Play the sound
            yield return new WaitForSeconds(tripwireSound.length); // Wait for the sound to finish
        }

        if (floor != null)
        {
            floor.SetActive(false); // Deactivate the floor GameObject
        }

        // Play the deactivation sound after the floor is deactivated
        if (audioSource != null && deactivationSound != null)
        {
            audioSource.clip = deactivationSound; // Change the audio clip to the deactivation sound
            audioSource.Play(); // Play the deactivation sound
            yield return new WaitForSeconds(deactivationSound.length); // Wait for the deactivation sound to finish
        }
    }
}
