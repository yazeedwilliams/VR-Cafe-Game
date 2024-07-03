using UnityEngine;

/// <summary>
/// Destroys object after it touches the bin
/// </summary>
public class DestroyObject : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int points = 1;
    private UpdateScore updateScore;

    private void Start()
    {
        updateScore = FindObjectOfType<UpdateScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bin"))
        {
            updateScore.IncreasScore(points);
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}
