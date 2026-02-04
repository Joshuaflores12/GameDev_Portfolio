using UnityEngine;

public class StalactileCollapse : MonoBehaviour
{
    [SerializeField] private GameObject stalactile;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            if (stalactile.GetComponent<Rigidbody2D>() != null) 
            {
                Rigidbody2D rb = stalactile.GetComponent<Rigidbody2D>();
                rb.gravityScale = 1f;
            }
        }
    }

}
