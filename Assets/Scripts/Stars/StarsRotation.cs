using UnityEngine;

public class StarsRotation : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 50f;

    void Update() {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
