using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    Player player;

    string animacaoatual;

    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_RUN = "Player_Run";
    const string PLAYER_JUMP = "Player_Jump";

    void TrocarAnimacao(string animacao)
    {
        if(animacaoatual == animacao)
        {
            return;
        }
        anim.Play(animacao);
        animacaoatual = animacao;
    }




    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();


    }

    void Update()
    {
        if (player.onGround)
        {
            if (player.horizontal != 0)
            {
                TrocarAnimacao(PLAYER_RUN);

            }
            else
            {
                TrocarAnimacao(PLAYER_IDLE);
            }
        }
        else
        {
            TrocarAnimacao(PLAYER_JUMP);
        }

        

    }
}
