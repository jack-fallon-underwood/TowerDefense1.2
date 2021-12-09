using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagButton : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// A reference to the bag item
    /// </summary>
    private Bag bag;

    /// <summary>
    /// Sprites to indicate if the bag is full or empty
    /// </summary>
    [SerializeField]
    private Sprite full, empty;

    /// <summary>
    /// A property for accessing the specific bag
    /// </summary>
    public Bag MyBag
    {
        get
        {
            return bag;
        }

        set
        {
            if (value != null)
            {
                GetComponent<Image>().sprite = full;
            }
            else
            {
                GetComponent<Image>().sprite = empty;
            }

            bag = value;
        }
    }

    /// <summary>
    /// if we click the specific bag button
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (bag != null)//If we have a bag equipped
        {
            //Open or close the bag
            bag.MyBagScript.OpenClose();
        }
    }
}
