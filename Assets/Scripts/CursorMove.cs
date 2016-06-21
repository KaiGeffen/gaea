using UnityEngine;
using System.Collections;

public class CursorMove : MonoBehaviour
{

	private float speed = 1.0f;

	public void Setup ()
	{
		// Don't need to move to origin
	}

	void Update () {
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
	}
}
