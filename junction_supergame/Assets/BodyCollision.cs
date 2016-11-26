﻿using UnityEngine;
using System.Collections;
using System;

public class BodyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    //void OnCollisionEnter2D( Collision2D coll )
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            float tmp_x = (float)Math.Round(2.0 * transform.position.x) / 2.0f;
            float tmp_y = (float)Math.Round(2.0 * transform.position.y) / 2.0f;
            transform.position = new Vector3(tmp_x, tmp_y, 0f);
            GetComponent<Movement>().m_direction = Quaternion.Euler(0, 0, -90) * GetComponent<Movement>().m_direction;
            Debug.Log(GetComponent<Movement>().m_direction.ToString());
			GetComponent<BodySpriteAnimations>().changeSprite( GetComponent<Movement>().m_direction );
        }
        else if (collision.gameObject.tag == "Grave")
        {
            Debug.Log("You DIEDEDEDEDEDEDED!!!");
            transform.position = collision.transform.position;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver = true;

        }
        else if (collision.gameObject.tag == "Character")
        {			
			if( !GameObject.FindObjectOfType<LevelHandling>().nextLevel() )
			{
				GameObject.FindGameObjectWithTag( "GameManager" ).GetComponent<GameManager>().GameWon = true;
			}
        }
    }
}
