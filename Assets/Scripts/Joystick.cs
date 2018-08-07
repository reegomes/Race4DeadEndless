using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

    private Image bgJoyImg;
    private Image joyImg;
    public Vector3 inputDirection;

    public void Start(){
        bgJoyImg = GetComponent<Image>();
        joyImg = transform.GetChild(0).GetComponent<Image>();
        joyImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public virtual void OnDrag(PointerEventData ped){

        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            bgJoyImg.rectTransform, 
            ped.position,
            ped.enterEventCamera,
            out pos)) {
                pos.x = pos.x / bgJoyImg.rectTransform.sizeDelta.x * 2;
                pos.y = pos.y / bgJoyImg.rectTransform.sizeDelta.y * 2;          

                inputDirection = new Vector3(pos.x, 0.0f, pos.y);

                if (inputDirection.magnitude > 1)
                {
                    inputDirection = inputDirection.normalized;
                }
                float posX = inputDirection.x * (bgJoyImg.rectTransform.sizeDelta.x / 2)    ;
                float posY = inputDirection.z * (bgJoyImg.rectTransform.sizeDelta.y / 2);
                joyImg.rectTransform.anchoredPosition = new Vector3( posX, posY);
        }
    }

    public virtual void OnPointerUp(PointerEventData ped){
        inputDirection = Vector3.zero;
        joyImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public virtual void OnPointerDown(PointerEventData ped) {
        OnDrag(ped);
    }

   



}
