using UnityEngine;

public class InvisibleBlockCollider : MonoBehaviour
{
    [SerializeField] private GameObject spikeTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spikeTrigger != null)
        {
            spikeTrigger.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spikeTrigger != null)
        {
            spikeTrigger.SetActive(false);
        }
    }
}
