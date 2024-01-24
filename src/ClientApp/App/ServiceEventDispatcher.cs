using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client
{
    public class ServiceEventDispatcher
    {
        public static List<NotifiedEvent> CallServiceAndDispatchImmediateEventNotification<T1>(Func<T1, List<NotifiedEvent>> serviceOperation, T1 argument1)
        {
            List<NotifiedEvent> notifiedEvents = serviceOperation(argument1);
            DispatchEvents(notifiedEvents);
            return notifiedEvents;
        }

        public static T1 CallServiceAndDispatchImmediateEventNotification<T1>(ApplicationEvent @event, Func<T1, List<NotifiedEvent>> serviceOperation, T1 argument1) where T1 : DomainObject
        {
            List<NotifiedEvent> notifiedEvents = CallServiceAndDispatchImmediateEventNotification(serviceOperation,
                                                                                                  argument1);
            return FindDomainObjectByEvent<T1>(notifiedEvents, @event);
        }

        public static T1 CallServiceAndDispatchImmediateEventNotification<T1, T2>(ApplicationEvent @event, Func<T1, T2, List<NotifiedEvent>> serviceOperation, T1 argument1, T2 argument2) where T1 : DomainObject
        {
            List<NotifiedEvent> notifiedEvents = CallServiceAndDispatchImmediateEventNotification(serviceOperation, argument1, argument2);
            return FindDomainObjectByEvent<T1>(notifiedEvents, @event);
        }

        private static T FindDomainObjectByEvent<T>(List<NotifiedEvent> events, ApplicationEvent @event) where T : DomainObject
        {
            NotifiedEvent findDomainObjectByEvent = events.Find(obj => obj.ApplicationEvent == @event && obj.DomainObject is T);
            return (T)findDomainObjectByEvent.DomainObject;
        }
        
        public static List<NotifiedEvent> CallServiceAndDispatchImmediateEventNotification<T1, T2>(
            Func<T1, T2, List<NotifiedEvent>> serviceOperation,
            T1 argument1, T2 argument2)
        {
            List<NotifiedEvent> notifiedEvents = serviceOperation(argument1, argument2);
            DispatchEvents(notifiedEvents);
            return notifiedEvents;
        }

        public static List<NotifiedEvent> CallServiceAndDispatchImmediateEventNotification<T1, T2, T3>(
            Func<T1, T2, T3, List<NotifiedEvent>> serviceOperation,
            T1 argument1, T2 argument2, T3 argument3)
        {
            List<NotifiedEvent> notifiedEvents = serviceOperation(argument1, argument2, argument3);
            DispatchEvents(notifiedEvents);
            return notifiedEvents;
        }

        public static void CallServiceAndDispatchImmediateEventNotification<T1, T2, T3, T4>(
            Func<T1, T2, T3, T4, List<NotifiedEvent>> serviceOperation,
            T1 argument1, T2 argument2, T3 argument3, T4 argument4)
        {
            List<NotifiedEvent> notifiedEvents = serviceOperation(argument1, argument2, argument3, argument4);
            DispatchEvents(notifiedEvents);
        }

        public static void CallServiceAndDispatchImmediateEventNotification<T1, T2, T3, T4, T5>(
            Common.Utility.Func<T1, T2, T3, T4, T5, List<NotifiedEvent>> serviceOperation,
            T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5)
        {
            List<NotifiedEvent> notifiedEvents = serviceOperation(argument1, argument2, argument3, argument4, argument5);
            DispatchEvents(notifiedEvents);
        }

        public static void CallServiceAndDispatchImmediateEventNotification<T1, T2, T3, T4, T5, T6>(
            Common.Utility.Func<T1, T2, T3, T4, T5, T6, List<NotifiedEvent>> serviceOperation,
            T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6)
        {
            List<NotifiedEvent> notifiedEvents = serviceOperation(argument1, argument2, argument3, argument4, argument5, argument6);
            DispatchEvents(notifiedEvents);
        }

        public static void CallServiceAndDispatchImmediateEventNotification<T1, T2, T3, T4, T5, T6, T7>(
           Common.Utility.Func<T1, T2, T3, T4, T5, T6, T7, List<NotifiedEvent>> serviceOperation,
           T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7)
        {
            List<NotifiedEvent> notifiedEvents = serviceOperation(
                argument1, argument2, argument3, argument4, argument5, argument6, argument7);
            DispatchEvents(notifiedEvents);
        }

        public static void DispatchEvents(List<NotifiedEvent> notifiedEvents)
        {
            foreach (NotifiedEvent notifiedEvent in notifiedEvents)
            {
                ClientServiceRegistry.Instance.RemoteEventRepeater.Dispatch(notifiedEvent.ApplicationEvent, notifiedEvent.DomainObject);
            }
        }
    }
}
