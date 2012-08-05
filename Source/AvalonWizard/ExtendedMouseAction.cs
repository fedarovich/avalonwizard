using System.Windows.Input;

namespace AvalonWizard
{
    internal enum ExtendedMouseAction : byte
    {
        None = MouseAction.None,

        LeftClick = MouseAction.LeftClick,
        
        RightClick = MouseAction.RightClick,

        MiddleClick = MouseAction.MiddleClick,

        WheelClick = MouseAction.WheelClick,

        LeftDoubleClick = MouseAction.LeftDoubleClick,
        
        RightDoubleClick = MouseAction.RightDoubleClick,

        MiddleDoubleClick = MouseAction.MiddleDoubleClick,

        XButton1Click,

        XButton2Click
    }
}
