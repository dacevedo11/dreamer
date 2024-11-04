using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject wallToDestroy;  // Assign the wall GameObject in the Inspector

    // Call this method to destroy the wall
    public void DestroyWall()
    {
        if (wallToDestroy != null)
        {
            Destroy(wallToDestroy); // Destroy the wall GameObject
        }
    }
}
