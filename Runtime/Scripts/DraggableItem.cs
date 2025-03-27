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
        canvasGroup.blocksRaycasts = false; // ���� ������ ���� Raycast ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // ���콺�� ���� �̵�
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // �ٽ� ���� �����ϵ��� ����

        // ���� ����� ���� ã��
        UIInventorySlot nearestSlot = FindNearestSlot(eventData);

        if (nearestSlot != null && nearestSlot.IsEmpty())
        {
            // �� ������ ������ �̵�
            MoveToSlot(nearestSlot);
        }
        else if (transform.parent == originalParent.root)
        {
            // ������ ������ ���� �ڸ��� �ǵ�����
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }

    private UIInventorySlot FindNearestSlot(PointerEventData eventData)
    {
        // ���콺 ��ġ���� ���� ����� ������ ã�� ����
        GameObject hoveredObject = eventData.pointerEnter;
        if (hoveredObject != null)
        {
            UIInventorySlot slot = hoveredObject.GetComponent<UIInventorySlot>();
            return slot;
        }
        return null;
    }

    protected virtual void MoveToSlot(UIInventorySlot newSlot)
    {
        if (currentSlot != null)
        {
            currentSlot.RemoveItem(); // ���� ���Կ��� ������ ����
        }

        currentSlot = newSlot;
        transform.SetParent(newSlot.transform); // ������ ���ο� �θ�� ����
        transform.localPosition = Vector3.zero; // ���� �߾� ����
    }
}
