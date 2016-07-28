using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectTool.Helpers.Interface;

namespace ConnectTool.Model
{
    public interface IDataService
    {

        void GetData(Action<DataItem, Exception> callback);
        void GetPopupMessage(Action<IPopupMessage, Exception> callback);
    }
}
