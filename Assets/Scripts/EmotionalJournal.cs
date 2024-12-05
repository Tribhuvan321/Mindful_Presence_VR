using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalController : MonoBehaviour
{
    public GameObject journalPanel;          // The UI panel for the journal
    public TMP_InputField journalInputField;     // The input field for typing
    public TMP_Text journalTextBox;             // The Text box to reflect InputField content in real-time
    private string journalContent = "";      // Variable to store the content

    void Start()
    {
        CloseJournal();                     // Start with the journal closed
        LoadJournal();                      // Load saved content if available

        // Listen for changes in the InputField
        journalInputField.onValueChanged.AddListener(UpdateTextBox);
    }

    public void OpenJournal()
    {
        journalPanel.SetActive(true);       // Display the journal panel
    }

    public void CloseJournal()
    {
        journalPanel.SetActive(false);      // Hide the journal panel
        SaveJournal();                      // Save the content when closing
    }

    private void SaveJournal()
    {
        journalContent = journalInputField.text; // Save current InputField text
        PlayerPrefs.SetString("JournalContent", journalContent); // Save using PlayerPrefs
        PlayerPrefs.Save();
        Debug.Log("Journal saved: " + journalContent);
    }

    public void LoadJournal()
    {
        if (PlayerPrefs.HasKey("JournalContent"))
        {
            journalContent = PlayerPrefs.GetString("JournalContent");
            journalInputField.text = journalContent;
            journalTextBox.text = journalContent; // Update the TextBox with saved content
        }
    }

    private void UpdateTextBox(string newText)
    {
        journalTextBox.text = newText; // Update the TextBox as the InputField changes
    }
}
