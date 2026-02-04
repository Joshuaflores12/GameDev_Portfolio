using UnityEngine;
using System.Collections;
public class WindowDragMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer windowDragRenderer;
    [SerializeField] private float speed;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float moveDuration;
    void Start()
    {
        StartCoroutine(MoveAndFade());        
    }

    private IEnumerator MoveAndFade() 
    {
        float timer = 0f;
        while (timer < moveDuration) 
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return StartCoroutine(FadeOut());
        Destroy(gameObject);
    }

    private IEnumerator FadeOut() 
    {
        Color color = windowDragRenderer.color;
        while (color.a > 0f) 
        {
            color.a -= Time.deltaTime * fadeSpeed;
            windowDragRenderer.color = color;
            yield return null;
        }

        color.a = 0f;
        windowDragRenderer.color = color;
    }
}
