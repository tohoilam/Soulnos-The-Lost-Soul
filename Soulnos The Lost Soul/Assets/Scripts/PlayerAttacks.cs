using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//public enum AttackMode
//{
//    Sword,
//    FireBall,
//}

public class PlayerAttacks : MonoBehaviour
{
    //public enum AttackMode { Sword, FireBall };
    public AttackModeClass.AttackMode initialAttackMode;
    public bool isAttackDirectionRight;
    public bool disableDuration;
    public GameObject fireball;
    public GameObject fireballAbilityObject;
    public GameObject swordAbilityExplosion;
    public GameObject swordAbilityExplosionReverse;
    public float explosionOffsetX;
    public float explosionOffsetY;
    public float explosionOffsetYVoid;

    // Audio
    public AudioClip swordSlashAudio;
    public AudioClip fireCastingAudio;
    public AudioClip swordAbilityAudio;
    public AudioClip fireCastingAbilityAudio;

    private AudioSource audioSource;

    //public bool killAttackAnimation;

    private PlayerMovementControl playerMovementControlScript;
    private PlayerStatistics playerStatistics;
    private AttackModeClass.AttackMode currentAttackMode;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool isSwordTriggerAllowed;
    private bool isVoid;
    private float rangeCastOffset;
    private float basicAttackCooldownDuration;
    private float attackTime;
    private bool isAttackAllowed;
    private bool isExplosionActivate;


    // Start is called before the first frame update
    void Start()
    {
        currentAttackMode = initialAttackMode;
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        playerMovementControlScript = this.GetComponent<PlayerMovementControl>();
        playerStatistics = this.GetComponent<PlayerStatistics>();
        isSwordTriggerAllowed = false;
        isAttackAllowed = true;
        GameObject.Find("RealityPlayerSwordAttackRight").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("RealityPlayerSwordAttackLeft").GetComponent<CircleCollider2D>().enabled = false;
        isVoid = playerMovementControlScript.negativeGravity;
        rangeCastOffset = isVoid ? 0.6f : 0.0f;
        basicAttackCooldownDuration = 0.6f;
        attackTime = -basicAttackCooldownDuration;
        isExplosionActivate = false;

        // Audio
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttackAllowed && Time.time > attackTime + basicAttackCooldownDuration)
        {
            isAttackAllowed = true;
        }

        if (Input.GetButtonDown("PowerUpAttack"))
        {
            if (playerStatistics.IsAbilityActivatable(currentAttackMode))
            {
                //isPowerUpAttack = true;
                playerStatistics.PowerUp(currentAttackMode);
                animator.SetTrigger("IsCastAbility");
            }

        }

        if (isAttackAllowed)
        {
            if (Input.GetButtonDown("BasicAttack"))
            {
                playerMovementControlScript.isMovementAllowed = false;
                attackTime = Time.time;
                isAttackAllowed = false;
                if (Input.GetAxis("BasicAttack") > 0)
                {
                    spriteRenderer.flipX = false;
                    isAttackDirectionRight = true;
                }
                else if (Input.GetAxis("BasicAttack") < 0)
                {
                    spriteRenderer.flipX = true;
                    isAttackDirectionRight = false;
                }

                switch (currentAttackMode)
                {
                    case AttackModeClass.AttackMode.Sword:
                        if (playerStatistics.GetIsPowerUpAttack(currentAttackMode))
                        {
                            animator.SetTrigger("IsSwordAbility");
                            playerStatistics.CastAbility(currentAttackMode);
                            isExplosionActivate = true;
                            audioSource.clip = swordAbilityAudio;
                            audioSource.Play();
                        }
                        else
                        {
                            animator.SetTrigger("IsSwordBasic");
                            audioSource.clip = swordSlashAudio;
                            audioSource.PlayDelayed(0.15f);
                        }
                        
                        break;
                    case AttackModeClass.AttackMode.FireBall:
                        animator.SetTrigger("IsFireCasting");
                        if (playerStatistics.GetIsPowerUpAttack(currentAttackMode))
                        {
                            Instantiate(fireballAbilityObject, this.transform.position + new Vector3(0, -0.3f + rangeCastOffset, 0), Quaternion.identity);
                            playerStatistics.CastAbility(currentAttackMode);
                            audioSource.clip = fireCastingAbilityAudio;
                            audioSource.Play();
                        }
                        else
                        {
                            Instantiate(fireball, this.transform.position + new Vector3(0, -0.3f + rangeCastOffset, 0), Quaternion.identity);
                            audioSource.clip = fireCastingAudio;
                            audioSource.Play();
                        }

                        break;
                }

            }
        }
    }

    public void FinishAttackAnimation()
    {
        playerMovementControlScript.isMovementAllowed = true;
    }

    public void SowrdFinishAttackAnimation()
    {
        playerMovementControlScript.isMovementAllowed = true;
        GameObject.Find("RealityPlayerSwordAttackRight").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("VoidPlayerSwordAttackRight").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("RealityPlayerSwordAttackLeft").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("VoidPlayerSwordAttackLeft").GetComponent<CircleCollider2D>().enabled = false;
    }

    public void TriggerSowrdCollision()
    {
        isSwordTriggerAllowed = true;
        if (isAttackDirectionRight)
        {
            if (isVoid)
            {
                GameObject.Find("VoidPlayerSwordAttackRight").GetComponent<CircleCollider2D>().enabled = true;
            }
            else
            {
                GameObject.Find("RealityPlayerSwordAttackRight").GetComponent<CircleCollider2D>().enabled = true;
            }
            
            
        }
        else
        {
            if (isVoid)
            {
                GameObject.Find("VoidPlayerSwordAttackLeft").GetComponent<CircleCollider2D>().enabled = true;
            }
            else
            {
                GameObject.Find("RealityPlayerSwordAttackLeft").GetComponent<CircleCollider2D>().enabled = true;
            }
            
            
        }

        if (isExplosionActivate)
        {
            float directionMultiplication = isAttackDirectionRight ? 1.0f : -1.0f;
            if (isVoid)
            {
                Instantiate(swordAbilityExplosionReverse, this.transform.position + new Vector3(directionMultiplication * explosionOffsetX, explosionOffsetYVoid, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(swordAbilityExplosion, this.transform.position + new Vector3(directionMultiplication * explosionOffsetX, explosionOffsetY, 0), Quaternion.identity);
            }
            
            isExplosionActivate = false;
        }
    }

    public AttackModeClass.AttackMode getCurrentAttackMode()
    {
        return this.currentAttackMode;
    }

    public void setCurrentAttackMode(AttackModeClass.AttackMode newAttackMode)
    {
        this.currentAttackMode = newAttackMode;
        this.playerStatistics.SetCurrentAttackMode(currentAttackMode);
    }
}
