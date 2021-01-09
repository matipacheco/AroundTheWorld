using UnityEngine;

public class StarsLighting : MonoBehaviour {
    private bool isDay;
    private Camera mainCamera;

    [SerializeField] private Light sunLight;
    [SerializeField] private Light moonLight;
    [SerializeField] private Transform universeCenter;

    private void Start() {
        mainCamera = GetComponent<Camera>();
    }

    private void Update() {
        SetIsDay();

        sunLight.gameObject.SetActive(isDay);
        moonLight.gameObject.SetActive(!isDay);
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

    private void TriggerDawn() {}
    private void TriggerSunset() {}
}
