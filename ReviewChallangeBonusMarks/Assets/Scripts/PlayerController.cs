using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	[SerializeField] private int lives = 3;
	void Update()
	{
		MovePlayer();
	}

	void MovePlayer()
	{
		if (Input.GetKey(KeyCode.A))
		{
			transform.position -= transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += transform.right * speed * Time.deltaTime;
		}
	}

	public void TakeDamage(int damage)
	{
		lives -= damage;
	}
}
