using UnityEngine;

public class HiddenBlock : MonoBehaviour
{
    [SerializeField] private GameObject fakeExitTrap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            fakeExitTrap.SetActive(false);
            Destroy(gameObject);
        }
    }
}
