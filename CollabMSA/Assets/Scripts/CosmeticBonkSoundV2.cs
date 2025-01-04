using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CosmeticBonkSoundV2 : MonoBehaviour
{
    [Header("This is the tag it will detect to play the sound effect aka your head tag")]
    public string cameraTag;

    [Header("This is the sound it will play when activated")]
    public AudioSource bonkSound;

    [Header("This is the photon view that goes on the hammer")]
    public PhotonView photonView;

    [Header("This is the player view so it will disable the bonk on yourself")]
    public PhotonView MyView;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(cameraTag))
        {
            if (MyView.IsMine)
            {
                return;
            }
            else
            {
                photonView.RPC("FireBonk", RpcTarget.All);
            }
        }     
    }

    [PunRPC]

    private void FireBonk()
    {
        bonkSound.Play();
    }
}
