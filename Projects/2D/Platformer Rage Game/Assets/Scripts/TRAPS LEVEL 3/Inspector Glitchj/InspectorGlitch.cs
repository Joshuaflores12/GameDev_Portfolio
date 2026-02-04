using UnityEngine;

public class ReverseGravityTrigger : MonoBehaviour
{
    public float gravityTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has a Rigidbody2D
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Start coroutine to reverse gravity for 3 seconds
            StartCoroutine(ReverseGravity(rb));
        }
    }

    private System.Collections.IEnumerator ReverseGravity(Rigidbody2D rb)
    {
        float originalGravity = rb.gravityScale;

        // Set gravity scale to -1
        rb.gravityScale = -1f;

        // Wait for 3 seconds
        yield return new WaitForSeconds(gravityTime);

        // Revert to original gravity scale
        rb.gravityScale = originalGravity;
    }
}
