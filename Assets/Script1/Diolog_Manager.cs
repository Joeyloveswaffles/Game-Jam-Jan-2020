﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diolog_Manager : MonoBehaviour
{
    public KeyCode nextdiologue;
    public GameObject diologueBox;
    public Text dialogeDisplay;
    public Text speakerDisplay;

    public float textAnimateSpeed;

    public AudioSource source;
    public AudioClip textAnimateClip;
    public AudioClip closeDiologSoundClip;


    public bool displaySentence;
    public bool sentenceFinished;

    public string currentrSentence;
    
    



    public Conversation currentConversation; // custom scriptable object
    //public Help_Notification helpNotification; // script
    [Header("Debug")]
    [Header("Debug")]
    public Queue<string> queue;
    public Queue<string> authorQueue; // queue array
    public string[] sentences;
    public string[] authors;
    
    public bool diolgueActive;
    public bool nextLetter;

     void Awake()
    {
        nextLetter = true;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        nextLetter = true;
        if (textAnimateSpeed < 0f)
        {
            textAnimateSpeed = 0.3f;
        }
        //helpNotification = gameObject.transform.parent.GetComponentInChildren<Help_Notification>();
        queue = new Queue<string>(0);
        authorQueue = new Queue<string>(0);

        sentences = currentConversation.sentences;
        authors = currentConversation.speaker;
        diolgueActive = false;

        if (nextdiologue == KeyCode.None)
        {
            nextdiologue = KeyCode.P;
        }
        if (sentences.Length > 0)
        {
            enqueSentences();
        }

       // helpNotification.sendHelpNotification("Press " + nextdiologue.ToString() + " to continue dialogue", nextdiologue);
    }

    // Update is called once per frame
    void Update()
    {
        listener();
        displaySentenceListener();

    }

    public void enqueSentences()
    {
        foreach (string s in sentences)
        {
            queue.Enqueue(s);
        }

        foreach (string s in  authors)
        {
            authorQueue.Enqueue(s);
        }

        

    }

    public void listener()
    {
        if (diologueBox.GetComponent<Canvas>().enabled)
        {
            diolgueActive = true;
        }

        if (diolgueActive)
        {
            listenForPayerConfirm();
            
        }
        else
        {
            disableDiologueBox();
        }

       

    }

    public void listenForPayerConfirm()
    {
        if (Input.GetKeyDown(nextdiologue))
        {
            if (queue.Count <= 0 && sentenceFinished == false)
            {
                
                StopAllCoroutines();
                source.Stop();
                sentenceFinished = true;
                dialogeDisplay.text = currentrSentence;

            }
            else if (sentenceFinished == false)
            {
                StopAllCoroutines();
                source.Stop();
                sentenceFinished = true;


                dialogeDisplay.text = currentrSentence;

            }
            else if (queue.Count == 0 && sentenceFinished == true)
            {
                disableDiologueBox();
            }
            else
            {
                StartCoroutine(displayNextSentence());

            }

        }
    }
    public void displaySentenceListener()
    {
        if (displaySentence)
        {
            StartCoroutine(displayNextSentence());
            displaySentence = false;
        }
    }

    public IEnumerator displayNextSentence()
    {
        speakerDisplay.text = authorQueue.Dequeue();
        dialogeDisplay.text = "";
        sentenceFinished = false;
        float seconds = textAnimateSpeed;
        if (queue.Count > 0)
        {
            nextLetter = true;
            char[] letters;
            string text = queue.Dequeue();
            currentrSentence = text;
            letters = text.ToCharArray();
            
            foreach (char letter in letters)
            {
                if (nextLetter)
                {
                    source.Stop();
                    dialogeDisplay.text += letter;
                    if (source.clip != textAnimateClip)
                    {
                        source.clip = textAnimateClip;
                        
                    }
                    source.Play();

                    // StartCoroutine(delay(1f, letter));
                    yield return new WaitForSeconds(seconds);

                    
                }
                else
                {
                    source.Stop();
                    yield return new WaitForSeconds(seconds);
                }
               
            }
            sentenceFinished = true;
            source.Stop();
            yield return new WaitForSeconds(0f);
        }
        else
        {
            yield return new WaitForSeconds(0f);
        }
        

        
    }

   

   

    public void activateDiologueBox()
    {

    }

    public void disableDiologueBox()
    {
        diolgueActive = false;
        

        if (diologueBox.GetComponent<Canvas>().enabled)
        {
            diologueBox.GetComponent<Canvas>().enabled = false;
            source.clip = closeDiologSoundClip;
            
            source.Play();
        }

    }
}
