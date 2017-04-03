using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using UnityEngine.Advertisements;

public class GameManager: MonoBehaviour {

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	float countDown;
	public Text CountDown;

	float countTime;
	public Text Timer;

	public Text Finish;
	public Text FinishScore;

	public Text ScoreText;
	public static int score;

	public Text HighScore;

	public static GameObject zombie;

//	float stageXX = 230;
//	float stageZZ = 230;


	void Start () {
		countDown = 3;
		countTime = 120;
		score = 0;

		if (SceneManager.GetActiveScene ().name == "Menu") {
			HighScore.text = PlayerPrefs.GetInt ("HighScore") + "Zombies";
		}

	}
		
	void Update () {
		if ((SceneManager.GetActiveScene ().name == "Fly") || (SceneManager.GetActiveScene ().name == "Walk")) {
			ScoreText.text = "Score: " + score;
		
			countDown -= Time.deltaTime;  
			CountDown.GetComponent<Text> ().text = countDown.ToString ("F0");
			if (countDown < 0.7f) {
				CountDown.GetComponent<Text> ().text = "Go!!";
				Invoke ("DelayMethod", 1.0f);
			}
		}
			

//		if (ZombieController.agent.transform.position == ZombieController.goal.position) {
//			zombie.transform.position = new Vector3 (Random.Range (-stageXX, stageXX), 0, Random.Range (-stageZZ, stageZZ));
//		}
    }


	public void DelayMethod(){
		CountDown.GetComponent<Text> ().enabled = false;
		setTimer ();
	}

	public void DelayMethodAfterGame(){
		FinishScore.GetComponent<Text> ().enabled = false;
		ShowAd ();
		SceneManager.LoadScene ("Menu");
	}


	public void FinishGame(){
		Finish.GetComponent<Text> ().enabled = false;
		ScoreText.GetComponent<Text> ().enabled = false;
		FinishScore.GetComponent<Text> ().text = "Score: " + score + "zombies";

		Invoke ("DelayMethodAfterGame", 10.0f);
	}


	public void setTimer () {
		countTime -= Time.deltaTime;
		Timer.GetComponent<Text>().text = countTime.ToString("F2"); 
		if (countTime < 0f) {
//		if(countTime<60f){
		Timer.GetComponent<Text> ().enabled = false;
			Finish.transform.GetComponent<Text>().text = "Finish!!";
			SaveHighScore ();
	
			Invoke("FinishGame", 2.0f);

		}
	}

	public  void ScorePlus() {
		score += 1;
	}

	public void SaveHighScore() {
		if (PlayerPrefs.GetInt ("HighScore") < score) {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}

	public  void ZombieDead(){
		zombie.SetActive(false);
//		StartCoroutine ("ZombieRevival");
	}

//	public static IEnumerator ZombieRevival(){
//		yield return new WaitForSeconds (3.0f);
//		GameManager.zombie.SetActive (true);
//	}

}
