using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using UnityEngine.Advertisements;

public class RayController : MonoBehaviour {

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	public GameObject diveCamera;
	AudioClip hitSound;
	AudioSource audioSource;

//	LineRenderer laser;
//	public GameObject Colliders;
	GameObject[] difficultyImages;

	Slider _slider;
//	public LayerMask layerMask;
//
//	float yOffset;

	// Use this for initialization
	void Start () {
		
//		yOffset = diveCamera.transform.position.y;
		difficultyImages = GameObject.FindGameObjectsWithTag ("DifficultyImage");
		_slider = GameObject.Find("Slider").GetComponent<Slider>();
//		laser = this.GetComponent<LineRenderer> ();
//		laser.SetPosition (1, diveCamera.transform.forward*100);
		hitSound = Resources.Load<AudioClip>("Audio/Arrow 8");
	
	}
	float _hp = 0;
	// Update is called once per frame
	void Update () {
//		ShowAd ();

		Ray ray = new Ray (diveCamera.transform.position, diveCamera.transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			Debug.DrawLine (ray.origin, hit.point, Color.black);
			if (hit.collider.gameObject.tag == "DifficultyColliderWalk") {
				audioSource = hit.collider.gameObject.transform.parent.GetComponent<AudioSource> ();
				audioSource.PlayOneShot (hitSound);
				hit.collider.gameObject.transform.parent.GetComponent<Image> ().color = Color.yellow;
				_hp += 0.03f;
				if (_hp > 1) {
					SceneManager.LoadScene ("Walk");
				}
				_slider.value = _hp;
			} else if (hit.collider.gameObject.tag == "DifficultyColliderFly") {
				audioSource = hit.collider.gameObject.transform.parent.GetComponent<AudioSource> ();
				audioSource.PlayOneShot (hitSound);
				hit.collider.gameObject.transform.parent.GetComponent<Image> ().color = Color.yellow;
				_hp += 0.03f;
				if (_hp > 1) {
					SceneManager.LoadScene ("Fly");
				}
				_slider.value = _hp;
			} else if (hit.collider.gameObject.tag == "DifficultyColliderQuit") {
				audioSource = hit.collider.gameObject.transform.parent.GetComponent<AudioSource>();
				audioSource.PlayOneShot(hitSound);
				hit.collider.gameObject.transform.parent.GetComponent<Image> ().color = Color.yellow;
				_hp += 0.03f;
				if (_hp > 1) {
					Application.Quit();
				}
				_slider.value = _hp;
			} else { for (int i = 0; i < difficultyImages.Length; i++) { 
		                 difficultyImages [i].GetComponent<Image> ().color = Color.white;
				   }
				_hp = 0;
				_slider.value = _hp;
			}
		}


	}
}