using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	Character target;
	public UIManager uiManager;

	void Update()
	{
		if (target == null)
			return;

		transform.localPosition = Vector3.Lerp (transform.localPosition, target.transform.localPosition, 0.1f);
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Character character = other.gameObject.GetComponent<Character> ();
		if (character != null) {
			uiManager.GetCoin ();	
			target = character;
			Invoke ("OnDestroy", 0.25f);
		}
	}
	void OnDestroy()
	{
		Events.OnSoundFX ("sounds/coin");
		Destroy (this.gameObject);
	}
}
