using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField]
    private DataBase dataBase;
    [SerializeField]
    private GameObject slotPreFab;
    [SerializeField]
    private Transform panelInventario;
    [SerializeField]
    private List<SlotInfo> slotInfoList;
    [SerializeField]
    private int capacidad;

    private string jsonString; //Para guardar el inventario

    public void Start()
    {
        slotInfoList = new List<SlotInfo>();
        CreateInventory();
    }

    private void CreateInventory()
    {
        for (int i = 0; i < capacidad; i++)
        {
            GameObject slot = Instantiate<GameObject>(slotPreFab, panelInventario);
            Slot newSlot = slot.GetComponent<Slot>();
            newSlot.Iniciar(i);
            newSlot.dataBase = dataBase;
            SlotInfo newSlotInfo = newSlot.slotInfo;
            slotInfoList.Add(newSlotInfo);
        }
    }

    private SlotInfo EncontrarSlotVacio() 
    {
        foreach(SlotInfo slotInfo in slotInfoList)
        {
            if(slotInfo.isEmpty)
            {
                slotInfo.EmptySlot();
                return slotInfo;
            }
        }
        return null;
    }

    private Slot EncontrarSlot(int id)
    {
        return panelInventario.GetChild(id).GetComponent<Slot>();
    }

    private SlotInfo EncontrarItemInventario(int itemId)
    {
        foreach (SlotInfo slotInfo in slotInfoList)
        {
            if (slotInfo.idItem == itemId && !slotInfo.isEmpty)
            {
                return slotInfo;
            }
        }
        return null;
    }

    private void AddItem(int id)
    {
        Item item = dataBase.EncontrarItem(id); //Buscarlo
        if (item != null)
        {
            SlotInfo slotInfo = EncontrarSlotVacio(); // Buscar campo para meterlo
            if (slotInfo != null)
            {
                slotInfo.idItem = id;
                slotInfo.isEmpty = false;
                EncontrarSlot(slotInfo.id).UpdateUI();
            }
        }
    }

    private void removerItem(int itemId)
    {
        SlotInfo slotInfo = EncontrarItemInventario(itemId);
        if (slotInfo != null) 
        {
            slotInfo.EmptySlot();
            EncontrarSlot(slotInfo.id).UpdateUI();
        } 
    }
}
