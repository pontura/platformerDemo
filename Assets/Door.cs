using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public UIManager uiManager;

	void OnTriggerEnter2D(Collider2D other)
	{
		Character character = other.gameObject.GetComponent<Character> ();
		if (character != null) {
			uiManager.Win ();
		}
	}
}
