using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class FakeExitTrigger : MonoBehaviour
{
    [SerializeField] private GameObject fakeExitUI;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private string shutdownMessage = "System shutdown initiated...";
    [SerializeField] private string gameMenu;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private float delayBeforeFadeOut = 1f;
    [SerializeField] private bool hasTriggered = false;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            hasTriggered = true;
            StartCoroutine(ShutdownSequence());
        }
    }

    private IEnumerator ShutdownSequence()
    {
        fakeExitUI.SetActive(true);
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        foreach(GameObject button in buttons) 
        {
            button.SetActive(false);
        }

        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        messageText.text = "";
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 1f);
        foreach (char letter in shutdownMessage)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(delayBeforeFadeOut);

        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * fadeSpeed;
            messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, t);
            yield return null;
        }

        messageText.gameObject.SetActive(false);
        foreach (GameObject button in buttons) 
        {
            button.SetActive(true);
            CanvasGroup buttonGroup = button.GetComponent<CanvasGroup>();
            if (buttonGroup != null) 
            {
                buttonGroup.alpha = 0f;
                while (buttonGroup.alpha < 1f) 
                {
                    buttonGroup.alpha += Time.deltaTime * fadeSpeed;
                    yield return null;
                }
            }
        }
    }
     public void TryAgain() 
    {
        SceneManager.LoadScene(gameMenu);
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
