using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    struct AttackModeStats
    {
        public float abilityCooldown;
        public float lastCastingTime;
        public bool isActivatable;
        public bool isPowerUpAttack;
    }

    AttackModeStats fireball;
    AttackModeStats sword;

    public float maxHealth;
    public float damageDealt;


    private AttackModeClass.AttackMode currentAttackMode;
    public float currentHealth;
    private GameObject HealthBar;
    private GameObject CooldownBar;
    private float healthBarLength;
    private float cooldownBarHeight;
    private float cooldownBarYPosition;
    private Animator animator;
    private SpriteRenderer cooldownBarSpriteRenderer;
    private GameObject gameManagement;


    void Start()
    {
        fireball = new AttackModeStats();
        fireball.abilityCooldown = 15.0f;
        fireball.lastCastingTime = -15.0f;
        fireball.isActivatable = true;
        fireball.isPowerUpAttack = false;

        sword = new AttackModeStats();
        sword.abilityCooldown = 15.0f;
        sword.lastCastingTime = -15.0f;
        sword.isActivatable = true;
        sword.isPowerUpAttack = false;

        animator = this.GetComponent<Animator>();
        gameManagement = GameObject.Find("GameManagement");

        currentHealth = maxHealth;

        this.HealthBar = this.transform.Find("HealthBar").transform.Find("HealthBar").transform.Find("Health").gameObject;
        this.CooldownBar = this.transform.Find("HealthBar").transform.Find("CooldownBar").transform.Find("Cooldown").gameObject;
        this.healthBarLength = this.HealthBar.transform.localScale.x;
        this.cooldownBarHeight = this.CooldownBar.transform.localScale.y;
        this.cooldownBarYPosition = this.CooldownBar.transform.localPosition.y;

        cooldownBarSpriteRenderer = this.CooldownBar.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (this.currentAttackMode == AttackModeClass.AttackMode.FireBall)
        {
            float barPercentage = (Time.time - this.fireball.lastCastingTime) / this.fireball.abilityCooldown;
            if (barPercentage > 1)
            {
                barPercentage = 1;
                this.cooldownBarSpriteRenderer.color = new Color(0, 255, 0, 255);
            }
            else
            {
                this.cooldownBarSpriteRenderer.color = new Color(255, 255, 0, 255);
            }
            this.CooldownBar.transform.localScale = new Vector3(this.CooldownBar.transform.localScale.x, this.cooldownBarHeight * barPercentage, this.CooldownBar.transform.localScale.z);
            this.CooldownBar.transform.localPosition = new Vector3(this.CooldownBar.transform.localPosition.x, this.cooldownBarYPosition + (1 - barPercentage) / -2, this.CooldownBar.transform.localPosition.z);
        }
        else
        {
            float barPercentage = (Time.time - this.sword.lastCastingTime) / this.sword.abilityCooldown;
            if (barPercentage > 1)
            {
                barPercentage = 1;
                this.cooldownBarSpriteRenderer.color = new Color(0, 255, 0, 255);
            }
            else
            {
                this.cooldownBarSpriteRenderer.color = new Color(255, 255, 0, 255);
            }
            this.CooldownBar.transform.localScale = new Vector3(this.CooldownBar.transform.localScale.x, this.cooldownBarHeight * barPercentage, this.CooldownBar.transform.localScale.z);
            this.CooldownBar.transform.localPosition = new Vector3(this.CooldownBar.transform.localPosition.x, this.cooldownBarYPosition + (1 - barPercentage) / -2, this.CooldownBar.transform.localPosition.z);
        }

        checkOutOfScreen();
    }

    private void checkOutOfScreen()
    {
        if (this.transform.position.y > 8f || this.transform.position.y < -8f)
        {
            this.PlayerDie();
        }
    }

    public void SetCurrentAttackMode(AttackModeClass.AttackMode newAttackMode)
    {
        this.currentAttackMode = newAttackMode;
    }

    public bool GetIsPowerUpAttack(AttackModeClass.AttackMode attackMode)
    {
        if (attackMode == AttackModeClass.AttackMode.FireBall)
        {
            return this.fireball.isPowerUpAttack;
        }
        else
        {
            return this.sword.isPowerUpAttack;
        }
    }

    public void SetIsPowerUpAttack(AttackModeClass.AttackMode attackMode, bool isPowerUpAttack)
    {
        if (attackMode == AttackModeClass.AttackMode.FireBall)
        {
            this.fireball.isPowerUpAttack = isPowerUpAttack;
        }
        else
        {
            this.sword.isPowerUpAttack = isPowerUpAttack;
        }
    }

    public void PowerUp(AttackModeClass.AttackMode attackMode)
    {
        this.SetIsPowerUpAttack(attackMode, true);
        this.ActivateAbility(attackMode);
    }

    public float GetAbilityCooldown(AttackModeClass.AttackMode attackMode)
    {
        if (attackMode == AttackModeClass.AttackMode.FireBall)
        {
            return this.fireball.abilityCooldown;
        }
        else
        {
            return this.sword.abilityCooldown;
        }
    }

    public float GetLastCastingTime(AttackModeClass.AttackMode attackMode)
    {
        if (attackMode == AttackModeClass.AttackMode.FireBall)
        {
            return this.fireball.lastCastingTime;
        }
        else
        {
            return this.sword.lastCastingTime;
        }
    }

    public void CastAbility(AttackModeClass.AttackMode attackMode)
    {
        if (attackMode == AttackModeClass.AttackMode.FireBall)
        {
            this.fireball.lastCastingTime = Time.time;
        }
        else
        {
            this.sword.lastCastingTime = Time.time;
        }
        this.SetIsPowerUpAttack(attackMode, false);
    }

    public void ActivateAbility(AttackModeClass.AttackMode attackMode)
    {
        if (attackMode == AttackModeClass.AttackMode.FireBall)
        {
            this.fireball.isActivatable = false;
        }
        else
        {
            this.sword.isActivatable = false;
        }
    }

    public bool IsAbilityActivatable(AttackModeClass.AttackMode attackMode)
    {
        if (attackMode == AttackModeClass.AttackMode.FireBall)
        {
            if (!this.fireball.isPowerUpAttack && Time.time > this.fireball.lastCastingTime + this.fireball.abilityCooldown)
            {
                this.fireball.isActivatable = true;
            }
            else
            {
                this.fireball.isActivatable = false;
            }
            return this.fireball.isActivatable;
        }
        else
        {
            if (!this.sword.isPowerUpAttack && Time.time > this.sword.lastCastingTime + this.sword.abilityCooldown)
            {
                this.sword.isActivatable = true;
            }
            else
            {
                this.sword.isActivatable = false;
            }
            return this.sword.isActivatable;
        }
    }

    public void GotAttacked(float specialDamageDealt = 0)
    {
        if (specialDamageDealt == 0)
        {
            currentHealth -= damageDealt;
        }
        else
        {
            currentHealth -= specialDamageDealt;
        }
        
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        this.HealthBar.transform.localScale = new Vector3(this.healthBarLength * (currentHealth / maxHealth), this.HealthBar.transform.localScale.y, this.HealthBar.transform.localScale.z);
        this.HealthBar.transform.localPosition = new Vector3((1 - (currentHealth / maxHealth)) * -2, 0, 0);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("IsDeath");
            this.gameManagement.GetComponent<GameManagement>().PlayerDied();
            Destroy(this.gameObject, 0.833f);
        }
        else
        {
            animator.SetTrigger("IsHurt");
            
        }
        
    }

    public void RecoverHealth()
    {
        currentHealth = maxHealth;
        this.HealthBar.transform.localScale = new Vector3(this.healthBarLength * (currentHealth / maxHealth), this.HealthBar.transform.localScale.y, this.HealthBar.transform.localScale.z);
        this.HealthBar.transform.localPosition = new Vector3((1 - (currentHealth / maxHealth)) * -2, 0, 0);
    }

    public void PlayerDie(float destroyDelayTime = 0f)
    {
        currentHealth = 0;

        this.HealthBar.transform.localScale = new Vector3(this.healthBarLength * (currentHealth / maxHealth), this.HealthBar.transform.localScale.y, this.HealthBar.transform.localScale.z);
        this.HealthBar.transform.localPosition = new Vector3((1 - (currentHealth / maxHealth)) * -2, 0, 0);

        animator.SetTrigger("IsDeath");
        this.gameManagement.GetComponent<GameManagement>().PlayerDied();
        Destroy(this.gameObject, destroyDelayTime);
    }

    public void HideColor()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.transform.GetChild(3).gameObject.SetActive(false);
    }
}
