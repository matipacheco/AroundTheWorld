using System.Collections;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [Header("Spawn Settings")]
    [SerializeField] private GameObject[] cloudPrefabs;
    [SerializeField] private Transform spawnPointReference;
    [SerializeField][Range(.5f, 5f)] private float minSpawnTime, maxSpawnTime;

    [Header("Cloud attributes")]
    [SerializeField][Range(1f, 3f)] private float minSpeed;
    [SerializeField][Range(1f, 3f)] private float  maxSpeed;
    [SerializeField][Range(0f, 10f)] private float minYPos, maxYPos;
    [SerializeField][Range(.1f, 1f)] private float minScale, maxScale;

    private void Start() {
        StartCoroutine(SpawnCloud());
    }

    private IEnumerator SpawnCloud() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            GameObject cloud = Instantiate(
                cloudPrefabs[Random.Range(0, cloudPrefabs.Length - 1)],
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(0, 90, 0)
            );

            float cloudYpos = Random.Range(minYPos, maxYPos);
            float cloudScale = Random.Range(minScale, maxScale);

            Vector3 cloudPosVector = new Vector3(0f, cloudYpos, 0f);
            Vector3 cloudScaleVector = new Vector3(cloudScale, cloudScale, cloudScale);

            cloud.transform.localScale = cloudScaleVector;
            cloud.transform.localPosition += cloudPosVector;

            float cloudSpeed = Random.Range(minSpeed, maxSpeed);
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.velocity  = new Vector3(cloudSpeed, 0f, 0f);
        }
    }
}
