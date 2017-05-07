using System;
using UnityEngine;
using DouduckGame.EventManager;

public enum EventCodeA {
    eventA1,
    eventA2
}

public enum EventCodeB {
    eventB1,
    eventB2
}

public class EventBArgs : EventArgs {
    private int m_number;
    public int number {
        get {
            return m_number;
        }
    }
    public EventBArgs (int num) {
        m_number = num;
    }
}

public class Example : MonoBehaviour {

    void Start () {
        CentralEventManager.RegisterCallback<EventCodeA> (EventCodeA.eventA1, CallbackA);
        CentralEventManager.RegisterCallback<EventCodeB> (EventCodeB.eventB1, CallbackB);

        CentralEventManager.Notify<EventCodeA> (EventCodeA.eventA1);
        CentralEventManager.Notify<EventCodeA> (EventCodeA.eventA2);
        CentralEventManager.Notify<EventCodeB> (EventCodeB.eventB1, new EventBArgs(10));
    }

    private void CallbackA(EventCodeA code, EventArgs args) {
        Debug.Log ("Callback of EventCodeA." + code);
    }

    private void CallbackB (EventCodeB code, EventArgs args) {
        EventBArgs eventBArgs = args as EventBArgs;
        Debug.Log ("Callback of EventCodeB." + code + ", EventBArgs.number = " + eventBArgs.number);
    }

}
