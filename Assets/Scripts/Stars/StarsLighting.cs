using UnityEngine;
using System.Collections;

public class StarsLighting : MonoBehaviour {
    private bool isDay;
    private SkyboxLighting mainCamera;

    [SerializeField] private Transform universeCenter;

    // Use this factor to make a softer or harder intensity change 
    [SerializeField] private float lerpFactor = 1f;

    [Header("Sun Settings")]
    [SerializeField] private Light sunLight;
    [SerializeField][Range(0f, 1f)] private float minSunLight = .5f;
    [SerializeField][Range(0f, 1f)] private float maxSunLight = 1f;

    [Header("Moon Settings")]
    [SerializeField] private Light moonLight;

    [SerializeField][Range(0f, 1f)] private float minMoonLight = 0.8f;
    [SerializeField][Range(0f, 1f)] private float maxMoonLight = 1f;

    private Gradient sunsetGradient;
    private Gradient dawnGradient;

    private void Start() {
        mainCamera = FindObjectOfType<SkyboxLighting>();

        sunLight.intensity  = maxSunLight;
        moonLight.intensity = minMoonLight;
    }

    private void Update() {
        SetIsDay();
    }

    private void OnTriggerEnter(Collider other) {
        if (isDay) {
            StartCoroutine(TriggerSunset());
            StartCoroutine(mainCamera.TriggerSunset());
        } else {
            StartCoroutine(TriggerDawn());
            StartCoroutine(mainCamera.TriggerDawn());
        }
    }

    private float Distance() {
        return transform.position.y - universeCenter.position.y;
    }

    public void SetIsDay() {
        isDay = (Distance() >= 0);
    }

    public bool GetIsDay() {
        return isDay;
    }

    private IEnumerator TriggerSunset() {
        do {
            // Reduce sun's light to its minimum
            // Increase moon's light to its maximum

            sunLight.intensity -= Time.deltaTime * lerpFactor;
            moonLight.intensity += Time.deltaTime * lerpFactor;

            yield return new WaitForSeconds(.1f);

        } while (sunLight.intensity > minSunLight);
    }

    private IEnumerator TriggerDawn() {
        do {
            // Increase sun's light to its maximum
            // Reduce moon's light to its minimum

            sunLight.intensity += Time.deltaTime * lerpFactor;
            moonLight.intensity -= Time.deltaTime * lerpFactor;

            yield return new WaitForSeconds(.1f);

        } while (sunLight.intensity < maxSunLight);
    }
}
