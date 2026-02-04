using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private bool isActivated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActivated) return;

        if (other.CompareTag("Player")) 
        {
            PlayerColl.SetCheckpoint(transform.position);
            isActivated = true;
            Debug.Log("New Checkpoint Unlocked!");
        }
    }
}
