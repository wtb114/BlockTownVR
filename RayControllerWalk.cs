using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using UnityEngine.Advertisements;

public class RayControllerWalk : MonoBehaviour {

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	public GameObject diveCamera,display;
//	public GameObject Colliders;
	GameObject[] difficultyImages;

	Slider _slider;
	AudioClip hitSound;
	AudioSource audioSource;

//	public LayerMask layerMask;
//
//	float yOffset;

	float _gaugetime = 0;

	float zombieHP = 0;

	float stageX = 230;
	float stageZ = 230;

	GameManager gameManeger;


	// Use this for initialization
	void Start () {
//		yOffset = diveCamera.transform.position.y;
		difficultyImages = GameObject.FindGameObjectsWithTag ("DifficultyImage");
		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		hitSound = Resources.Load<AudioClip>("Audio/Arrow 8");
		gameManeger = display.GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (diveCamera.transform.position, diveCamera.transform.forward);
		RaycastHit hit;


		if (Physics.Raycast (ray, out hit)) {
			Debug.DrawLine (ray.origin, hit.point, Color.black);

			if (hit.collider.gameObject.tag == "Zombie") {
				GameManager.zombie = hit.collider.gameObject;
				zombieHP += Time.deltaTime;
				if (zombieHP > 2f) {
					GameObject effectObj = Resources.Load<GameObject> ("Effects/Destroy");
					Instantiate(effectObj, hit.collider.gameObject.transform.position, effectObj.transform.rotation);

//					GameManagerWalk abc = new GameManagerWalk();
//					abc.ScorePlus ();
					//GameManager.ZombieDead();
					gameManeger.ZombieDead ();
					//GameManager.ScorePlus();
					gameManeger.ScorePlus();
					StartCoroutine ("ZombieRevival");
				} 
			}else {
				zombieHP = 0;
			}


			if (hit.collider.gameObject.tag == "DifficultyColliderMenu") {
				hit.collider.gameObject.transform.parent.GetComponent<Image> ().color = Color.yellow;
				audioSource = hit.collider.gameObject.transform.parent.GetComponent<AudioSource> ();
				audioSource.PlayOneShot (hitSound);
				_gaugetime += 0.03f;
				if (_gaugetime > 1f) {
					ShowAd ();
					SceneManager.LoadScene ("Menu");
				}
				_slider.value = _gaugetime;
			}  else { for (int i = 0; i < difficultyImages.Length; i++) { 
					difficultyImages [i].GetComponent<Image> ().color = Color.white;
				}
				_gaugetime = 0;
				_slider.value = _gaugetime;
			}
		}
			


	}
	IEnumerator ZombieRevival(){
		yield return new WaitForSeconds (3.0f);
		GameManager.zombie.SetActive (true);
		GameManager.zombie.transform.position = new Vector3(Random.Range(-stageX,stageX), 0,Random.Range(-stageZ,stageZ));
	}
}