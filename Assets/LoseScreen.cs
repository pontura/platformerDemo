﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour {

	public void Restart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
	}
}
