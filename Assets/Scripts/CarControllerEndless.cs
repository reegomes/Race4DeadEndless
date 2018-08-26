using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[System.Serializable]
public class Dot_Truck : System.Object
{
    public WheelCollider leftWheel;
    public GameObject leftWheelMesh;
    public WheelCollider rightWheel;
    public GameObject rightWheelMesh;
    public bool motor;
    public bool steering;
    public bool reverseTurn;
}

public class CarControllerEndless : MonoBehaviour
{
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public List<Dot_Truck> truck_Infos;
    public AudioSource audioEngine;
    float motor, gas, gasTiming;
    [SerializeField]
    float Whelllow;
    bool nitroOk;
    int nNitros;
    Rigidbody rb;
    // Variaveis do tutorial da unity
    public Graphic UI_Wheel;
    RectTransform rectT;
    Vector2 centerPoint;
    public float maximumSteeringAngle = 35f;
    public float wheelReleasedSpeed = 35f;
    float wheelAngle = 0f;
    float wheelPrevAngle = 0f;
    float Wheel;
    bool wheelBeingHeld = false;
    public static bool neon;
    int life;
    // Fim

    [SerializeField]
    float speed;
    public GameObject NitroP, Blur, Neon;

    public void VisualizeWheel(Dot_Truck wheelPair)
    {
        Quaternion rot;
        Vector3 pos;
        wheelPair.leftWheel.GetWorldPose(out pos, out rot);
        wheelPair.leftWheelMesh.transform.position = pos;
        wheelPair.leftWheelMesh.transform.rotation = rot;
        wheelPair.rightWheel.GetWorldPose(out pos, out rot);
        wheelPair.rightWheelMesh.transform.position = pos;
        wheelPair.rightWheelMesh.transform.rotation = rot;
    }
    void Start()
    {
        audioEngine = GetComponent<AudioSource>();
        rectT = UI_Wheel.rectTransform;
        InitEventsSystem();
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        // Cases
        switch (ShopStats.gas)
        {
            case 1:
                gas = 200;
                break;
            case 2:
                gas = 300;
                break;
            case 3:
                gas = 500;
                break;
            case 5:
                gas = 700;
                break;
            case 6:
                gas = 1000;
                break;
            default:
                gas = 60;
                break;
        }
        switch (ShopStats.velocity)
        {
            case 1:
                speed = 20;
                life = 20;
                break;
            case 2:
                speed = 30;
                life = 30;
                break;
            case 3:
                speed = 40;
                life = 50;
                break;
            case 4:
                speed = 50;
                nitroOk = true;
                nNitros = 1;
                life = 100;
                Archievements.NitroIsEnable = true;
                break;
            case 5:
                speed = 60;
                nitroOk = true;
                nNitros = 3;
                life = 200;
                Archievements.NitroIsEnable = true;
                break;
            default:
                speed = 10;
                life = 10;
                break;
        }
        switch (ShopStats.mass)
        {
            default:
                rb.mass = 850;
                break;
            case 1:
                rb.mass = 950;
                break;
            case 2:
                rb.mass = 1050;
                break;
            case 3:
                rb.mass = 1150;
                break;
            case 4:
                rb.mass = 1550;
                break;
            case 5:
                rb.mass = 2550;
                break;
        }
        // Fim do Switch

        Wheel = wheelAngle / maximumSteeringAngle;
        Whelllow = Wheel;
        //motor = maxMotorTorque * Input.GetAxis("Vertical");
        motor = maxMotorTorque * speed * Time.deltaTime;

        float steering = maxSteeringAngle * Wheel;
        float brakeTorque = Mathf.Abs(Whelllow);
        if (brakeTorque > 0.90 || SwipeController.Instance.IsSwiping(SwipeDirection.Down))
        {
            brakeTorque = maxMotorTorque;
            motor--;
            //Desacelera o carro conforme a curva
        }
        else
        {
            brakeTorque = 0;
        }

        foreach (Dot_Truck truck_Info in truck_Infos)
        {
            if (truck_Info.steering == true)
            {
                truck_Info.leftWheel.steerAngle = truck_Info.rightWheel.steerAngle = ((truck_Info.reverseTurn) ? -1 : 1) * steering;
            }

            if (truck_Info.motor == true)
            {
                truck_Info.leftWheel.motorTorque = motor;
                truck_Info.rightWheel.motorTorque = motor;
            }

            truck_Info.leftWheel.brakeTorque = brakeTorque;
            truck_Info.rightWheel.brakeTorque = brakeTorque;

            VisualizeWheel(truck_Info);
        }

        EngineSound();
        //Debug.Log("brakeTorque" + brakeTorque);
        //Debug.Log("maxMotorTorque" + maxMotorTorque);
        //Debug.Log("motor" + motor);

        //Quando o volante é solto, ele reseta a rotação.
        if (!wheelBeingHeld && !Mathf.Approximately(0f, wheelAngle))
        {
            float deltaAngle = wheelReleasedSpeed * Time.deltaTime;
            if (Mathf.Abs(deltaAngle) > Mathf.Abs(wheelAngle))
            {
                wheelAngle = 0f;
            }
            else if (wheelAngle > 0f)
            {
                wheelAngle -= deltaAngle;
            }
            else
            {
                wheelAngle += deltaAngle;
            }
        }
        // Roda a imagem
        rectT.localEulerAngles = Vector3.back * 2 * wheelAngle;
        // Neon
        if(neon == true){
            Neon.SetActive(true);
        }
        else
        {
            Neon.SetActive(false);
        }
        if (gas <= 0){
            maxMotorTorque = 0;
        }
    }
    private void OnCollisionEnter(Collision zombie)
    {
        if(this.gameObject.CompareTag("Zombie")){
            life--;
            gas--;
        }
    }
    public void EngineSound()
    {
        audioEngine.pitch = motor / maxMotorTorque + 0x1;
    }
    public float GetClampedValue()
    {
        // retorna um valor de -1 ou 1, similar ao getaxis"horizontal"
        return wheelAngle / maximumSteeringAngle;
    }
    public float GetAngle()
    {
        // Retorna o angulo do volante ao valor dele mesmo sem o clamp
        return wheelAngle;
    }
    void InitEventsSystem()
    {
        // Warning: Be ready to see some extremely boring code here :-/
        // You are warned!
        EventTrigger events = UI_Wheel.gameObject.GetComponent<EventTrigger>();

        if (events == null)
            events = UI_Wheel.gameObject.AddComponent<EventTrigger>();

        if (events.triggers == null)
            events.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.TriggerEvent callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> functionCall = new UnityAction<BaseEventData>(PressEvent);
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback = callback;

        events.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>(DragEvent);
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.Drag;
        entry.callback = callback;

        events.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>(ReleaseEvent);//
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback = callback;

        events.triggers.Add(entry);
    }

    public void PressEvent(BaseEventData eventData)
    {
        // Executed when mouse/finger starts touching the steering wheel
        Vector2 pointerPos = ((PointerEventData)eventData).position;

        wheelBeingHeld = true;
        centerPoint = RectTransformUtility.WorldToScreenPoint(((PointerEventData)eventData).pressEventCamera, rectT.position);
        wheelPrevAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);
    }
    public void DragEvent(BaseEventData eventData)
    {
        // Executed when mouse/finger is dragged over the steering wheel
        Vector2 pointerPos = ((PointerEventData)eventData).position;

        float wheelNewAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);
        // Do nothing if the pointer is too close to the center of the wheel
        if (Vector2.Distance(pointerPos, centerPoint) > 20f)
        {
            if (pointerPos.x > centerPoint.x)
                wheelAngle += wheelNewAngle - wheelPrevAngle;
            else
                wheelAngle -= wheelNewAngle - wheelPrevAngle;
        }
        // Make sure wheel angle never exceeds maximumSteeringAngle
        wheelAngle = Mathf.Clamp(wheelAngle, -maximumSteeringAngle, maximumSteeringAngle);
        wheelPrevAngle = wheelNewAngle;
    }

    public void ReleaseEvent(BaseEventData eventData)
    {
        // Executed when mouse/finger stops touching the steering wheel
        // Performs one last DragEvent, just in case
        DragEvent(eventData);

        wheelBeingHeld = false;
    }
    void Awake()
    {
        StartCoroutine("UpdateFake");
    }
    IEnumerator Nitro()
    {
        yield return new WaitForSeconds(0.5f);
        //if (SwipeController.Instance.IsSwiping(SwipeDirection.Up) && nitroOk == true && nNitros >= 1)
        if (SwipeController.Instance.IsSwiping(SwipeDirection.Up))
        {
            maxMotorTorque = 300;
            //CameraScript.pov = true;
            NitroP.SetActive(true);
            Blur.SetActive(true);
            nNitros--;
        }
        else if (SwipeController.Instance.IsSwiping(SwipeDirection.None))
        {
            Debug.Log("Voltei ao normal");
            NitroP.SetActive(false);
            Blur.SetActive(false);
            StartCoroutine("Back");
        }
    }
    IEnumerator UpdateFake()
    {
        yield return new WaitForSeconds(0.05f);
        StartCoroutine("UpdateFake");
        StartCoroutine("Nitro");
    }
    IEnumerator Back()
    {
        yield return new WaitForSeconds(2f);
        maxMotorTorque = 60;
        //CameraScript.pov = false;
    }
}