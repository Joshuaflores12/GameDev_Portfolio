using UnityEngine;
using TMPro;

public class PopUpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject popUpCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (popUpCanvas != null && other.CompareTag("Player")) 
        {
            popUpCanvas.SetActive(true);
            Destroy(gameObject);
        }
    }
}
