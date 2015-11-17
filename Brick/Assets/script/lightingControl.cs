using UnityEngine;
using System.Collections;

public class lightingControl : MonoBehaviour {
    public GameObject lighting;
	// Use this for initialization
	void Start () {
        lightingsetposition();
    }
	
	// Update is called once per frame
	void Update () {
	    if(lighting.GetComponent<Transform>().position.y >= Screen.height - 100)
        {
            Destroy(this.gameObject);
        }
	}

    public void lightingsetposition()
    {
        lighting.GetComponent<Transform>().position = new Vector2( GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.x, GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.y + 100) ;
        lighting.GetComponent<Rigidbody2D>().velocity = new Vector2(0,500);
    }
}
