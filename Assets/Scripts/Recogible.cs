using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recogible : MonoBehaviour
{
    public GameObject canvas;
    public int itemId;
    private Player player;

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.inTrigger && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Precione");
            player.canMove = true;
            player.inTrigger = false;
            player.inventario.GetComponentInChildren<Inventario>().AddItem(itemId);
            player.inventario.gameObject.SetActive(true);
            Destruir();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(true);
        player = collision.GetComponent<Player>();
        player.inTrigger = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
        collision.GetComponent<Player>().inTrigger = false;
        player = null;
    }

    private void Destruir()
    {
        Destroy(this.gameObject);
    }
}
