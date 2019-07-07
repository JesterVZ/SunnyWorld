using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checker : MonoBehaviour {
    public bool active = true;
    void Start()
    {
        //gameObject.SetActive(false);
    }

    void Update()
    {
        if (active)
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
    }

	void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.name.Equals("fireball 1(Clone)")){
			Destroy(gameObject);
		}
	}

}
