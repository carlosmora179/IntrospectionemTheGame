using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirConLectura : MonoBehaviour
{
    [SerializeField]
    private DialogueManager[] listaPapeles;
    private bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && AllPaperReaded())
        {
            this.gameObject.SetActive(false);
            open = true;
        }
    }

    private bool AllPaperReaded()
    {
        foreach (DialogueManager puzzle in listaPapeles)
        {
            if (!puzzle.leido)
            {
                return false;
            }
        }

        return true;
    }
}
