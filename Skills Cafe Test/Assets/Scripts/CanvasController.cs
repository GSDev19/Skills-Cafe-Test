using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance { get; private set; }

    [SerializeField] private CanvasGroup inGameCanvasGroup;
    [SerializeField] private CanvasGroup gameOvercanvasGroup;
    [SerializeField] private CanvasGroup resultsCanvasGroup;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
     
    public void ShowGameCanvasGroup()
    {
        SetCanvasGroup(inGameCanvasGroup, true);
        SetCanvasGroup(gameOvercanvasGroup, false);
        SetCanvasGroup(resultsCanvasGroup, false);
    }
    public void ShowGameOverCanvasGroup()
    {
        SetCanvasGroup(inGameCanvasGroup, true);
        SetCanvasGroup(gameOvercanvasGroup, true);
        SetCanvasGroup(resultsCanvasGroup, false);
    }
    public void ShowResultsCanvasGroup()
    {
        SetCanvasGroup(inGameCanvasGroup, false);
        SetCanvasGroup(gameOvercanvasGroup, false);
        SetCanvasGroup(resultsCanvasGroup, true);
    }
    public void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
    private void SetCanvasGroup(CanvasGroup canvasGroup, bool value)
    {
        if (value)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }
}
