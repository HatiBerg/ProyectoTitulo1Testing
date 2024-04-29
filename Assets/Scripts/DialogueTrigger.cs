using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    [SerializeField] private GameObject actionMark;

    private bool isPlayerInRange;

    private void Start()
    {
        actionMark.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueRunner.StartDialogue("Soldier");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            actionMark.SetActive(true);
            Debug.Log("Di�logo disponible");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            actionMark.SetActive(false);
            Debug.Log("Di�logo no disponible");
        }
    }
}
