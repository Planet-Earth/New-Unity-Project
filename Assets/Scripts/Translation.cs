using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Translation : MonoBehaviour {

	public float speedFactor = 1f;
	public float forceFactor = 100f;
	public Vector3 momentum;

	public Slider sliderForce;
	public Slider sliderAngle;
	public float test = 0f;

	private Vector3 vel;
	private float mas;

	void Start(){
		momentum = vel * mas;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.W)){
			//transform.Translate(Vector3.forward * speedFactor * Time.deltaTime);
			GetComponent<Rigidbody>().AddForce(transform.forward * forceFactor);
		}
		if(Input.GetKey(KeyCode.S))
			transform.Translate(-Vector3.forward * speedFactor * Time.deltaTime);
		if(Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right * speedFactor * Time.deltaTime);
		if(Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left * speedFactor * Time.deltaTime);
		if(Input.GetKey(KeyCode.Space)){
			transform.position = new Vector3(0, .5f, 0);
			transform.rotation = Quaternion.identity;
			GetComponent<Rigidbody>().AddForce(-momentum);
		}
	}

	void Update(){
		vel = GetComponent<Rigidbody>().velocity;
		mas = GetComponent<Rigidbody>().mass;
		momentum = vel * mas;
	}

	public void OnClick(){
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().AddForce(transform.forward * forceFactor);
	}

	public void SliderForceUpdate(float value){
		forceFactor = value;
		Debug.Log(value);
	}

	public void SliderAngleUpdater(float value){
		Debug.Log(value);
		transform.eulerAngles = new Vector3(value,0,0);
	}
}
