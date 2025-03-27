using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 인벤토리 슬롯: 특정 아이템과 개수를 관리
/// </summary>
[System.Serializable]
public class UIInventorySlot : MonoBehaviour, IDropHandler
{
    private UIInventoryItem _currentItem;
    private int _quantity;

    public UIInventoryItem Item
    { 
        get { return _currentItem; } 
        set { _currentItem = value; } 
    }

    public UIInventorySlot(UIInventoryItem item, int quantity)
    {
        this._currentItem = item;
        this._quantity = quantity;
    }


    public void OnDrop(PointerEventData eventData)
    {
        UIInventoryItem item = eventData.pointerDrag.GetComponent<UIInventoryItem>();

        if (item != null)
        {
            // 슬롯이 비어 있으면 아이템을 추가
            if (transform.childCount == 0)
            {
                item.transform.SetParent(transform);
                item.transform.localPosition = Vector3.zero;
            }
            else
            {
                // 이미 아이템이 있으면 기존 아이템과 교체할 수도 있음 (추가 로직 필요)
            }
        }
    }

    /// <summary>
    /// 아이템 추가 시 최대 개수 초과 여부 확인
    /// </summary>
    //public bool CanAddMore(int amount) => (quantity + amount) <= item.maxStack;


    public bool IsEmpty()
    {
        return _currentItem == null;
    }

    public void RemoveItem()
    {
        _currentItem = null;
    }

}
