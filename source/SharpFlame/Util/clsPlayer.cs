#region

using System;
using SharpFlame.Colors;
using SharpFlame.Core.Domain.Colors;

#endregion

namespace SharpFlame.Util
{
    public class clsPlayer
    {
        public SRgb Colour;
        public SRgb MinimapColour;

        public void CalcMinimapColour()
        {
            MinimapColour.Red = Math.Min(Colour.Red * 0.6666667F + 0.333333343F, 1.0F);
            MinimapColour.Green = Math.Min(Colour.Green * 0.6666667F + 0.333333343F, 1.0F);
            MinimapColour.Blue = Math.Min(Colour.Blue * 0.6666667F + 0.333333343F, 1.0F);
        }
    }
}