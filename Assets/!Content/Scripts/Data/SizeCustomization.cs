namespace FlippyPong.Customization
{
    public class SizeCustomization : ICustomizationData
    {
        public readonly float Size;
        
        public SizeCustomization(float size)
        {
            Size = size;
        }
    }
}
