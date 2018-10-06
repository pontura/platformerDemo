using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public int life = 3;
	public int coins = 0;
	public Text coinsField;
	public Text lifeField;

	void Start () {
		coinsField.text = "coins: " + coins;
		lifeField.text = "life: " + life;
	}
	public void GetCoin()
	{
		coins++;
		coinsField.text = "coins: " + coins;
	}
	public void Lose()
	{
		life--;
		lifeField.text = "life: " + life;
	}
	public void Win()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("WinScreen");
	}
}
