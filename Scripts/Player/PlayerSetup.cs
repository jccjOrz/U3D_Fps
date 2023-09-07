using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] componentsToDisable; //Behaviour ��ָ�����û���õ������

    private Camera SceneCamera;

    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
   
       if (!IsLocalPlayer)
        {
            SetLayerMaskForAllChildren(transform, LayerMask.NameToLayer("Remote Player"));
            DisableComponents();
        }
        else
        {
            PlayerUI.Singleton.setPlayer(GetComponent<Player>());
            SetLayerMaskForAllChildren(transform, LayerMask.NameToLayer("Player"));
            SceneCamera = Camera.main;
            if (SceneCamera != null)
            {
                SceneCamera.gameObject.SetActive(false); //�����������Ϊ�ǻ�Ծ״̬
            }
        }
        string name = "Player " + GetComponent<NetworkObject>().NetworkObjectId.ToString();
        Player player = GetComponent<Player>();
        player.Setup();
        GameManager.Singleton.RegisterPlayer(name, player);
    }
    private void SetLayerMaskForAllChildren(Transform transform,LayerMask layerMask)
    {
        transform.gameObject.layer=layerMask;
        for(int i = 0; i < transform.childCount; i++)
        {
            SetLayerMaskForAllChildren(transform.GetChild(i), layerMask);
        }
    }

    private void DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
            componentsToDisable[i].enabled = false; //���õ����Եĳ�ȥ�Լ���������
    }
    //������˳�ʱ���Զ�����
    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        if (SceneCamera != null)
        {
            SceneCamera.gameObject.SetActive(true);
        }
        GameManager.Singleton.UnRegisterPlayer(transform.name);
    }
 
}

