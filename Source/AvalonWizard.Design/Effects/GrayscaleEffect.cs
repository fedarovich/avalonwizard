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
