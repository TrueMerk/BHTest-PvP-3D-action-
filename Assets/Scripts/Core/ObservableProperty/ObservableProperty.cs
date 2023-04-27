using System;

namespace Core.ObservableProperty
{
    public class ObservableProperty<T>
    {
        private T _value;

        public event Action<T> OnChange;
        
        public ObservableProperty()
        {
            
        }

        public ObservableProperty(T value)
        {
            SetValueWithoutNotify(value);
        }

        public void SetValue(T value)
        {
            _value = value;
            OnChange?.Invoke(value);
        }

        public T GetValue()
        {
            return _value;
        }

        public void SetValueWithoutNotify(T value)
        {
            _value = value;
        }
        
    }
}