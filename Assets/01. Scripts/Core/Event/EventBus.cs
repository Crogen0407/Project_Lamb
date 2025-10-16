using System;
using UnityEngine;

namespace Project_Lamb
{
    public static class EventBus<T> where T : struct, IGameEvent
    {
        public delegate void Event(T evt);
        public static Event OnEvent;

        public static void Publish(T evt) => OnEvent?.Invoke(evt);
    }
}
