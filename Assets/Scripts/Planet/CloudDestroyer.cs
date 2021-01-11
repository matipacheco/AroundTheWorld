using UnityEngine;

public class CloudDestroyer : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
