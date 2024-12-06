using System.Collections;
using UnityEngine;

public class BreathingCompanionController : MonoBehaviour
{
    public AudioClip inhaleClip;
    public AudioClip exhaleClip;
    private AudioSource audioSource;
    private Animator animator;
    private Coroutine breathingCoroutine;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        breathingCoroutine = StartCoroutine(BreathingCycle());
    }

    private void OnDisable()
    {
        if (breathingCoroutine != null)
        {
            StopCoroutine(breathingCoroutine);
            breathingCoroutine = null;
        }
        ResetAnimation();
    }

    IEnumerator BreathingCycle()
    {
        while (true)
        {
            PlayInhale();
            yield return new WaitForSeconds(4f);

            PlayExhale();
            yield return new WaitForSeconds(4f);
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

    private void ResetAnimation()
    {
        animator.ResetTrigger("Inhale");
        animator.ResetTrigger("Exhale");
        animator.Play("Idle");
    }
}
