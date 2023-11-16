using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Dialogs.Internal;
using AvaloniaTestApp.ViewModels;

namespace AvaloniaTestApp
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if(param is null)
            {
                return new TextBlock{ Text = "ViewLocator: Data was null." };
            }
            string name = param.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);
            if(type is not null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock{ Text = "ViewLocator: Not Found "+ name};
            }
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
