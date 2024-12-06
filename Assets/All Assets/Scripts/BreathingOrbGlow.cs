using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingOrbGlow : MonoBehaviour
{
    public Material orbMaterial;
    public float maxEmissionIntensity = 2f;
    public float minEmissionIntensity = 0.5f;
    public float transitionDuration = 4f;

    private float targetEmissionIntensity;
    private float currentEmissionIntensity;
    private float elapsedTime;

    void Start()
    {
        currentEmissionIntensity = minEmissionIntensity;
        targetEmissionIntensity = maxEmissionIntensity;
        StartBreathingCycle();
    }

    void Update()
    {
        if (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float newIntensity = Mathf.Lerp(currentEmissionIntensity, targetEmissionIntensity, elapsedTime / transitionDuration);
            orbMaterial.SetColor("_EmissionColor", orbMaterial.color * newIntensity);
        }
    }

    void StartBreathingCycle()
    {
        InvokeRepeating(nameof(TransitionToInhale), 0f, 8f);
        InvokeRepeating(nameof(TransitionToExhale), 4f, 8f);
    }

    void TransitionToInhale()
    {
        currentEmissionIntensity = orbMaterial.GetColor("_EmissionColor").maxColorComponent;
        targetEmissionIntensity = maxEmissionIntensity;
        elapsedTime = 0f;
    }

    void TransitionToExhale()
    {
        currentEmissionIntensity = orbMaterial.GetColor("_EmissionColor").maxColorComponent;
        targetEmissionIntensity = minEmissionIntensity;
        elapsedTime = 0f;
    }
}