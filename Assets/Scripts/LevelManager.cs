using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

	public void LoadLevel (string name)
	{
		Application.LoadLevel (name);
	}
	
	public void LoadNextLevel (string name)
	{
		Application.LoadLevel (name);
	}

	public void QuitRequest ()
	{
		Application.Quit ();
	}
}
