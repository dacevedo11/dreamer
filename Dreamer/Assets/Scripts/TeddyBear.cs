using UnityEngine;

public class TeddyBear : MonoBehaviour
{
    public AudioClip hitSound;  // Assign the sound effect in the Inspector
    public Explode explodeScript;  // Assign the Explode script in the Inspector

    private AudioSource audioSource;
    private MeshRenderer meshRenderer;
    private bool isDestroyed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (hitSound != null)
        {
            audioSource.clip = hitSound;
        }
    }

    // Call this method when a raycast hit is detected
    public void OnHit()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;  // Prevent multiple triggers
            PlaySoundAndDeactivate();

            if (explodeScript != null)
            {
                explodeScript.DestroyWall();  // Destroy the wall
            }
        }
    }

    private void PlaySoundAndDeactivate()
    {
        // Make the mesh invisible immediately
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false; // Hide the mesh
        }

        // Play the hit sound immediately
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
