﻿using System.Collections;
using UnityEngine;

public class SkyboxLighting : MonoBehaviour {
    private Camera mainCamera;

    private float transitionStartTime;
    private const float transitionDuration = 10f;


    [Header("Skybox Settings")]
    // For some reason colors are not set on the field!
    [SerializeField] private Color dayColor; // = new Color(90f, 190f, 215f, 0f);
    [SerializeField] private Color sunsetColor; // = new Color(240f, 180f, 60f, 0f);
    [SerializeField] private Color nightColor; // = new Color(20f, 50f, 60f, 0f);
    [SerializeField] private Color dawnColor; // = new Color(220f, 220f, 120f, 0f);

    private Gradient sunsetGradient, dawnGradient;
    private GradientColorKey[] sunsetColorKey, dawnColorKey;
    private GradientAlphaKey[] sunsetAlphaKey, dawnAlphaKey;

    private void Start() {
        mainCamera = GetComponent<Camera>();
        mainCamera.backgroundColor = dayColor;

        // The goal is to change the camera's background color two times, on sunset and  on dawn.
        // Changes are: day -> sunset -> night  and  night -> dawn -> day
        // Gradients have to be un groups of three.

        sunsetGradient = new Gradient();
        sunsetGradient.SetKeys(SetSunsetColorKey(), SetAlphaKey());

        dawnGradient = new Gradient();
        dawnGradient.SetKeys(SetDawnColorKey(), SetAlphaKey());
    }

    private GradientColorKey[] SetSunsetColorKey() {
        GradientColorKey[] colorKey = new GradientColorKey[3];

        colorKey[0].color = dayColor;
        colorKey[0].time  = 0.0f;

        colorKey[1].color = sunsetColor;
        colorKey[1].time  = 0.5f;

        colorKey[2].color = nightColor;
        colorKey[2].time  = 1.0f;
        return colorKey;
    }

    private GradientColorKey[] SetDawnColorKey() {
        GradientColorKey[] colorKey = new GradientColorKey[3];

        colorKey[0].color = nightColor;
        colorKey[0].time  = 0.0f;

        colorKey[1].color = dawnColor;
        colorKey[1].time  = 0.5f;

        colorKey[2].color = dayColor;
        colorKey[2].time  = 1.0f;
        return colorKey;
    }

    private GradientAlphaKey[] SetAlphaKey() {
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[3];

        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time  = 0.0f;

        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time  = 0.5f;

        alphaKey[2].alpha = 1.0f;
        alphaKey[2].time  = 1.0f;
        return alphaKey;
    }

    public IEnumerator TriggerSunset() {
        transitionStartTime = Time.deltaTime;

        do {
            mainCamera.backgroundColor = sunsetGradient.Evaluate(Time.deltaTime - transitionStartTime / transitionDuration);
            yield return new WaitForSeconds(.1f);

        } while (mainCamera.backgroundColor != nightColor);
    }

    public IEnumerator TriggerDawn() {
        transitionStartTime = Time.deltaTime;

        do {
            mainCamera.backgroundColor = dawnGradient.Evaluate(Time.deltaTime - transitionStartTime / transitionDuration);
            yield return new WaitForSeconds(.1f);

        } while (mainCamera.backgroundColor != dayColor);
    }
}