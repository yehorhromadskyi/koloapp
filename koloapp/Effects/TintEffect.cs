using System;
using Xamarin.Forms;

namespace koloapp.Effects
{
    public class TintImage : RoutingEffect
    {
        public Color TintColor { get; private set; }

        public TintImage() : base($"koloapp.{nameof(TintImage)}")
        {
        }
    }
}
