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


    public float shootRate = 10f;//���٣�һ���ڿ��Դ���ٷ��ӵ���������С�������С�ڵ���0�����ǵ�����
    public float shootCoolDownTime = 0.75f;//����ģʽ����ȴʱ��
    public float recoilForce = 2f;//������

    public int maxBullets = 30;//�����ӵ�����
    public int bullets = 30;//��ǰ���ӵ�����
    public float reloadTime = 2f;//����ʱ��

    [HideInInspector]
    public bool isReloading = false;

    public GameObject graphics;
}
