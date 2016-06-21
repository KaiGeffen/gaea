using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;

		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 8;
	public int rows = 8;

	public GameObject[] floorTiles;
	public GameObject[] playerTiles;
	public GameObject[] enemyTiles;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List<Vector3>();

	void InitialiseList ()
	{
		gridPositions.Clear ();
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				gridPositions.Add(new Vector3(x,y,0f));
			}
		}
	}

	void BoardSetup ()
	{
		boardHolder = new GameObject ("Board").transform;

		// BACKGROUND TILES
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				GameObject toInstantiate = floorTiles[Random.Range (0, floorTiles.Length)];
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;

				instance.transform.SetParent (boardHolder);
			}
		}
	}

	// NOTE(kgeffen) This code was mostly copied, I don't like that this method removes from list
	// should be done elsewhere to avoid confusion
	Vector3 RandomPosition ()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);

		return randomPosition;
	}

	// accepts and array of game objects to choose from along with a miniumu and maximum
	// range for the number of objects to create.
	void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
	{
		// Number of objects to create
		int objectCount = Random.Range (minimum, maximum);

		for (int i = 0; i < objectCount; i++)
		{
			Vector3 randomPosition = RandomPosition ();
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPosition, Quaternion.identity);
		}
	}

	public void SetupScene () {
		BoardSetup ();

		InitialiseList ();

		// TODO(kgeffen) unnammed constants tho
		LayoutObjectAtRandom (enemyTiles, 1, 3);

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
