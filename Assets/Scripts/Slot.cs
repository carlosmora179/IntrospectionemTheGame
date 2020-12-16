using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public SlotInfo slotInfo;
    public DataBase dataBase;
    public GameObject image;

    public void Iniciar(int id)
    {
        slotInfo = new SlotInfo();
        slotInfo.id = id;
        slotInfo.EmptySlot();
    }

    public void UpdateUI()
    {
        if (slotInfo.isEmpty)
        {
            image.GetComponent<Image>().sprite = null;
            image.gameObject.SetActive(false);
        }
        else
        {
            image.GetComponent<Image>().sprite = dataBase.EncontrarItem(slotInfo.idItem).image;
            image.gameObject.SetActive(true);
        }
    }
}

[System.Serializable]
public class SlotInfo
{
    public int id;
    public bool isEmpty;
    public int idItem;

    public void EmptySlot()
    {
        isEmpty = true;
        idItem = -1;
    }
}