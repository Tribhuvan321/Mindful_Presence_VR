using UnityEngine;

public class StopFunctions : MonoBehaviour
{
    public GameObject orbCanvas;
    public MeditationTextController mtcScript;
    public BreathingCompanionController bccScript;
    public Outline orbOutlineScript;

    public Animator orbAnimator;
    public Animator bookAnimator;
    public Outline bookOutlineScript;

    public GameObject bookCanvas;
    public GameObject keyboard;

    // Reference to the EmotionalJournal script
    public EmotionalJournal emotionalJournalScript;

    public void StopOrb()
    {
        orbOutlineScript.enabled = true;
        orbCanvas.SetActive(false);
        mtcScript.enabled = false;
        bccScript.enabled = false;
        orbAnimator.Play("Idle");
    }

    public void StopBook()
    {
        if (emotionalJournalScript != null)
        {
            emotionalJournalScript.SaveJournal();
        }

        bookOutlineScript.enabled = true;
        orbOutlineScript.enabled = true;
        bookAnimator.Play("Idle");
        bookCanvas.SetActive(false);
        keyboard.SetActive(false);
    }
}
