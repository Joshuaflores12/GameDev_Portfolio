using UnityEngine;

public class WindowDragTrigger : MonoBehaviour
{
    [SerializeField] private GameObject windowDragTrap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            windowDragTrap.SetActive(true);
        }
    }
}
