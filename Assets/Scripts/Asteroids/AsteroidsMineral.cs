using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMineral : MonoBehaviour {

	/// <summary>
	/// mineral : The Mineral item contained.
	/// mineralCountProbability : range of probabilities to for itemCount
	/// eg : [0,10,30,90] : 10% 1, 20% 2, 60% 3, 10% 4 itemCount.
	/// mineralCount : the amount of minerals it contains.
	/// </summary>
	public int id;
	public float[] mineralCountProbability = new float[5];
	public int mineralCount;


	/// Sets mineralCount (number of minerals of the asteroid)
	void Start () {
		mineralCountProbability [0] = 0;
		mineralCountProbability [1] = 10;
		mineralCountProbability [2] = 30;
		mineralCountProbability [3] = 90;
		mineralCountProbability [4] = 100;

		float randomValue = (Random.value * 100);
		int i = 0;
		int n = mineralCountProbability.Length;
		while (randomValue > mineralCountProbability [i] && i < n - 1) {
			i++;
		}
		mineralCount = i;
	}
	

}
