using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Containers
{
    public class ContainerExtensionPoint : ExtensionPoint<IContainer>
    {
        private readonly ContentType contentType;

        public ContainerExtensionPoint(IContainer value, ContentType contentType)
            : base(value)
        {
            this.contentType = contentType;
        }

        public ContentType ContentType
        {
            get { return contentType; }
        }
    }
}