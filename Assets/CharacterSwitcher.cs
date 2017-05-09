using UnityEngine;
using System.Collections;

public class CharacterSwitcher : MonoBehaviour {

	public GameObject Olaf;
	public GameObject Haley;
	public GameObject Lulu;

	private GameObject _currentHafik;

	// Use this for initialization
	void Start() {
		_currentHafik = Olaf;
	}

	// Update is called once per frame
	void FixedUpdate() {
		var movement = Input.GetAxisRaw("Horizontal");

		if (Input.GetKey(KeyCode.O)) {
			_currentHafik = Olaf;
		} else if (Input.GetKey(KeyCode.L)) {
			_currentHafik = Lulu;
		} else if (Input.GetKey(KeyCode.H)) {
			_currentHafik = Haley;
		}

		_currentHafik.GetComponent<HafikController>().Move(movement);
		_currentHafik.GetComponent<HafikController>().FollowCamera();
	}
}
