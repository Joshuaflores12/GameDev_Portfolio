using UnityEngine;
using TMPro;
public class CorruptedFilesTrap : MonoBehaviour
{
    [SerializeField] private GameObject corruptedFilesUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            corruptedFilesUI.SetActive(true);
            Destroy(gameObject);
        }
    }
}
