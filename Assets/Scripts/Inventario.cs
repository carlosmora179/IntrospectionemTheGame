using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour, IPointerClickHandler
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
    private GameObject canva;
    [SerializeField]
    private int capacidad;
    [SerializeField]
    private int selected;

    public void Start()
    {
        slotInfoList = new List<SlotInfo>();
        selected = -1;
        CreateInventory();
        CerrarInventario();
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

    public void AddItem(int id)
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

    public void removerItem(int itemId)
    {
        SlotInfo slotInfo = EncontrarItemInventario(itemId);
        if (slotInfo != null) 
        {
            slotInfo.EmptySlot();
            EncontrarSlot(slotInfo.id).UpdateUI();
        } 
    }

    public void AbrirInvantario()
    {
        canva.SetActive(true);
    }

    public void CerrarInventario()
    {
        canva.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Objeto")
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            selected = eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotInfo.idItem;
            CerrarInventario();
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotInfo.id);
            selected = 100;
            CerrarInventario();
        }
    }

    public int getSelected()
    {
        return selected;
    }

    public void UnSelected()
    {
        selected = -1;
    }
}
