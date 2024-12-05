using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingCompanionController : MonoBehaviour
{
    public AudioClip inhaleClip;
    public AudioClip exhaleClip;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        StartCoroutine(BreathingCycle());
    }

    IEnumerator BreathingCycle()
    {
        while (true)
        {
            // Inhale Phase
            PlayInhale();
            yield return new WaitForSeconds(4f); // Wait for 4 seconds (duration of inhale)

            // Exhale Phase
            PlayExhale();
            yield return new WaitForSeconds(4f); // Wait for 4 seconds (duration of exhale)
        }
    }

    void PlayInhale()
    {
        animator.SetTrigger("Inhale");
        audioSource.clip = inhaleClip;
        audioSource.Play();
    }

    void PlayExhale()
    {
        audioSource.clip = exhaleClip;
        audioSource.Play();
        animator.SetTrigger("Exhale");
    }
}
