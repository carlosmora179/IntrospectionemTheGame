using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;
    private Player player;

    Queue<string> sentences;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

    string activeSentence;
    private float typingSpeed = 0.05f;

    private bool isEnter = false;

    public GameObject canvas;
    public bool leido = false;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        player = FindObjectOfType<Player>();
    }

    void FillSentences()
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";

        foreach (char leter in sentence.ToCharArray())
        {
            displayText.text += leter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void DisplayNextSentence()
    {
        if (sentences.Count > 0)
        {
            activeSentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine("TypeTheSentence", activeSentence);
        }
        else
        {
            dialoguePanel.SetActive(false);
            player.canMove = true;
            FillSentences();
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(true);
            FillSentences();
            isEnter = true;
        }
    }

    void Update()
    {
        if (isEnter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvas.SetActive(false);
                player.canMove = false;
                dialoguePanel.SetActive(true);
                DisplayNextSentence();
                leido = true;
                Debug.Log(leido);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(false);
            isEnter = false;
        }
    }
}
