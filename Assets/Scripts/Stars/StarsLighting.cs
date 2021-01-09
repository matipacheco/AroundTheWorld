using UnityEngine;

public class StarsLighting : MonoBehaviour {
    private bool isDay;
    [SerializeField] private Transform universeCenter;
    [SerializeField] private Light sunLight;
    [SerializeField] private Light moonLight;

    private void Update() {
        SetIsDay();
        Debug.Log(isDay);
        

        // sunLight.gameObject.SetActive(isDay);
        // moonLight.gameObject.SetActive(!isDay);
    }

    private float Distance() {
        return transform.position.y - universeCenter.position.y;
    }

    public void SetIsDay() {
        isDay = (Distance() >= 0);
    }

    public bool IsDay() {
        return isDay;
    }

    private void TriggerDawn() {}
    private void TriggerSunset() {}
}
