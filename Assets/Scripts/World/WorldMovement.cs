using UnityEngine;

public class WorldMovement : MonoBehaviour {
    [SerializeField] private float speed = 50f;

    private void Update() {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}