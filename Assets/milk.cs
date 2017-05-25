using UnityEngine;
using System.Collections;

public class milk : MonoBehaviour {
	private bool _olafBumbik = false;
	private bool _luluBumbik = false;
	private bool _haleyBumbik = false;
	public AudioClip mlask;


	void OnCollisionEnter2D(Collision2D col)
	{

		if(col.gameObject.name == "Olaf")
		{
			AudioSource.PlayClipAtPoint(mlask, Camera.main.transform.position);
			_olafBumbik = true;
		}

		if(col.gameObject.name == "Lulu")
		{
			AudioSource.PlayClipAtPoint(mlask, Camera.main.transform.position);
			_luluBumbik = true;
		}

		if(col.gameObject.name == "Haley")
		{
			AudioSource.PlayClipAtPoint(mlask, Camera.main.transform.position);
			_haleyBumbik = true;
		}
	}

	void Update()
	{
		if (_olafBumbik && _luluBumbik && _haleyBumbik) {
			Application.LoadLevel("Win");  
		}
	}
}
