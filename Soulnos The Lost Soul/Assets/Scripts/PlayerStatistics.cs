using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    private float fireballAbilityCooldown;
    private float fireballLastCastingTime;
    private bool isFireballCastingAvailable;

    void Start()
    {
        fireballAbilityCooldown = 15.0f;
        fireballLastCastingTime = -15.0f;
    }

    public float GetFireballAbilityCooldown()
    {
        return this.fireballAbilityCooldown;
    }

    public float GetFireballAbilityLastCastingTime()
    {
        return this.fireballLastCastingTime;
    }

    public void CastFireballAbility()
    {
        fireballLastCastingTime = Time.time;
    }

    public bool IsFireballAbilityCastingAvailable()
    {
        return Time.time > fireballLastCastingTime + fireballAbilityCooldown;
    }
}
