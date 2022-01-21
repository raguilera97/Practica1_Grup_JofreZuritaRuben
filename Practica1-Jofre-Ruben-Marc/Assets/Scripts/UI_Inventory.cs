using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public Inventory inventory;
    private Transform scrollView;
    private Transform viewport;
    private Transform content;
    private Transform itemSlotTamplate;

    private void Awake()
    {
        scrollView = transform.Find("Scroll");
        viewport = scrollView.Find("Viewport");
        content = viewport.Find("Content");
        itemSlotTamplate = content.Find("ItemSlotTemplate");
        
        
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        foreach(Transform child in content){
            if (child == itemSlotTamplate) continue;
            Destroy(child.gameObject);
        }

        

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTamplate, content).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<ItemSlotTemplate>().idItem = item.getID();

            Image image =  itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            image.SetNativeSize();
            TextMeshProUGUI text = itemSlotRectTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            text.SetText(item.GetName());
            TextMeshProUGUI textAmount = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                textAmount.SetText(item.amount.ToString());
            }
            else
            {
                textAmount.SetText("");
            }
            
        }
    }
}
