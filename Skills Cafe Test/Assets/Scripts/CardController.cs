using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private CanvasGroup m_CanvasGroup;
    private ActionType m_Action;
    private Vector3 originalPosition;

    private void Awake()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
        originalPosition = transform.position;
    }
    public void SetCard(ActionType action)
    {
        //GetComponent<Image>().color = new Color(Random.value, Random.value, Random.value, 1f);
        m_Action = action;
    }
    public ActionType GetActionType() { return m_Action; }

    #region DRAG AND DROP
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!GameManager.Instance.gameIsOver)
        {
            m_CanvasGroup.alpha = 0.5f;
            m_CanvasGroup.blocksRaycasts = false;

            GameManager.Instance.SetCurrentCard(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.gameIsOver)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_CanvasGroup.alpha = 1f;
        m_CanvasGroup.blocksRaycasts = true;

        GameManager.Instance.SetCurrentCard(null);
        if(!GameManager.Instance.isOverBucket)
        {
            transform.position = originalPosition;
        }
    }
    #endregion
}
