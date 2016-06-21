using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	public static Cursor instance = null;

	private CursorMove cursorMoveScript;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		// Instantiate the components
		cursorMoveScript = GetComponent<CursorMove> ();


		Init ();
	}

	void Init ()
	{
		cursorMoveScript.Setup ();
	}
}
