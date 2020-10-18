namespace FlippyPong.Customization
{
    public interface ICustomizable<in T> where T : ICustomizationData
    {
        void Apply(T data);
    }
}