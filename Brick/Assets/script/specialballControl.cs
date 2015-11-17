using UnityEngine;
using System.Collections;

public class specialballControl : MonoBehaviour {

    public GameObject specialball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setposition(Vector2 pos)
    {
        specialball.GetComponent<Transform>().position = pos;
    }



}
