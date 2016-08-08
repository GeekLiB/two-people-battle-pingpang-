using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	public Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start () 
	{
		rigidbody2D = GetComponent<Rigidbody2D> ();

		GoBall ();
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.tag=="Player")
		{
			Vector2 velocity =rigidbody2D.velocity;
			velocity.y = velocity.y / 2 + col.rigidbody.velocity.y;
			rigidbody2D.velocity = velocity;
		}
		if (col.gameObject.name == "rightwall" || col.gameObject.name == "leftwall") {
			WallController.Instance.ChangeScore (col.gameObject.name);
		}
	}

	// Update is called once per framew
	void Update () {
		Vector2 velocity =rigidbody2D.velocity;
		if(velocity.x<9&&velocity.x>-9&&velocity.x!=0){
			if(velocity.x>0){
				velocity.x=10;
			}
			else{
				velocity.x=-10;
			}
			rigidbody2D.velocity=velocity;
		}

	
	}
	public void Reset(){
		transform.position = Vector3.zero;
		GoBall ();
	}
	void GoBall()
	{
		int number = Random.Range (0,2);
		if (number == 1) {
			rigidbody2D.AddForce (new Vector2 (120, 0));
		} 
		else 
		{
			rigidbody2D.AddForce (new Vector2 (-120, 0));
		}
	}
}
