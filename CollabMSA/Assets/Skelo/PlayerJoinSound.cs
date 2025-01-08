using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerJoinSound : MonoBehaviourPunCallbacks
{

    [Header("Unknown")]
    [SerializeField] AudioSource playerJoinSound;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        playerJoinSound.Play();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        playerJoinSound.Play();
    }

    /*
    I (edward) still and obviously reserve full right to distribute, sell, use in my own game(s), app(s), and any other action with
    this script, forever

    Credits are not required
    */

}