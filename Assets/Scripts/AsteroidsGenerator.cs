using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour {

	public GameObject[] asteroids; 
	private Vector3 origin = Vector3.zero;

	private float minSize = 0.2f;
	private float maxSize = 1.5f;

	private int minCount = 500;
	private int maxCount = 1200;

	private float minDistance = 30.0f;
	private float maxDistance = 150.0f;

	/// <summary>
	/// Start this instance.
	/// </summary>
	 void Start () {
		origin = transform.position;
		GenerateAsteroids(Random.Range(minCount, maxCount));
	}

	/// <summary>
	/// Generates the asteroids.
	/// </summary>
	/// <param name="asteroidsCount">Asteroids count.</param>
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
