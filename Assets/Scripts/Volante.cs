using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class Volante : MonoBehaviour
{
    public Graphic UI_Element;

    RectTransform rectT;
    Vector2 pontoCentral;

    public float maxGiro = 60f;
    public float velRetorno = 300f;

    float anguloVolante = 0f;
    float anguloAnterior = 0f;

    bool tocandoVolante = false;

    

    void Start()
    {
        rectT = UI_Element.rectTransform;
        InitEventsSystem();
    }

    void Update()
    {
        //Verifica se o volante esta sendo tocado e se o angulo já está zerado
        if (!tocandoVolante && !Mathf.Approximately(0f, anguloVolante))
        {
            //Faz o volante retornar ao ponto 0f com velocidade do velRetorno
            float vel = velRetorno * Time.deltaTime;
            if (Mathf.Abs(vel) > Mathf.Abs(anguloVolante))
                anguloVolante = 0f;
            else if (anguloVolante > 0f)
                anguloVolante -= vel;
            else
                anguloVolante += vel;
        }

        // Rotaciona a imagem
        rectT.localEulerAngles = Vector3.back * anguloVolante;
    }

    void InitEventsSystem()
    {
        //Cria um EventTrigger do Canvas Element
        EventTrigger events = UI_Element.gameObject.GetComponent<EventTrigger>();

        //Adiciona todos os eventos possiveis do EventTrigger
        if (events == null)
            events = UI_Element.gameObject.AddComponent<EventTrigger>();

        // Adiciona todos os triggers possiveis do EventTrigger
        if (events.triggers == null)
            events.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();

        //Cria e configura o Event Trigger e o callback para interações no canvas
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.TriggerEvent callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> functionCall = new UnityAction<BaseEventData>(PressEvent);

        //Cria um callback de chamada de evento
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.PointerDown;//Toque na tela
        entry.callback = callback;

        events.triggers.Add(entry);

        //Configura o Event trigger  para ser um callback do DragEvent
        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>(DragEvent);

        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.Drag;
        entry.callback = callback;

        events.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>(ReleaseEvent);
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback = callback;

        events.triggers.Add(entry);
    }

    public void PressEvent(BaseEventData eventData)
    {
        // Chama a posicao quando o event data do tocar for ativado
        Vector2 pointerPos = ((PointerEventData)eventData).position;

        //Pega o toque na tela e configura o ponto central para determinar a rotação do volante
        tocandoVolante = true;
        pontoCentral = RectTransformUtility.WorldToScreenPoint(((PointerEventData)eventData).pressEventCamera, rectT.position);
        anguloAnterior = Vector2.Angle(Vector2.up, pointerPos - pontoCentral);
    }

    public void DragEvent(BaseEventData eventData)
    {
        // Ativa o Drag para fazer com que o volate comece a rotacionar
        Vector2 pointerPos = ((PointerEventData)eventData).position;

        float wheelNewAngle = Vector2.Angle(Vector2.up, pointerPos - pontoCentral);
        // Nao ativa nada caso o ponto esteja proximo ao ponto central
        if (Vector2.Distance(pointerPos, pontoCentral) > 20f)
        {
            if (pointerPos.x > pontoCentral.x)
                anguloVolante += wheelNewAngle - anguloAnterior;
            else
                anguloVolante -= wheelNewAngle - anguloAnterior;
        }
        // Garante que não vá ultrapassar o giro maximo determinado
        anguloVolante = Mathf.Clamp(anguloVolante, -maxGiro, maxGiro);
        anguloAnterior = wheelNewAngle;
    }

    public void ReleaseEvent(BaseEventData eventData)
    {
        // Larga o volante quando parar o toque. Garante um ultimo drag para evitar erros de giro
        DragEvent(eventData);

        tocandoVolante = false;
    }

    public float GetClampedValue()
    {
        // Uma simulação do Axis [-1,1]
        return anguloVolante / maxGiro;
    }

    public float GetAngle()
    {
        return anguloVolante;
    }
}