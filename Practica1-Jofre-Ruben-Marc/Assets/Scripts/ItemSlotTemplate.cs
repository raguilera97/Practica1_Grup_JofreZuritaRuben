using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotTemplate : MonoBehaviour
{
    [SerializeField] UI_Inventory ui;
    [SerializeField] PlayerController player;
    [SerializeField] BattleSystem batSys;
    [SerializeField] PlayerHUD pHUD;
    [SerializeField] GameObject combatPlayer;
    

    public int idItem;
    public Dialogue dialogueVM, dialogueONU;
    public void UseObject()
    {
        foreach (Item item in ui.inventory.GetItemList())
        {
            if(item.getID() == idItem)
            {
                //Objetos que se usan i no se equipan
                if (item.IsStackeable())
                {
                    //Objeto que hay mas de 1 en el inventario y que pueden recuperar vida
                    if(item.amount > 1 && item.recuperationHealth > 0)
                    {
                        
                        if(player.currentHealth < player.maxHealth)
                        {
                            item.amount -= 1;
                            if (player.maxHealth - player.currentHealth < item.recuperationHealth)
                            {
                                player.currentHealth = player.maxHealth;
                            }
                            else
                            {
                                player.currentHealth += item.recuperationHealth;
                            }
                            
                            pHUD.SetHP(combatPlayer.GetComponent<PlayerController>().currentHealth);
                        }
                        else
                        {
                            FindObjectOfType<DialogueManager>().StartDialogue(dialogueVM);
                 
                            Debug.Log("Ya tienes la vida al maximo");
                        }
                    }
                    //objeto puede recuperar vida y solo tienes 1 en el inventario
                    else if(item.amount == 1 && item.recuperationHealth > 0)
                    {
                        if (player.currentHealth < player.maxHealth)
                        {
                            if (player.maxHealth - player.currentHealth > item.recuperationHealth)
                            {
                                player.currentHealth = player.maxHealth;
                            }
                            else
                            {
                                player.currentHealth += item.recuperationHealth;
                            }
                            ui.inventory.RemoveItem(item);
                        }
                        else
                        {
                            FindObjectOfType<DialogueManager>().StartDialogue(dialogueVM);
                            Time.timeScale = 0;
                            Debug.Log("Ya tienes la vida al maximo");
                        }

                    }
                    //Objetos que no pueden recuperar vida
                    else
                    {
                        FindObjectOfType<DialogueManager>().StartDialogue(dialogueONU);
                        
                        Debug.Log("El objeto no puede usarse");
                    }
                    
                }
                //Objetos equipables
                else
                {
                    Debug.Log("Este objeto se equipa");
                }
                break;
            }
        }
        ui.RefreshInventoryItems();
    }

    public void DeleteItem()
    {
        foreach (Item item in ui.inventory.GetItemList())
        {
            if (item.getID() == idItem)
            {
                ui.inventory.RemoveItem(item);
                ui.RefreshInventoryItems();
                Destroy(this.gameObject);
                break;
            }
        }
    }

    public void PickUpObject()
    {
        foreach (Item item in ui.inventory.GetItemList())
        {
            if (item.getID() == idItem)
            {
                Item newItem = new Item { itemType = item.itemType, amount = item.amount };
                player.inventory.AddItem(newItem);
                ui.inventory.RemoveItem(item);
                ui.RefreshInventoryItems();
                Destroy(this.gameObject);
                break;
            }
        }
    }

    public void TryBuyItem()
    {
        int coins = 0;
        foreach (Item item in player.inventory.GetItemList())
        {
            if(item.itemType == Item.ItemType.coins)
            {
                coins = item.amount;
                break;
            }
        }

        foreach (Item item in ui.inventory.GetItemList())
        {
            if(item.getID() == idItem)
            {
                int cost = item.GetCost();

                if(cost <= coins && item.amount > 0)
                {
                    Item newItem = new Item { itemType = item.itemType, amount = 1 };
                    player.inventory.AddItem(newItem);
                    item.amount--;
                    ui.RefreshInventoryShopItems();
                    foreach (Item itemPlayer in player.inventory.GetItemList())
                    {
                        if (itemPlayer.itemType == Item.ItemType.coins)
                        {
                            if(itemPlayer.amount - cost == 0)
                            {
                                player.inventory.RemoveItem(itemPlayer);
                            }
                            else
                            {
                                itemPlayer.amount = itemPlayer.amount - cost;
                            }
                            break;
                        }
                    }
                    
                }
                else
                {
                    Debug.Log("No se puede comprar");
                }
            }
            
        }
    }

}
