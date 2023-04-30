using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject droppedItemPrefab;
    [SerializeField] private Image itemInHandIcon;
    //
    private Item _itemInHand;

    public Item ItemInHand
    {
        get { return _itemInHand; } 
        set 
        { 
            _itemInHand = value;
            if (_itemInHand != null)
            {
                itemInHandIcon.sprite = _itemInHand.IconSprite;
                itemInHandIcon.color = Color.white;
            }
            else
            {
                itemInHandIcon.sprite = null;
                itemInHandIcon.color = new Color(0, 0, 0, 0);
            }
        }
    }

    public void DropItem()
    {
        GameObject droppedItem = Instantiate(this.droppedItemPrefab, this.transform.position, this.transform.rotation);
        droppedItem.name = ItemInHand.Label;
        droppedItem.GetComponent<SpriteRenderer>().sprite = ItemInHand.IconSprite;
        ItemInHand = null;
    }

    /*[SerializeField] private Item testItem;

    private void Start()
    {
        ItemInHand = testItem;
        DropItem();
    }*/
}
