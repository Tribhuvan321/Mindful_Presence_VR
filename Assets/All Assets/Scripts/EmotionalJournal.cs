using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class EmotionalJournal : MonoBehaviour
{
    public TMP_InputField journalInputField;
    public TMP_Text journalTextBox;
    private string journalContent = "";

    void Start()
    {
        LoadJournal();
        if (journalInputField != null)
        {
            journalInputField.onValueChanged.AddListener(UpdateTextBox);
        }
    }

    public void SaveJournal()
    {
        if (journalInputField != null)
        {
            journalContent = journalInputField.text;
            PlayerPrefs.SetString("JournalContent", journalContent);
            PlayerPrefs.Save();
            Debug.Log("Journal saved: " + journalContent);
        }
    }

    public void LoadJournal()
    {
        if (PlayerPrefs.HasKey("JournalContent"))
        {
            journalContent = PlayerPrefs.GetString("JournalContent");
            if (journalInputField != null)
            {
                journalInputField.text = journalContent;
                StartCoroutine(SetCaretToEnd()); // Delay setting caret position
            }
            if (journalTextBox != null)
            {
                journalTextBox.text = journalContent;
            }
        }
        else
        {
            Debug.Log("No saved journal content found.");
        }
    }

    private IEnumerator SetCaretToEnd()
    {
        // Wait until the InputField is initialized and active in the scene
        while (!journalInputField.isActiveAndEnabled || journalInputField.textComponent == null)
        {
            yield return null; // Wait for the next frame
        }

        // Ensure the caret position is safely updated after initialization
        yield return null; // Additional frame wait for safety
        journalInputField.caretPosition = journalInputField.text.Length;
    }




    private void UpdateTextBox(string newText)
    {
        if (journalTextBox != null)
        {
            journalTextBox.text = newText;
        }
    }
    public void ClearJournal()
    {
        journalContent = "";
        if (journalInputField != null)
        {
            journalInputField.text = "";
        }
        if (journalTextBox != null)
        {
            journalTextBox.text = "";
        }
        Debug.Log("Journal cleared.");
    }
}
