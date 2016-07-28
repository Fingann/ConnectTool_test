using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ConnectTool.Helpers.Enum;

namespace ConnectTool.Helpers.Interface
{
    public interface IPopupMessage
    {

        string Message { get; set; }

        TimeSpan TimeSpan { get; set; }

        Color MessageColor { get; set; }

       PopupMessageCategory Category { get; set; }
        bool ShowButton { get; set; }
       

    }
}
