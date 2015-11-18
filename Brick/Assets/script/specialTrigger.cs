using UnityEngine;
using System.Collections;

public class specialTrigger : MonoBehaviour {

    public AudioSource audiosource;
    public AudioClip catchclip;
    public int state;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Transform>().position.y <= 20)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            //audiosource.PlayOneShot(catchclip);
            audiosource.Play();
            if (state == 1) // clone ball
            {
                Debug.Log("state is 1");
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<Maincontrol>().cloneball(2);
            } else
            {
                GameObject.FindGameObjectWithTag("ball").GetComponent<ballcontrol>().special_state = state;
                GameObject.FindGameObjectWithTag("ball").GetComponent<ballcontrol>().special_flag = true;
            }
            Destroy(this.gameObject, 0.3f);
            Debug.Log("special");
        }
    }
}
