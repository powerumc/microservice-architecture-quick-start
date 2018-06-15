using System;

namespace Powerumc.RssFeeds
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RegisterAttribute : Attribute
    {
        public Type RegistrationType { get; }

        public RegisterAttribute(Type registrationType)
        {
            this.RegistrationType = registrationType;
        }
    }
}