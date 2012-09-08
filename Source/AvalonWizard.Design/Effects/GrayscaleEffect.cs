#region License
// Copyright © Pavel Fedarovich, 2010-2012
// 
// This file is part of AvalonWizard.
//  
// You may at your option receive a license to Avalon Wizard under 
// either the terms of the Apache License version 2.0 or 
// the GNU Lesser General Public License (LGPL) version 2.1 or any later version.
//  
// AvalonWizard is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//  
// You may obtain a copy of the Apache License at [http://www.apache.org/licenses/LICENSE-2.0].
// You may obtain a copy of the LGPL at [http://www.gnu.org/licenses/].
#endregion

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
