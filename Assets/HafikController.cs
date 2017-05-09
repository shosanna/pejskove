using UnityEngine;
using System.Collections;

public class HafikController : MonoBehaviour {
	public float walkSpeed = 3;
	public Transform cameraTransform;
	public float jumpForce = 4;

	private Rigidbody2D _rigidbody2D;
	private Transform _leftRaySource;
	private Transform _rightRaySource;

	private Animator _anim;
	private SpriteRenderer _renderer;

	private bool _grounded = false;
	private bool _doubleJumpAvailable = false;
	private bool _followCamera = false;

	// Use this for initialization
	void Start () {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_leftRaySource = transform.FindChild("Feet Raycast Left");
		_rightRaySource = transform.FindChild("Feet Raycast Right");
		_anim = GetComponent<Animator>();
		_renderer = GetComponent<SpriteRenderer>();
	}

	public void FollowCamera() {
		_followCamera = true;
	}

	public void Move(float movement) {
		if (movement == 1) {
			_renderer.flipX = false;
			_anim.SetBool("isMoving", true);
		} else if (movement == -1) {
			_renderer.flipX = true;
			_anim.SetBool("isMoving", true);
		} else {
			_anim.SetBool("isMoving", false);
		}

		_rigidbody2D.velocity = new Vector2(movement*walkSpeed, _rigidbody2D.velocity.y);

		HandleJump();

		GroundCheckRay(_leftRaySource);
		GroundCheckRay(_rightRaySource);
	}

	private void GroundCheckRay(Transform raySource) {
		var from = raySource.transform.position;
		float feetRayLength = 0.03f;

		Debug.DrawLine(from, from + Vector3.down*feetRayLength);
		var hit = Physics2D.Raycast(from, Vector2.down, feetRayLength);
		if (hit) {
			_grounded = true;
		} else {
			_grounded = false;
		}
	}

	private IEnumerator EnableDoubleJump() {
		yield return new WaitForSeconds(0.05f);
		_doubleJumpAvailable = true;
	}

	private void HandleJump() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (_grounded) {
				_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
				_rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
				StartCoroutine(EnableDoubleJump());
			} else if (_doubleJumpAvailable) {
				_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
				_rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
				_doubleJumpAvailable = false;
			}
		}
	}

	void LateUpdate() {
		if (_followCamera) {
			cameraTransform.position = new Vector3(transform.position.x + 3, transform.position.y,
				cameraTransform.position.z);
			_followCamera = false;
		}
	}
}
