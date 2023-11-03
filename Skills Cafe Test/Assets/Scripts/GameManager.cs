using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int correctActionScore;
    private int totalScore;
    private CardController m_currentCard;

    public bool isOverBucket;

    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardsParent;
    [SerializeField] private List<GameObject> cardsGameObjects = new List<GameObject>();

    private int totalCards;
    private int cardsCount;
    public bool gameIsOver = false;


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
    private void Start()
    {
        SetGame();
    } 
    private void CreateCards()
    {
        totalCards = 0;
        cardsGameObjects = new List<GameObject>();

        for (int i = gameData.actionsCardOrder.Count - 1; i >= 0; i--)
        {
            ActionType currentAction = gameData.actionsCardOrder[i];

            GameObject newCard = Instantiate(cardPrefab, cardsParent);
            cardsGameObjects.Add(newCard);
            newCard.transform.SetParent(cardsParent);
            newCard.GetComponent<CardController>().SetCard(currentAction);
            totalCards++;
        }
    }
    public void CheckActionTypeMatch(ActionType bucketAction, BucketController bucket)
    {
        if(m_currentCard != null)
        {
            bucket.SetNotification();
            AudioController.Instance.PlayCardSound();
            if (m_currentCard.GetActionType() == bucketAction)
            {
                totalScore += correctActionScore;                
            }
            m_currentCard.gameObject.SetActive(false);
            cardsCount++;

            gameIsOver = CheckIfGameIsOver();

            if(gameIsOver)
            {                
                CanvasController.Instance.SetScoreText(totalScore);
                CanvasController.Instance.ShowGameOverCanvasGroup();
            }
        }
    }
    private bool CheckIfGameIsOver()
    {
        if(cardsCount == totalCards)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetGame()
    {
        gameIsOver = false;

        foreach (var item in cardsGameObjects)
        {
            if(item != null)
            {
                Destroy(item.gameObject);
            }
        }
        correctActionScore = gameData.correctActionScore;
        cardsCount = 0;
        m_currentCard = null;
        totalScore = 0;

        CreateCards();
        CanvasController.Instance.ShowGameCanvasGroup();


    }
    public void SetCurrentCard(CardController cardController)
    {
        m_currentCard = cardController;
    }
}
public enum ActionType
{
    Keep,
    Discard
}

