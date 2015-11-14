using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class ballcontrol : MonoBehaviour {

    public Rigidbody2D rigibody;
    public CircleCollider2D circlecollider;
   
	// Use this for initialization
	void Start () {
        circlecollider = GetComponent<CircleCollider2D>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        circlecollider.radius = Screen.width / 40;
        rigibody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void setPosition(float x, float y)
    {
        GetComponent<RectTransform>().position = new Vector2(x, y);
    }

    public void setSpeed(float speed)
    {
        rigibody.velocity = new Vector2(speed, -speed);
    }
    public void speedUP()
    {
        rigibody.velocity = new Vector2(rigibody.velocity.x * 1.4f, rigibody.velocity.y * 1.4f);
    }

    public void speedDOWN()
    {
        rigibody.velocity = new Vector2(rigibody.velocity.x * 0.6f, rigibody.velocity.y * 0.6f);
    }
}
