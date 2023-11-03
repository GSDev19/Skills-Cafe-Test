using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BucketController : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ActionType m_Action;
    [SerializeField] private GameObject m_TextNotification;
    private void Awake()
    {
        m_TextNotification.SetActive(false);
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameManager.Instance.CheckActionTypeMatch(m_Action, this);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.isOverBucket = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.isOverBucket = false;
    }

    public void SetNotification()
    {
        StartCoroutine(ShowNotification());
    }
    IEnumerator ShowNotification()
    {
        m_TextNotification.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        m_TextNotification.SetActive(false);
    }
}
