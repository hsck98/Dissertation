using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

    //just variables and information that form each item
    public string itemName;
    public int itemID;
    public int itemCost;
    public string itemDescription;
    public Texture2D itemIcon;
    public float power;
    public float armor;
    public float extraHealth;
    public float extraMana;

    //contructor for item object
    public Item(string itemName, int itemID, int itemCost, string itemDescription, float power, float armor, float extraHealth, float extraMana)
    {
        this.itemName = itemName;
        this.itemID = itemID;
        this.itemCost = itemCost;
        this.itemDescription = itemDescription;
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + itemName);
        Debug.Log(itemIcon.name);
        this.power = power;
        this.armor = armor;
        this.extraHealth = extraHealth;
        this.extraMana = extraMana;
    }

    //emtpy constructor
    public Item()
    {
    }

}
