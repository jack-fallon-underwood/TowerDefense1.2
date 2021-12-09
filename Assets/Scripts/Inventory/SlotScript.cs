using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour, IPointerClickHandler, IClickable
{
    /// <summary>
    /// A stack for all items on this slot
    /// </summary>
    private ObservableStack<Item> items = new ObservableStack<Item>();

    //A a reference to the slot's icon
    [SerializeField]
    private Image icon;

    [SerializeField]
    private Text stackSize;

    /// <summary>
    /// Checks if the item is empty
    /// </summary>
    public bool IsEmpty
    {
        get
        {
            return items.Count == 0;
        }
    }

    /// <summary>
    /// Indicates if the slot is full
    /// </summary>
    public bool IsFull
    {
        get
        {
            if (IsEmpty || MyCount < MyItem.MyStackSize)
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// The current item on the slot
    /// </summary>
    public Item MyItem
    {
        get
        {
            if (!IsEmpty)
            {
                return items.Peek();
            }

            return null;
        }
    }

    /// <summary>
    /// The icon on the slot
    /// </summary>
    public Image MyIcon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    /// <summary>
    /// The item count on the slot
    /// </summary>
    public int MyCount
    {
        get {return items.Count; }
    }

    /// <summary>
    /// The stack text
    /// </summary>
    public Text MyStackText
    {
        get
        {
           return stackSize;
        }
    }

    private void Awake()
    {
        //Assigns all the event on our observable stack to the updateSlot function
        items.OnPop += new UpdateStackEvent(UpdateSlot);
        items.OnPush += new UpdateStackEvent(UpdateSlot);
        items.OnClear += new UpdateStackEvent(UpdateSlot);
    }

    /// <summary>
    /// Whem the slot is clicked
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (InventoryScript.MyInstance.FromSlot == null && !IsEmpty) //If we don't have something to move
            {
                HandScript.MyInstance.TakeMoveable(MyItem as IMoveable);
                InventoryScript.MyInstance.FromSlot = this;
            }
            else if (InventoryScript.MyInstance.FromSlot != null)//If we have something to move
            {
                //We will try to do diffrent things to place the item back into the inventory
                if (PutItemBack() || SwapItems(InventoryScript.MyInstance.FromSlot) ||AddItems(InventoryScript.MyInstance.FromSlot.items))
                {
                    HandScript.MyInstance.Drop();
                    InventoryScript.MyInstance.FromSlot = null;
                }
            }
      
        }
        if (eventData.button == PointerEventData.InputButton.Right)//If we rightclick on the slot
        {
            UseItem();
        }
    }

    /// <summary>
    /// Adds an item to the slot
    /// </summary>
    /// <param name="item">the item to add</param>
    /// <returns>returns true if the item was added</returns>
    public bool AddItem(Item item)
    {
        items.Push(item);
        icon.sprite = item.MyIcon;
        icon.color = Color.white;
        item.MySlot = this;
        return true;
    }

    /// <summary>
    /// Adds a stack of items to the slot
    /// </summary>
    /// <param name="newItems">stack to add</param>
    /// <returns></returns>
    public bool AddItems(ObservableStack<Item> newItems)
    {
        if (IsEmpty || newItems.Peek().GetType() == MyItem.GetType())
        {
            int count = newItems.Count;

            for (int i = 0; i < count; i++)
            {
                if (IsFull)
                {
                    return false;
                }

                AddItem(newItems.Pop());
            }

            return true;
        }

        return false;
    }

    /// <summary>
    /// Removes the item from the slot
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(Item item)
    {
        if (!IsEmpty)
        {
            items.Pop();
        }
    }

    /// <summary>
    /// Uses the item if it is useable
    /// </summary>
    public void UseItem()
    {
        if (MyItem is IUseable)
        {
            (MyItem as IUseable).Use();
        }
      
    }

    /// <summary>
    /// Stacks two items
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool StackItem(Item item)
    {
        if (!IsEmpty && item.name == MyItem.name && items.Count < MyItem.MyStackSize)
        {
            items.Push(item);
            item.MySlot = this;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Puts the item back in the inventory
    /// </summary>
    /// <returns></returns>
    private bool PutItemBack()
    {
        if (InventoryScript.MyInstance.FromSlot == this)
        {
            InventoryScript.MyInstance.FromSlot.MyIcon.color = Color.white;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Swaps two items in the inventory
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    private bool SwapItems(SlotScript from)
    {
        if (IsEmpty)
        {
            return false;
        }
        if (from.MyItem.GetType() != MyItem.GetType() || from.MyCount+MyCount > MyItem.MyStackSize)
        {
            //Copy all the items we need to swap from A
            ObservableStack<Item> tmpFrom = new ObservableStack<Item>(from.items);

            //Clear Slot a
            from.items.Clear();
            //All items from slot b and copy them into A
            from.AddItems(items);

            //Clear B
            items.Clear();
            //Move the items from ACopy to B
            AddItems(tmpFrom);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Updates the the slot
    /// </summary>
    private void UpdateSlot()
    {
        UIManager.MyInstance.UpdateStackSize(this);
    }
}
