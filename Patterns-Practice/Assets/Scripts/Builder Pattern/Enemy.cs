using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string Name {get; private set;}
    public int Health {get; private set;}
    public int Armor {get; private set;}
    public float Speed {get; private set;}
    public float Damage {get; private set;}

    public class Builder
    {
        public string name;
        public int health;
        public int armor;
        public float speed;
        public float damage;
        public Builder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public Builder WithHealth(int health)
        {
            this.health = health;
            return this;
        }

        public Builder WithArmor(int armor)
        {
            this.armor = armor;
            return this;
        }
        public Builder WithSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }
        public Builder WithDamage(float damage)
        {
            this.damage = damage;
            return this;
        }
        public Enemy Build()
        {
            Enemy enemy = new GameObject(name).AddComponent<Enemy>();
            enemy.Name = name;
            enemy.Armor = armor;
            enemy.Damage = damage;
            enemy.Speed = speed;
            enemy.Health = health;
            return enemy;
        }

    }

}
