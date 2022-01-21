using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotTemplate : MonoBehaviour
{
    [SerializeField] UI_Inventory ui;
    [SerializeField] PlayerController player;
    public int idItem;
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
                        
                        if(player.currentHealt < player.maxHealth)
                        {
                            item.amount -= 1;
                            if (player.maxHealth - player.currentHealt < item.recuperationHealth)
                            {
                                player.currentHealt = player.maxHealth;
                            }
                            else
                            {
                                player.currentHealt += item.recuperationHealth;
                            }
                        }
                        else
                        {
                            Debug.Log("Ya tienes la vida al maximo");
                        }
                    }
                    //objeto puede recuperar vida y solo tienes 1 en el inventario
                    else if(item.amount == 1 && item.recuperationHealth > 0)
                    {
                        if (player.currentHealt < player.maxHealth)
                        {
                            if (player.maxHealth - player.currentHealt > item.recuperationHealth)
                            {
                                player.currentHealt = player.maxHealth;
                            }
                            else
                            {
                                player.currentHealt += item.recuperationHealth;
                            }
                            ui.inventory.RemoveItem(item);
                        }
                        else
                        {
                            Debug.Log("Ya tienes la vida al maximo");
                        }

                    }
                    //Objetos que no pueden recuperar vida
                    else
                    {
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
                Debug.Log(item.getID());
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
}
