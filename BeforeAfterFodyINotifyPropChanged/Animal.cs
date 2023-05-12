using System;
using System.ComponentModel;
using System.Diagnostics;


namespace BeforeAfterFodyINotifyPropChanged;

public class Animal : INotifyPropertyChanged
{
    public Animal()
    {
        PropertyChanged += delegate (object? sender, PropertyChangedEventArgs args)
        {
            Debug.WriteLine($"{args.PropertyName}");
        };
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    public string Name { get; set; }

    public void OnPropertyChanged(string propertyName, object before, object after)
    {
        Debug.WriteLine($"{before}:{after}");
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public static class PropertyChangedNotificationInterceptor
{
    public static void Intercept(object target, Action onPropertyChangedAction,
        string propertyName, object before, object after)
    {
        onPropertyChangedAction();
    }
}

