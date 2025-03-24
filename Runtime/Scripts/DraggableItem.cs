using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private Canvas canvas;
    private UIInventorySlot currentSlot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(originalParent.root);
        canvasGroup.blocksRaycasts = false; // 슬롯 감지를 위해 Raycast 차단
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // 마우스를 따라 이동
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // 다시 감지 가능하도록 변경

        // 가장 가까운 슬롯 찾기
        UIInventorySlot nearestSlot = FindNearestSlot(eventData);

        if (nearestSlot != null && nearestSlot.IsEmpty())
        {
            // 빈 슬롯이 있으면 이동
            MoveToSlot(nearestSlot);
        }
        else if (transform.parent == originalParent.root)
        {
            // 슬롯이 없으면 원래 자리로 되돌리기
            ResetPosition();
        }
    }

    private UIInventorySlot FindNearestSlot(PointerEventData eventData)
    {
        // 마우스 위치에서 가장 가까운 슬롯을 찾는 로직
        GameObject hoveredObject = eventData.pointerEnter;
        if (hoveredObject != null)
        {
            UIInventorySlot slot = hoveredObject.GetComponent<UIInventorySlot>();
            return slot;
        }
        return null;
    }

    private void MoveToSlot(UIInventorySlot newSlot)
    {
        if (currentSlot != null)
        {
            currentSlot.RemoveItem(); // 기존 슬롯에서 아이템 제거
        }

        currentSlot = newSlot;
        transform.SetParent(newSlot.transform); // 슬롯을 새로운 부모로 설정
        transform.localPosition = Vector3.zero; // 슬롯 중앙 정렬

        newSlot.SetItem(this); // 새로운 슬롯에 아이템 등록
    }

    private void ResetPosition()
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }
}
