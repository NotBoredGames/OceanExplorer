using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogText;

    public Animator animator;
    public Animator animator2;
    public Animator animator3;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("isOpen", true);
        animator2.SetBool("isOpen", true);
        animator3.SetBool("isOpen", true);
        Debug.Log("Hello");
        nameText.text = dialog.name;
        sentences.Clear();
        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }
    void EndDialog()
    {
        animator.SetBool("isOpen", false);
        animator2.SetBool("isOpen", false);
        animator3.SetBool("isOpen", false);
    }

    
}
