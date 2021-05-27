using System;

public interface IEvent<T>
{
    event Action<T> OnEventRised;
    void RisedEvent(T value);
}
