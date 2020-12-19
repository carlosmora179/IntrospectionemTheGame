using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarFinal : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dm;
    [SerializeField]
    private GameObject casaJuguete;
    private bool activated = false;

    // Update is called once per frame
    void Update()
    {
        if(!activated && dm.leido)
        {
            activated = true;
            casaJuguete.gameObject.SetActive(true);
        }
    }
}
