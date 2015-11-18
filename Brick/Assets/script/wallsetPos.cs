using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]

public class wallsetPos : MonoBehaviour {

    public Vector2 sizevalue;
    public Vector2 offset;
	// Use this for initialization
	void Start () {
        GetComponent<BoxCollider2D>().size = new Vector2(Screen.width * sizevalue.x , Screen.height * sizevalue.y);
        GetComponent<BoxCollider2D>().offset = new Vector2( offset.x * Screen.width, Screen.height * offset.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * sizevalue.x, Screen.width * sizevalue.y);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ball")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
