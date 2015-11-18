using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class playerControl : MonoBehaviour {

    public Vector2 pos;
    public bool drag_flag;
    public Vector2 oldmousepos;
    public float delta;

    public Sprite[] images;
	// Use this for initialization
	void Start () {
        pos = GetComponent<Transform>().position;
        GetComponent<CircleCollider2D>().radius = Screen.width / 10;
        GetComponent<CircleCollider2D>().offset = new Vector2(0, -Screen.width / 20);
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 5, Screen.width * 0.8f / 5);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
             if (drag_flag)
            {

                delta = Input.mousePosition.x - oldmousepos.x;
                if (Input.mousePosition.x > oldmousepos.x)
                {
                    GetComponent<Transform>().position = new Vector2( delta + GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
                } else if(Input.mousePosition.x < oldmousepos.x)
                {
                    GetComponent<Transform>().position = new Vector2( delta + GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
                }

                if(GetComponent<Transform>().position.x > Screen.width)
                {
                    GetComponent<Transform>().position = new Vector2(Screen.width, GetComponent<Transform>().position.y);
                } else if(GetComponent<Transform>().position.x < 0)
                {
                    GetComponent<Transform>().position = new Vector2(0, GetComponent<Transform>().position.y);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            drag_flag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            drag_flag = false;
        }

        oldmousepos = Input.mousePosition;

    }

    public void setposition(float x, float y)
    {
        GetComponent<Transform>().position = new Vector2(x, y);
    }
    public void setimage(int number)
    {
        GetComponent<Image>().sprite = images[number];
    }
}
