using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diolog_Manager : MonoBehaviour
{
    public KeyCode nextdiologue;
    public GameObject diologueBox;
    public Text dialogeDisplay;

    public Queue<string> queue; // queue array



    public Conversation currentConversation; // custom scriptable object
    //public Help_Notification helpNotification; // script

    [Header("Debug")]
    public string[] sentences;
    public string dialog;
    public bool diolgueActive;
    // Start is called before the first frame update
    void Start()
    {
        //helpNotification = gameObject.transform.parent.GetComponentInChildren<Help_Notification>();
        queue = new Queue<string>(0);

        sentences = currentConversation.sentences;
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

    }

    public void enqueSentences()
    {
        foreach (string s in sentences)
        {
            queue.Enqueue(s);
        }

        dialogeDisplay.text = queue.Dequeue();

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
            if (queue.Count <= 0)
            {
                disableDiologueBox();

            }
            else
            {
                dialogeDisplay.text = queue.Dequeue();

            }

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
        }

    }
}
