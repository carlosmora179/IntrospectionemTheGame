using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventario/Datos")]
public class DataBase : ScriptableObject
{
    public List<Item> items = new List<Item>();
    public Item EncontrarItem(int id) 
    {
        foreach (Item item in items)
        {
            if (item.id == id) 
            {
                return item;
            }
        }
        return null;
    }
}

[System.Serializable]
public class Item
{
    public int id;
    public string nombre;
    public Sprite image;
    [TextArea(5,5)]
    public string descripcion;
}
