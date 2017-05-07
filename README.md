### CentralEventManager Usage

#### Add custom Event Code
You can simply use any `enum` as the Event Code.

```csharp
public enum EventCodeA {
    eventA1,
    eventA2
}

```

#### Add custom Event Args
The Event Args of this CentralEventManager is based on `System.EventArgs` in .NET.

```csharp
public class CustomArgs : EventArgs {
    private int m_number;
    public int number {
        get {
            return m_number;
        }
    }
    public CustomArgs (int num) {
        m_number = num;
    }
}

```

#### Register or Unregister callback
The CentralEventManager is a singleton-based class, so you won't need to do any initialization before using.

```csharp
CentralEventManager.RegisterCallback<EventCodeA> (EventCodeA.eventA1, CallbackA);
CentralEventManager.UnregisterCallback<EventCodeA> (EventCodeA.eventA1, CallbackA);

```

#### Notify events
There are two Notify functions, with or without event args to send.

```csharp
CentralEventManager.Notify<EventCodeA> (EventCodeA.eventA1);
CentralEventManager.Notify<EventCodeB> (EventCodeA.eventA2, new CustomArgs(10));

```