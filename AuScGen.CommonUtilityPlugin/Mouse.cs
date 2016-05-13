using MouseKeyboardLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.CommonUtilityPlugin
{
    public class Mouse
    {
        public static void WheelUp(int delta)
        {
            MouseSimulator.MouseWheel(delta);
        }

        public static void Hover(Point point)
        {
            MouseSimulator.Position = point;
        }
    }
}
