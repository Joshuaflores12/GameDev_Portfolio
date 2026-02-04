using UnityEngine;

public class HiddenBlockj : MonoBehaviour
{
    [SerializeField] private GameObject PlayMode;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayMode.SetActive(false);
        }        
    }
}
