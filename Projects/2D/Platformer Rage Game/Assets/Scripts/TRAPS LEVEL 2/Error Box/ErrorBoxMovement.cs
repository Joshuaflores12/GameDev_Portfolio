using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ErrorBoxMovement : MonoBehaviour, IPointerEnterHandler 
{
    [SerializeField] private int moveCount;
    [SerializeField] private RectTransform buttonRectTransform;
    [SerializeField] private GameObject errorBoxBombPrefab;
    [SerializeField] private GameObject errorBoxUI;
    [SerializeField] private Transform bombSpawnPoint;
    [SerializeField] private float timer = 5f;
    [SerializeField] private bool hasClicked = false;
    [SerializeField] private TextMeshProUGUI errorTimer;
    private PlayerColl playerScript;

    private void Awake()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        
    }

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerColl>();
    }
    private void Update()
    {
        if (hasClicked) return;
        timer -= Time.deltaTime;
        errorTimer.text = "Seconds Left: " + timer;
        if (timer <= 0) 
        {
            failedClickedX();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (moveCount <= 5)
        {
            float randomX = Random.Range(-100f, 100f);
            float randomY = Random.Range(-100f, 100f);
            buttonRectTransform.anchoredPosition += new Vector2(randomX, randomY);
            moveCount++;
            
        }

    }

    private void failedClickedX() 
    {
        errorBoxUI.SetActive(false);
        playerScript.Death();
    }

    public void closeError() 
    {
        hasClicked = true;
        errorBoxUI.SetActive(false);
    }

}
