using UnityEngine;

public class FakeCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject zapper;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && zapper != null)
        {
            zapper.SetActive(true);
        }

    }

}
