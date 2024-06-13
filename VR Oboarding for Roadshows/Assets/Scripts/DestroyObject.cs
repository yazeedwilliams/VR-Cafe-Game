using UnityEngine;

/// <summary>
/// Destroys object after it touches the bin
/// </summary>
public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bin"))
            Destroy(gameObject);
    }
}
