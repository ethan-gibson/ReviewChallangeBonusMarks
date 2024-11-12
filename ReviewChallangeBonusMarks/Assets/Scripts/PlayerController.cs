using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	[SerializeField] private int lives = 3;
	[SerializeField] private TextMeshProUGUI health;

	private void Start() //set initial text
	{
		health.text = "Lives: " + lives;
	}

	void Update()
	{
		MovePlayer();
	}

	void MovePlayer() //reads A and D key for input
	{
		if (Input.GetKey(KeyCode.A))
		{
			transform.position -= speed * Time.deltaTime * transform.right;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += speed * Time.deltaTime * transform.right;
		}
	}

	/*
	deals damage to the player, if the player falls below 0 it calls the gamemanager singleton
	*/
	public void TakeDamage(int damage)
	{
		lives -= damage;
		health.text = "Lives: " + lives;
		if (lives <= 0)
		{
			GameManager.Instance.CallRestart();
		}
	}
}
