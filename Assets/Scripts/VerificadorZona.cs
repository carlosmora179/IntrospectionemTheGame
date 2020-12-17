using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerificadorZona : MonoBehaviour
{
    public Dialogue dialogue;
    Queue<string> sentences;
    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;
    string activeSentence;
    private Player player;
    private float typingSpeed = 0.05f;

    private bool firstSentence = true;
    private bool readAllSentences = false;
    public GameObject[] listPuzzles;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        player = FindObjectOfType<Player>();
        FillSentences();
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

    // Update is called once per frame
    void Update()
    {
        //if (AllPuzzlesResolved())
        {
            if (firstSentence)
            {
                player.canMove = false;
                dialoguePanel.SetActive(true);
                DisplayNextSentence();
                firstSentence = false;
            }
            else
            {
                if (!readAllSentences)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        DisplayNextSentence();
                    }
                }
            }
        }
    }

    /**
    private bool AllPuzzlesResolved()
    {
        foreach (GameObject puzzle in listPuzzles)
        {
            if (!puzzle.GetComponent<ObjetoPuzzle>().resuelto)
            {
                return false;
            }
        }

        return true;
    }
    **/
}
