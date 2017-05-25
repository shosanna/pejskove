using UnityEngine;
using System.Collections;

public class CharacterSwitcher : MonoBehaviour {

	public GameObject Olaf;
	public GameObject Haley;
	public GameObject Lulu;

	public AudioClip OlafSound;
	public AudioClip HaleySound;
	public AudioClip LuluSound;

	private float volume = 1.2f;
	private bool _olafSoundPlayed = false;
	private bool _haleySoundPlayed = false;
	private bool _luluSoundPlayed = false;

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
			if (!_olafSoundPlayed) {
				AudioSource.PlayClipAtPoint(OlafSound, Camera.main.transform.position, volume);
				_olafSoundPlayed = true;
				_luluSoundPlayed = false;
				_haleySoundPlayed = false;
			}
		} else if (Input.GetKey(KeyCode.L)) {
			_currentHafik = Lulu;
			if (!_luluSoundPlayed) {
				AudioSource.PlayClipAtPoint(LuluSound, Camera.main.transform.position, volume);
				_olafSoundPlayed = false;
				_luluSoundPlayed = true;
				_haleySoundPlayed = false;
			}
		} else if (Input.GetKey(KeyCode.H)) {
			_currentHafik = Haley;
			if (!_haleySoundPlayed) {
				AudioSource.PlayClipAtPoint(HaleySound, Camera.main.transform.position, volume);
				_olafSoundPlayed = false;
				_luluSoundPlayed = false;
				_haleySoundPlayed = true;
			}
		}

		_currentHafik.GetComponent<HafikController>().Move(movement);
		_currentHafik.GetComponent<HafikController>().FollowCamera();
	}
}
