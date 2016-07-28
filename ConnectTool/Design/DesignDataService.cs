using System;
using ConnectTool.Helpers.Interface;
using ConnectTool.Model;
using ConnectTool.Model.PopupMassage;

namespace ConnectTool.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }

        public void GetPopupMessage(Action<IPopupMessage, Exception> callback)
        {
            // Use this to connect to the actual data service
            var popupmessage = new DefaultPopup() { Message = "Sondre Fingann har ræven full av penger samt andre gjenstander og " };
            callback(popupmessage, null);
        }
    }
}