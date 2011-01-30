#region Licence
// This file is part of AvalonWizard.
// 
// AvalonWizard is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AvalonWizard is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with AvalonWizard.  If not, see <http://www.gnu.org/licenses/>.
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AvalonWizard.Design.Effects
{
    public class GrayscaleEffect : ShaderEffect
    {
        public GrayscaleEffect()
        {
            PixelShader = new PixelShader() {UriSource = ResourceHelper.GetEffectUri("Grayscale.ps")};
            UpdateShaderValue(InputProperty);
            //UpdateShaderValue(DesaturationFactorProperty);
        }

        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0);
        
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        //public static readonly DependencyProperty DesaturationFactorProperty = 
        //    DependencyProperty.Register("DesaturationFactor", typeof(double), typeof(GrayscaleEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), CoerceDesaturationFactor));
        
        //public double DesaturationFactor
        //{
        //    get { return (double)GetValue(DesaturationFactorProperty); }
        //    set { SetValue(DesaturationFactorProperty, value); }
        //}

        //protected static object CoerceDesaturationFactor(DependencyObject d, object value)
        //{
        //    var effect = (GrayscaleEffect)d;
        //    double newDesatFactor = (double)value;

        //    if (newDesatFactor < 0.0 || newDesatFactor > 1.0)
        //    {
        //        return effect.DesaturationFactor;
        //    }

        //    return newDesatFactor;
        //}
    }
}
