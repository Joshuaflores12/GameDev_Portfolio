using UnityEngine;
using TMPro;
using System.Collections;
public class FakeExitTrap : MonoBehaviour
{
    [SerializeField] private GameObject deathTrigger;
    [SerializeField] private GameObject fakeExitUI;
    [SerializeField] private GameObject hiddenBlock;
    [SerializeField] private TextMeshProUGUI fakeExitTimer;
    [SerializeField] private float timeToFind;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            triggered = true;
            hiddenBlock.SetActive(true);
            StartCoroutine(StartTimerCoundown());
        }
    }

    private IEnumerator StartTimerCoundown() 
    {
        float timer = timeToFind;
        while (timer > 0) 
        {
            timer -= Time.deltaTime;
            fakeExitTimer.text = Mathf.CeilToInt(timer).ToString();
            yield return null;
        }

        StartCoroutine(FadeFakeExitUI());
    }

    private IEnumerator FadeFakeExitUI() 
    {
        CanvasGroup canvasGroup = fakeExitUI.GetComponent<CanvasGroup>();
        if (canvasGroup == null) 
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        fakeExitUI.SetActive(true);
        while (canvasGroup.alpha < 1f) 
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
        }
        yield return new WaitForSeconds(1f);

        while(canvasGroup.alpha > 0f) 
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        fakeExitUI.SetActive(false);
        deathTrigger.SetActive(true);
        Destroy(gameObject);
    }
}
