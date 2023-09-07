using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerWeapon
{
    public string name = "M16A1";
    public int damage = 10;
    public float range = 100f;


    public float shootRate = 10f;//射速，一秒内可以打多少发子弹，可以是小数；如果小于等于0，则是单发。
    public float shootCoolDownTime = 0.75f;//单发模式的冷却时间
    public float recoilForce = 2f;//后坐力

    public int maxBullets = 30;//最多的子弹数量
    public int bullets = 30;//当前的子弹数量
    public float reloadTime = 2f;//换弹时间

    [HideInInspector]
    public bool isReloading = false;

    public GameObject graphics;
}
