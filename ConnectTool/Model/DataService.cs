using System;
using ConnectTool.Helpers.Interface;
using ConnectTool.Model.LogWatcher;
using ConnectTool.Model.PopupMassage;

namespace ConnectTool.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public void GetCall(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service
            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public void GetApplicationSettings(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service
            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }
        public void GetPopupMessage(Action<IPopupMessage, Exception> callback)
        {
            // Use this to connect to the actual data service
            var popupmessage = new DefaultPopup() { Message = "Sondre Fingann" };
            callback(popupmessage, null);
        }



    }
}