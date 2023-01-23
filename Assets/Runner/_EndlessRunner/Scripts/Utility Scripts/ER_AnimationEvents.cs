using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_AnimationEvents : MonoBehaviour
{
    private ER_PlayerController playerController;

    private Animator anim;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<ER_PlayerController>();

        anim = GetComponent<Animator>();



    }

    void ResetShooting()
    {
        playerController.canShoot = true;

        anim.Play("Anim_ShootBar_Idle");

    }

}
