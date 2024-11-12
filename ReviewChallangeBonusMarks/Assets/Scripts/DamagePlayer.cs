using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	[SerializeField] private int damage = 1;

	private void OnCollisionEnter(Collision collider)//deals damage if the collision has the right componant
	{
		if (collider.gameObject.GetComponent<PlayerController>() != null)
		{
			collider.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
		}
	}
}
