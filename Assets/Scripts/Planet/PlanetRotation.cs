using UnityEngine;

public class PlanetRotation : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 50f;

    private void Update() {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }
}
