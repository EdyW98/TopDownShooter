﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class Gun : MonoBehaviour {

	public LayerMask collisionMask;

	public int damage = 1;

	//variabel untuk menentukan lokasi munculnya tembakan
	public Transform spawn;
	public Transform shellEjectionPoint;
	public Rigidbody shell;

	private LineRenderer tracer;

	void Start(){
		if (GetComponent<LineRenderer> ()) {
			tracer = GetComponent<LineRenderer>();
		}
	}


	public void Shoot(){
		//fungsi tembak mengunakan sistem ray
		//buat ray + arahnya
		Ray ray = new Ray (spawn.position, spawn.forward);
		RaycastHit hit;

		//variabel jarak tembak
		float shotDistance = 5;

		//collision detectionnya
		if (Physics.Raycast (ray, out hit, shotDistance, collisionMask)) {
			shotDistance = hit.distance;
			if(hit.collider.GetComponent<Entity>()){
				hit.collider.GetComponent<Entity>().takeDamage(damage);
			}
		}

		//debug untuk menunjukkan lokasi arah tembakannya
		Debug.DrawRay(ray.origin,ray.direction * shotDistance,Color.red,1);

		AudioSource audio = GetComponent<AudioSource>();
		audio.Play ();

		if (tracer) {
			StartCoroutine("RenderTracer",ray.direction*shotDistance);
		}

		Rigidbody newShell = Instantiate (shell, shellEjectionPoint.position, Quaternion.identity) as Rigidbody;
		newShell.AddForce (shellEjectionPoint.right * Random.Range (150f, 200f) + spawn.forward * Random.Range (-10f, 10f));


	}

	IEnumerator RenderTracer(Vector3 hitPoint){
		tracer.enabled = true;
		tracer.SetPosition(0,spawn.position);
		tracer.SetPosition (1, spawn.position + hitPoint);
		yield return null;
		tracer.enabled = false;
	}
	
	
}
