﻿using _01.AppToTest.Contracts;
using System;

// Axe durability drop with 5 
public class Axe:IWeapon
{
    private int attackPoints;
    private int durabilityPoints;

    public Axe(int attack, int durability)
    {
        this.attackPoints = attack;
        this.durabilityPoints = durability;
    }

    public int AttackPoints => this.attackPoints;

    public int DurabilityPoints => this.durabilityPoints;

    public void Attack(ITarget target)
    {
        if (this.durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        this.durabilityPoints -= 1;
    }
}
