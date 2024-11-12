using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	private void Awake()
	{
		if (Instance != null) //creates and sets the instance
			{
				Destroy(gameObject);
				return;
			}
			Instance = this;
	}
	
	public void CallRestart() //public call for restart
	{
		restart();
	}
	private void restart() //reloads the scene
	{
		SceneManager.LoadScene("SampleScene");
	}
}
