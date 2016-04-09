using UnityEngine;
using System.Collections;

public class HangmanController : MonoBehaviour {

	public GameObject head;
	public GameObject torso;
	public GameObject arms;
	public GameObject legs;

	private int tries;
	private GameObject[] parts;

	// Use this for initialization
	void Start () {
		parts = new GameObject[] {legs,arms,torso,head};
		reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool isDead {
	
		get{ 
			return tries < 0;
		}
	}
	
	
	public void punish() {
		Debug.Log("punish player");
		if(tries >= 0){
		
			parts[tries--].SetActive(true);
		}
	}
	
	
	public void reset(){
	
		if(parts == null){
		return;
		}
	
	
		tries = parts.Length -1;
		//foreach(GameObject g in parts){
		//	g.SetActive(false);
		//}
		for (int i = 0; i < parts.Length; i++) {
			parts[i].SetActive (false);
		}
	}
	
}
