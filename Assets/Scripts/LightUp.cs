﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour {

	public Material lightUpMaterial = null;
	private Material defaultMaterial = null;
	private bool isLitUp = false;
	public Canvas canvas = null;

	// Use this for initialization
	void Start () {
		defaultMaterial = this.GetComponent<MeshRenderer> ().material; //Save our initial material as the default
		isLitUp = false;
		if (canvas != null)
			canvas.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	}
		
	public void PlayerSelection() {
		if (!isLitUp) {
			ObjectLightUp();
			isLitUp = true;
		} else {
			AestheticReset ();
			isLitUp = false;
		}
		ToggleInformation ();
	}

	private void AestheticReset() {
		this.GetComponent<MeshRenderer>().material = defaultMaterial; //Revert to the default material
		//this.GetComponent<GvrAudioSource> ().Stop (); //Stop the audio attached
	}

	private void ObjectLightUp() { //Lightup behavior when the pattern shows.
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		//this.GetComponent<GvrAudioSource> ().Play (); //Play the audio attached
	}

	private void ToggleInformation(){
		print ("!@#!@$" + isLitUp);
		if (isLitUp) {
			StartCoroutine (playerSelection (1f));
		} else {
			StartCoroutine (playerSelection (0f));
		}

	}

	IEnumerator playerSelection(float duration) { //Light us up for a duration.  Used during the pattern display
		print ("duration = " + duration);
		yield return new WaitForSeconds(duration);
		if (canvas != null)
			canvas.gameObject.SetActive (isLitUp);
	}
}