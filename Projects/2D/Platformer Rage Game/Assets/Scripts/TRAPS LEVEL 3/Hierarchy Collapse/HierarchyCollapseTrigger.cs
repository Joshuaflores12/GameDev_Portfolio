using UnityEngine;

public class HierarchyCollapseTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] collapsable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            for(int i = 0; i < collapsable.Length; i++) 
            {
                if (collapsable[i] != null) 
                {
                    collapsable[i].SetActive(true);
                }
            }
        }        
    }
}
