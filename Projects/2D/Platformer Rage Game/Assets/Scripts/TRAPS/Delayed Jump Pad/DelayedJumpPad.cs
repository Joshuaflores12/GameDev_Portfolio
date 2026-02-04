using UnityEngine;
using System.Collections;
public class DelayedJumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float delay = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            StartCoroutine(DelayedJump(collision.gameObject));
        }
    }

    private IEnumerator DelayedJump(GameObject player) 
    {
        float elapsed = 0f;
        while (elapsed < delay)
        {
            Debug.Log(elapsed.ToString("F1") + " / " + delay + " seconds");
            yield return new WaitForSeconds(0.1f); 
            elapsed += 0.1f;
        }

        Debug.Log("Jump triggered after delay of " + delay + " second(s).");

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null) 
        {
            rb.linearVelocity = new Vector2 (rb.linearVelocity.x, jumpForce);
            rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse)   ;
        }
    }
}
