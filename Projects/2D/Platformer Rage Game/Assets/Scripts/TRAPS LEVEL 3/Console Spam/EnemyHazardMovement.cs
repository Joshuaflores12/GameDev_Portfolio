using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class EnemyHazardMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer enemyHazard;
    [SerializeField] private float speed;
    [SerializeField] private float moveDuration;
    [SerializeField] private float direction = 1f;
    [SerializeField] private float fadeSpeed;

    private void Start()
    {
        StartCoroutine(MoveAndFade());
    }

    private IEnumerator MoveAndFade() 
    {
        float timer = 0f;
        while (timer < moveDuration) 
        {
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
            timer += Time.deltaTime;
            if (Mathf.FloorToInt(timer * 2f) % 2 == 0) 
            
                direction = 1f;
            else
                direction = -1f;
            yield return null;
        }
        yield return StartCoroutine(FadeOut());
        Destroy(gameObject);
    }

    private IEnumerator FadeOut() 
    {
        Color color = enemyHazard.color;
        while (color.a > 0f) 
        {
            color.a -= Time.deltaTime * fadeSpeed;
            enemyHazard.color = color;
            yield return null;
        }

        color.a = 0f;
        enemyHazard.color = color;
    }

}
