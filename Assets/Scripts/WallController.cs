using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WallController : MonoBehaviour {
	private static WallController _instance;
	public  static WallController Instance
	{
		get
		{
			return _instance;
		}
	}
	public BoxCollider2D rightwall;
	public BoxCollider2D leftwall;
	public BoxCollider2D upwall;
	public BoxCollider2D downwall;
	public Transform player1;
	public Transform player2;
	private int score1;
	private int score2;
	public Text scoreText;
	public Text score1Text;
	// Use this for initialization
	void Start () {
		Reset ();
		ResetPlayer ();
	
	}
	void Awake(){
		_instance = this;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
	void Reset(){
		rightwall = transform.Find ("rightwall").GetComponent<BoxCollider2D> ();
		leftwall = transform.Find ("leftwall").GetComponent<BoxCollider2D> ();
		Vector3 tempPosition = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width,Screen.height));
		upwall.transform.position = new Vector3 (0,tempPosition.y+0.5f,0);
		upwall.size = new Vector2 (tempPosition.x*2,1);
		downwall.transform.position = new Vector3 (0,-tempPosition.y-0.5f,0);
		downwall.size = new Vector2 (tempPosition.x*2,1);
		rightwall.transform.position = new Vector3 (tempPosition.x+0.5f,0,0);
		rightwall.size = new Vector2 (1,tempPosition.y*2);
		leftwall.transform.position = new Vector3 (-tempPosition.x-0.5f,0,0);
		leftwall.size = new Vector2 (1,tempPosition.y*2);
	}
	void ResetPlayer(){
		Vector3 player1Position = Camera.main.ScreenToWorldPoint (new Vector3(100,Screen.height/2,0));
		player1Position.z = 0;
		player1.position = player1Position;
		Vector3 player2Position = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width-100,Screen.height/2,0));
		player2Position.z = 0;
		player2.position = player2Position;
	}
	public void ChangeScore(string Wallname){
		if (Wallname == "leftwall") {
			score2++;
		} else 
		{
			score1++;
		}
		scoreText.text = score1.ToString ();
		score1Text.text = score2.ToString ();
	}
	public void ResetButton()
	{
		score1 = 0;
		score2 = 0;
		scoreText.text = score1.ToString ();
		score1Text.text = score2.ToString ();
		GameObject.Find ("Ball").SendMessage ("Reset");
	}
}
