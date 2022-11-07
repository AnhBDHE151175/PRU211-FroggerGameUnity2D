using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public Asteroid asteroidPrefab;
    public float spawnDistance = 12f;
    public float spawnRate = 1f;
    public int amountPerSpawn = 1;
    [Range(0f, 45f)]
    public float trajectoryVariance = 15f;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);

    }

    public void Spawn()
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            Vector3 spawnPoint = Random.insideUnitCircle.normalized * spawnDistance;


            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            Vector2 trajectory = rotation * -Random.insideUnitCircle.normalized;
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);


            asteroid.SetTrajectory(trajectory);
        }
    }
}
