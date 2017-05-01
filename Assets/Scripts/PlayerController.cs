using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject firePoint;
	public GameObject redBeam;
	public GameObject blueBeam;

	public AudioClip coin;
	public AudioClip hatUpgrade;
	public AudioClip hurt;
	public AudioClip gameOver;

	public Image healthBar;

	public Text coinText;
	public Text healthText;

	public float moveSpeed;
	public float health;
	public float fireRate;
	public float upgrade;
	public float lives;
	public float bulletSpeed;
	public float bulletDamage;
	public float coinCount;
	public float coinTarget;

	public int loadStage;

	private bool canFire;
	private bool upgraded;

	private float fireTime;
	private float upgradeTime;

	private Vector3 mousePosition;
	private Vector3 mouseRotation;

	void Start() {
		canFire = true;
		upgraded = false;
		fireTime = Time.time;
		Cursor.visible = false;
		coinCount = 0;
		coinText.text = coinCount + "/" + coinTarget;
		healthText.text = "Health: " + health;
		this.transform.GetChild (4).gameObject.SetActive (false);
	}

	void Update() {

		Move ();
		UpdateUI ();

		if (Input.GetButton ("Fire1") && canFire) {
			if(Time.time > fireTime)
				Fire ();
		}

		if (upgraded) {
			//Enable Hat
			this.transform.GetChild (4).gameObject.SetActive (true);
			if (Time.time >= upgradeTime) {
				this.transform.GetChild (4).gameObject.SetActive (false);
				upgraded = false;
				bulletDamage /= 1.5f;
				fireRate *= 1.5f;
			}
				
		}

		if (coinCount >= coinTarget)
			SceneManager.LoadScene (loadStage);

		if (health <= 0)
			GameOver ();
		if (health > 100)
			health = 100;
	}

	void UpdateUI() {
		healthText.text = "Health: " + health;
		coinText.text = coinCount + "/" + coinTarget;
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(health/100,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	void Fire() {
		fireTime = Time.time + fireRate;

		if (upgraded) {
			GameObject beam = Instantiate (blueBeam.gameObject, firePoint.transform.position, firePoint.transform.rotation);
			AudioSource audio = beam.GetComponent (typeof(AudioSource)) as AudioSource;
			audio.Play ();
			Rigidbody2D beamRigid = beam.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
			beamRigid.velocity = Vector2.right * bulletSpeed;

		} else {
			GameObject beam = Instantiate (redBeam.gameObject, firePoint.transform.position, firePoint.transform.rotation);
			AudioSource audio = beam.GetComponent (typeof(AudioSource)) as AudioSource;
			audio.Play ();
			Rigidbody2D beamRigid = beam.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
			beamRigid.velocity = Vector2.right * bulletSpeed;
		}
	}

	void Move() {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		mousePosition = new Vector2 (mousePosition.x - 1f, mousePosition.y + 0.25f);
		transform.position = Vector2.Lerp (transform.position, mousePosition, moveSpeed);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Coin") {
			AudioSource.PlayClipAtPoint(coin, transform.position);
			coinCount++;
			Destroy (coll.gameObject);
		}

		if (coll.gameObject.tag == "Enemy") {
			AudioSource.PlayClipAtPoint(hurt, transform.position);
			Enemy e = coll.gameObject.GetComponent ("Enemy") as Enemy;
			health -= e.damage;
			Destroy (coll.gameObject);
		}

		if (coll.gameObject.tag == "Upgrade") {
			Debug.Log ("Hat Hit");
			AudioSource.PlayClipAtPoint(hatUpgrade, transform.position);
			upgraded = true;
			upgradeTime = Time.time + upgrade;
			bulletDamage *= 1.5f;
			health += 40;
			fireRate /= 1.5f;
			Destroy (coll.gameObject);
		}
	}

	void GameOver() {
		AudioSource.PlayClipAtPoint(gameOver, transform.position);
		SceneManager.LoadScene (4);
	}
}
