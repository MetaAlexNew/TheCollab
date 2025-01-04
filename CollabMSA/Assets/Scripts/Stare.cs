using UnityEngine;

public class Stare : MonoBehaviour
{
	public Transform playerCam;

	public Transform Gameobject;

	private void Update()
	{
		Gameobject.LookAt(playerCam);
	}
}
