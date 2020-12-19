using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasaFinal : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private int keyId;
    [SerializeField]
    private Collider2D collider;
    [SerializeField]
    private Text text;

    [SerializeField]
    private GameObject creditos;

    private bool isEnter = false;
    private bool isOpen = false;
    private Player player;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (isEnter && Input.GetKey(KeyCode.E) && !isOpen)
            {
                isOpen = true;
                canvas.SetActive(false);
                player.canMove = false;
                player.AbrirInventario();
            }
            int idItem = player.inventario.GetComponentInChildren<Inventario>().getSelected();
            if (idItem != -1)
            {
                player.canMove = true;
                if (idItem == keyId)
                {
                    player.inventario.GetComponentInChildren<Inventario>().UnSelected();
                    player.inventario.GetComponentInChildren<Inventario>().removerItem(keyId);
                    player = null;
                    canvas.gameObject.SetActive(false);
                    collider.enabled = false;
                    //Cambiar scena aqui
                    creditos.GetComponent<Level1Loader>().LoadLevel1();
                }
                else
                {
                    StartCoroutine("WaitSeconds");
                    player.inventario.GetComponentInChildren<Inventario>().UnSelected();
                }
                isOpen = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.text = "[E] Resolver";
            canvas.SetActive(true);
            isEnter = true;
            player = collision.GetComponent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            canvas.SetActive(false);
            isEnter = false;
            player = null;
        }
    }

    IEnumerator WaitSeconds()
    {
        text.text = "Equivocado";
        canvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
    }
}
