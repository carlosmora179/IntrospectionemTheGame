using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerificadorZonaHermana : MonoBehaviour
{
    public Dialogue dialogue;
    Queue<string> sentences;
    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;
    string activeSentence;
    private Player player;
    private float typingSpeed = 0.05f;
    
    public GameObject[] listPuzzles;
    public GameObject canvas;
    public GameObject trofeo;
    public GameObject respawn;
    public GameObject proeta;
    public GameObject puerta;

    private bool readAllSentences = false;
    private bool setFirstPuzzle = true;
    private bool changeFirstSprite = true;
    private bool changeSecondSprite = true;
    private bool showDialogue = false;
    private bool isEnter = false;
    private bool mostrarTrofeo = true;
    public bool zonaResuelta = false;

    public Sprite sprite1;
    public Sprite sprite2;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        canvas.SetActive(false);
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
            readAllSentences = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (showDialogue)
            {
                canvas.SetActive(true);
                FillSentences();
                isEnter = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (showDialogue)
            {
                canvas.SetActive(false);
                isEnter = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PuzzlesResolved() == 1 && setFirstPuzzle)
        {
            setFirstPuzzle = false;
            Instantiate(proeta, respawn.transform.position, Quaternion.identity);
        }
        if (PuzzlesResolved() == 2 && changeFirstSprite)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprite1;
            Instantiate(proeta, respawn.transform.position, Quaternion.identity);
            changeFirstSprite = false;
            
        }
        if (PuzzlesResolved() == 3 && changeSecondSprite)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = sprite2;
            changeSecondSprite = false;
            showDialogue = true;
        }
        if (showDialogue)
        {
            if (isEnter)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canvas.SetActive(false);
                    player.canMove = false;
                    dialoguePanel.SetActive(true);
                    DisplayNextSentence();
                }
            }
        }
        if (readAllSentences && mostrarTrofeo)
        {
            trofeo.gameObject.SetActive(true);
            zonaResuelta = true;
            mostrarTrofeo = false;
        }
        if (zonaResuelta)
        {
            //puerta.SetActive(false);
            zonaResuelta = false;
        }

    }

    private int PuzzlesResolved()
    {
        int count = 0;

        foreach (GameObject puzzle in listPuzzles)
        {
            if (puzzle.GetComponent<ObjetoPuzzle>().resuelto)
            {
                count += 1;
            }
        }

        return count;
    }
}
