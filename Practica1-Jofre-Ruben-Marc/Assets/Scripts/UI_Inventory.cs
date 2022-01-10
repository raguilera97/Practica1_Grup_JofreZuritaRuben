using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
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

    private void RefreshInventoryItems()
    {

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTamplate, content).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            Image image =  itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            image.SetNativeSize();
            TextMeshProUGUI text = itemSlotRectTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            text.SetText(item.GetName());
        }
    }
}
