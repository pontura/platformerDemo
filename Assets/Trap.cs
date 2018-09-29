using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public UIManager uiManager;

	void OnTriggerEnter2D(Collider2D other)
	{
		Character character = other.gameObject.GetComponent<Character> ();
		if (character != null) {
			character.Die ();
			uiManager.Lose ();
		}
	}
}
