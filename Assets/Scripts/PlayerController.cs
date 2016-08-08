﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public KeyCode upKey;
	public KeyCode downKey;
	private Rigidbody2D rigidbody2D;
	public float speed = 10;
	private AudioSource audio;


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (upKey)) {
			rigidbody2D.velocity = new Vector2 (0, speed);
		} else if(Input.GetKey (downKey)){
			rigidbody2D.velocity = new Vector2 (0, -speed);
		}
		else {
			rigidbody2D.velocity = new Vector2 (0, 0);
		}
	
	}
	void OnCollisionEnter2D()
	{
		audio.pitch = Random.Range (0.8f, 1.2f);
		audio.Play ();
	}
}
