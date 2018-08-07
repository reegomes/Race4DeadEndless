using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JumpButtom : MonoBehaviour, IPointerClickHandler{

    [SerializeField]
    private Player player;
    

    public virtual void OnPointerClick(PointerEventData ped)
    {
        player.Jump();
    }
}
