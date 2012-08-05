using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using AvalonWizard.Extensions;

namespace AvalonWizard
{
    internal class ExtendedMouseGesture : MouseGesture
    {
        private readonly ExtendedMouseAction extendedMouseAction;

        public ExtendedMouseGesture(ExtendedMouseAction mouseAction) : 
            this(mouseAction, ModifierKeys.None)
        {
        }

        public ExtendedMouseGesture(ExtendedMouseAction mouseAction, ModifierKeys modifiers)
            : base(ConvertExtendedMouseAction(mouseAction), modifiers)
        {
            extendedMouseAction = mouseAction;
        }

        public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
        {
            var action = GetExtendedMouseAction(inputEventArgs);
            if (action != null && extendedMouseAction == action.Value)
            {
                return Modifiers == Keyboard.Modifiers;
            }
            return base.Matches(targetElement, inputEventArgs);
        }

        private static MouseAction ConvertExtendedMouseAction(ExtendedMouseAction action)
        {
            return action.In(ExtendedMouseAction.XButton1Click, ExtendedMouseAction.XButton2Click)
                       ? MouseAction.None
                       : (MouseAction) action;
        }

        private static ExtendedMouseAction? GetExtendedMouseAction(InputEventArgs inputEventArgs)
        {
            var mouseButtonEventArgs = inputEventArgs as MouseButtonEventArgs;
            if (mouseButtonEventArgs != null)
            {
                switch (mouseButtonEventArgs.ChangedButton)
                {
                    case MouseButton.XButton1:
                        return ExtendedMouseAction.XButton1Click;
                    case MouseButton.XButton2:
                        return ExtendedMouseAction.XButton2Click;
                }
            }
            return null;
        }
    }
}
