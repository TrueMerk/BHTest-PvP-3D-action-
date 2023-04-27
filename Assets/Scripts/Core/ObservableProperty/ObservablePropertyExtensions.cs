using TMPro;

namespace Core.ObservableProperty
{
    public static class ObservablePropertyExtensions
    {
        public static void AttachToText<T>(this ObservableProperty<T> property, TMP_Text text)
        {
            property.OnChange += OnChange;

            OnChange(property.GetValue());
            void OnChange(T value)
            {
                text.text = value.ToString();
            }
        }
    }
}