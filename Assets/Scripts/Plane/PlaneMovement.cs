using System;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {

    // Plane movement theory 👇🏾
    // http://elektromot.com/how-to-control-an-aircraft/
    [SerializeField] private float rollFactor = 20f;
    [SerializeField] private float xMovementSpeed = 15f;
    [SerializeField] private float xMovementRange = 10f;

    private float xThrow;

    void Update() {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation() {
        xThrow = Input.GetAxis("Horizontal");

        float xOffset = xThrow * xMovementSpeed * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xMovementRange, xMovementRange);

        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void ProcessRotation() {
        float pitch = transform.localPosition.y;
        float yaw   = transform.localPosition.x;
        float roll  = xThrow * rollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
