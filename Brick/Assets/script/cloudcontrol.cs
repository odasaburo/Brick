﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class cloudcontrol : MonoBehaviour {
    public GameObject parent;
    public GameObject gamenmanager;
    public AudioSource audiosource;
    GameObject[] lighting;
    Animator animator;
	// Use this for initialization
	void Start () {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/11, Screen.width / 14);
        GetComponent<BoxCollider2D>().size = new Vector2(Screen.width / 11, Screen.width / 14);
        animator = GetComponent<Animator>();
        gamenmanager = GameObject.FindGameObjectWithTag("GameManager");
        
    }

    public void setPosition(float x, float y) {
        GetComponent<Transform>().position = new Vector2(x, y);
    }
	// Update is called once per frame
	void Update () {
        lighting = GameObject.FindGameObjectsWithTag("lighting");
        if(lighting == null)
        {
            return;
        }
        else
        {
            for(int i = 0; i < lighting.Length; i++)
            {
                if(lighting[i].GetComponent<Transform>().position.x < GetComponent<Transform>().position.x + Screen.width / 22 &&
                   lighting[i].GetComponent<Transform>().position.x > GetComponent<Transform>().position.x - Screen.width / 22 &&
                   lighting[i].GetComponent<Transform>().position.y < GetComponent<Transform>().position.y + Screen.width / 28 &&
                   lighting[i].GetComponent<Transform>().position.y > GetComponent<Transform>().position.y - Screen.width / 28)
                {
                    audiosource.Play();
                    animator.SetTrigger("destroy");
                    gamenmanager.GetComponent<Maincontrol>().game_score += 1;
                    gamenmanager.GetComponent<Maincontrol>().destroy_pos = GetComponent<Transform>().position;
                    Destroy(parent, 0.7f);
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ball" )
        {
            audiosource.Play();
            animator.SetTrigger("destroy");
            gamenmanager.GetComponent<Maincontrol>().game_score += 1;
            gamenmanager.GetComponent<Maincontrol>().destroy_pos = GetComponent<Transform>().position;
            

            if (other.tag == "ball")
            {
                 if (other.gameObject.GetComponent<ballcontrol>().special_state == 2)
                {
                    other.gameObject.GetComponent<ballcontrol>().snow_flag = true;
                }
            }
            Destroy(parent, 0.7f);
        }
    }
}
