using Unity.Cinemachine;
using UnityEngine;

public class FakeGoal : MonoBehaviour
{
    [SerializeField] private GameObject deathTrap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && deathTrap != null)
        {
            deathTrap.SetActive(true);
        }
    }
}
