using UnityEngine;
using System.Collections;

public class GyroScriptFly : MonoBehaviour {

	public GameObject diveCamera;
//	public float moveSpeed1  = 20.0f;
	public float moveSpeed2 = 30.0f;
//	public float moveSpeed3 = -10.0f;
//	public float moveAngleX = 10.0f;
//	public float moveAngleXX = 20.0f;
//	public float moveAngleXXX = 355.0f;
//	public float moveAngleXXXX = 340.0f;
//
	float yOffset;

	Quaternion currentGyro;

	void Start(){
		Input.gyro.enabled = true;
		yOffset = gameObject.transform.position.y;
	}

	void Update () {
		currentGyro = Input.gyro.attitude;
		this.transform.localRotation = 
			Quaternion.Euler (90, 90, 0) * (new Quaternion (-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w)); 

		

//		float angle = diveCamera.transform.eulerAngles.x;
//
//		Debug.Log (angle);		
//
//
//		if (moveAngleX < angle && angle < moveAngleXX) {
//			flyForward ();
//		} else if (moveAngleXX < angle && angle < 45.0f) {
//			moveUp ();
//		} else if (moveAngleXXX > angle && angle > moveAngleXXXX) {
//			moveDown ();
//		} 
//
			move ();

	}

	public void move(){
		Vector3 direction = new Vector3 (diveCamera.transform.forward.x, diveCamera.transform.forward.y, diveCamera.transform.forward.z).normalized * moveSpeed2 * Time.deltaTime;
		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
		diveCamera.transform.Translate (rotation * direction);
		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, diveCamera.transform.position.y, diveCamera.transform.position.z);
	}
		
//	public void flyForward() {
//		Vector3 direction = new Vector3 (diveCamera.transform.forward.x, 0, diveCamera.transform.forward.z).normalized * moveSpeed2 * Time.deltaTime;
//		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
//		diveCamera.transform.Translate (rotation * direction);
//		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, diveCamera.transform.position.y, diveCamera.transform.position.z);
//	}
//		
//	public void moveUp(){
//		Vector3 direction = Vector3.up * moveSpeed1 * Time.deltaTime;
//		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
//		rotation = Quaternion.identity;
//		diveCamera.transform.Translate (rotation * direction);
//		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, diveCamera.transform.position.y, diveCamera.transform.position.z);
//		diveCamera.transform.position += direction;
//	}
//
//	public void moveDown(){
//		Vector3 direction = Vector3.up * moveSpeed3 * Time.deltaTime;
//		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
//		rotation = Quaternion.identity;
//		diveCamera.transform.Translate (rotation * direction);
//		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, diveCamera.transform.position.y, diveCamera.transform.position.z);
//		diveCamera.transform.position += direction;
//	}
}