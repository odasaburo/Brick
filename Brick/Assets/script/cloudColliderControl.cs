using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class cloudColliderControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<CircleCollider2D>().radius = Screen.width / 30;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
