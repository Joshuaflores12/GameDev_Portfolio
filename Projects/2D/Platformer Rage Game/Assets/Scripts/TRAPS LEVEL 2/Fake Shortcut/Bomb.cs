using UnityEngine;
using System.Collections;
using TMPro;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 3f;
    [SerializeField] private float explodeDelay = 2f;
    [SerializeField] private TextMeshProUGUI countdownText;

    private void Start()
    {
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(true);
        }

        StartCoroutine(ExplodeAfterDelay());
    }

    private IEnumerator ExplodeAfterDelay()
    {
        float timeLeft = explodeDelay;

        while (timeLeft > 0)
        {
            if (countdownText != null)
            {
                countdownText.text = Mathf.Ceil(timeLeft).ToString();
            }

            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
        }

        if (countdownText != null)
        {
            countdownText.text = "";
            countdownText.gameObject.SetActive(false);
        }

        CircleCollider2D explosionTrigger = gameObject.AddComponent<CircleCollider2D>();
        explosionTrigger.isTrigger = true;
        explosionTrigger.radius = explosionRadius;

        gameObject.tag = "Trap";

        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
