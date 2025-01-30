using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTexts : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [TextArea(5, 50)] public string[] lines;
    public float textSpeed;

    private int index;

    public GameObject leaveButton;

    void Start()
    {
        leaveButton.SetActive(false);

        textComponent.text = string.Empty;
    }

    private void OnEnable()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if (textComponent.text == lines[index])
        {
            leaveButton.SetActive(true);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            leaveButton.SetActive(true);
        }
    }
}
