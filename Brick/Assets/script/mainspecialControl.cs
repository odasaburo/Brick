using UnityEngine;
using System.Collections;

public class mainspecialControl : MonoBehaviour {
    public int state;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ball")
        {
            other.gameObject.GetComponent<ballcontrol>().special_state = state;
            other.gameObject.GetComponent<ballcontrol>().special_flag = true;
        }
    }

}
