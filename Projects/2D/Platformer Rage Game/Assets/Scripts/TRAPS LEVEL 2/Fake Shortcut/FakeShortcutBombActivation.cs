using UnityEngine;
using TMPro;
using System.Collections;
public class FakeShortcutBombActivation : MonoBehaviour
{
    [SerializeField] private GameObject Bomb;
    [SerializeField] private float timerDelay;
    [SerializeField] private TextMeshProUGUI bombTimer;
    [SerializeField] private bool hasActivated = false;
    [SerializeField] private SpriteRenderer fakeShortcut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasActivated && other.CompareTag("Player")) 
        {
            hasActivated = true;
            StartCoroutine(ActivateBomb());
        }
    }

    private IEnumerator ActivateBomb() 
    {
        bombTimer.gameObject.SetActive(true);
        float timeLeft = timerDelay;
        while (timeLeft > 0) 
        {
            bombTimer.text = Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForSeconds(1f);
            timeLeft -= 1;
            
        }

        bombTimer.text = "";
        bombTimer.gameObject.SetActive(false);

        if(fakeShortcut != null) 
        {
            Color color = fakeShortcut.color;
            color.a = 0f; 
            fakeShortcut.color = color;
        }

        Bomb.SetActive(true);
    }
}
