using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour {

	public GameObject[] asteroids; 
	private Vector3 origin = Vector3.zero;

	/// <summary>
	/// The minimum and maximum allowed size of an asteroid.
	/// </summary>
	public float minSize = 0.2f;
	public float maxSize = 1.5f;

	/// <summary>
	/// The minimum and maximum amount of asteroids.
	/// </summary>
	public int minCount = 500;
	public int maxCount = 1200;

	/// <summary>
	/// The minimum and maximum distance between asteroids.
	/// </summary>
	public float minDistance = 30.0f;
	public float maxDistance = 150.0f;
	 void Start () {
		origin = transform.position;
		GenerateAsteroids(Random.Range(minCount, maxCount));
	}

	/// <summary>
	/// Generates a number (asteroidsCount) of asteroids with a random size between minSize and 
	/// maxSize and a random distance between them from minDistance to maxDistance.
	/// </summary>
	/// <param name="asteroidsCount">Number of Asteroids to Generate</param>
	public void GenerateAsteroids (int asteroidsCount) {
		for (int i = 0; i < asteroidsCount; i++) {
			float size = Random.Range(minSize, maxSize);
			GameObject prefab = asteroids[Random.Range(0, asteroids.Length)];
			Vector3 position = Vector3.zero;

			for (int j = 0; j < 100; j++) {
				 position = Random.insideUnitSphere * (minDistance + (maxDistance - minDistance) * Random.value);
				position += origin;
				if (!Physics.CheckSphere(position, size / 2.0f)) {
					break;
				}
			}
			GameObject go = Instantiate(prefab, position, Random.rotation);
			go.transform.localScale = new Vector3(size, size, size);
		}
	}


}
