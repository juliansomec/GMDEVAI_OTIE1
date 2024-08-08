using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
	public int damage = 10;
	
	void OnCollisionEnter(Collision col)
    {
    	GameObject e = Instantiate(explosion, this.transform.position, Quaternion.identity);
    	Destroy(e,1.5f);

		if (col.gameObject.CompareTag("Enemy"))
		{
			col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
		}

		Debug.Log(col.gameObject.name);
    	Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
