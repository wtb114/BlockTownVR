using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ButtonController : MonoBehaviour {

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	public void GameStart() { 
		ShowAd ();
		SceneManager.LoadScene ("Menu");
	} 

}