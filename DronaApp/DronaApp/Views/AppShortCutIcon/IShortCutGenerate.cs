using System;
namespace DronaApp
{
    public interface IShortCutGenerate
    {
        void GenerateShortCutOne(string title, string icon, Xamarin.Forms.ImageSource imgSource, string id);

        void GenerateShortCutTwo(string title, string icon, Xamarin.Forms.ImageSource imgSource, string id);

        void RemoveShortcut(string title, string icon, string id);
    }
}
