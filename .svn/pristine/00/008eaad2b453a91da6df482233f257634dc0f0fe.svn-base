using System;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Utility
{
    /// <summary>
    ///     A Domain object specific event args, allowing a domain object
    ///     to be passed around within the event
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class DomainEventArgs<T> : EventArgs where T : DomainObject
    {
        public DomainEventArgs(T selectedDomainObject)
            : this(selectedDomainObject, ApplicationEvent.None)
        {
        }

        public DomainEventArgs(ApplicationEvent applicationEventType) : this(null, applicationEventType)
        {
        }

        public DomainEventArgs(DomainObject selectedDomainObject)
            : this(selectedDomainObject != null ? selectedDomainObject as T : default(T))
        {
        }

        public DomainEventArgs(T selectedDomainObject, ApplicationEvent applicationEventType)
        {
            SelectedItem = selectedDomainObject;
            ApplicationEventType = applicationEventType;
        }

        public T SelectedItem { get; private set; }

        public ApplicationEvent ApplicationEventType { get; private set; }

        public string SelectedItemIdAsString
        {
            get
            {
                try
                {
                    if (SelectedItem == null)
                    {
                        return "null domain object";
                    }
                    if (!SelectedItem.Id.HasValue)
                    {
                        return "null id";
                    }
                    return SelectedItem.Id.Value.ToString(CultureInfo.InvariantCulture);
                }
                catch (Exception e)
                {
                    return "error getting id: " + e;
                }
            }
        }
    }
}