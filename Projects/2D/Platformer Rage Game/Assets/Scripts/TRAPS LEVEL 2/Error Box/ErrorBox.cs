using UnityEngine;

public class ErrorBox : MonoBehaviour
{
    [SerializeField] private GameObject ErrorBoxUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            ErrorBoxUI.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
