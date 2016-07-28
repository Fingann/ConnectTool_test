using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace ConnectTool.Dialogs.ViewModel
{
   
        /// <summary>
        /// This class contains properties that a View can data bind to.
        /// <para>
        /// See http://www.galasoft.ch/mvvm
        /// </para>
        /// </summary>
        public class DialogViewModel : ViewModelBase
        {
            /// <summary>
            /// Initializes a new instance of the DialogViewModel class.
            /// </summary>
            public DialogViewModel()
            {

            }
            private string _dialogMessage;
            public string DialogMessage
            {
                get { return _dialogMessage; }
                set
                {
                    if (_dialogMessage == value)
                    {
                        return;
                    }
                    _dialogMessage = value;
                    RaisePropertyChanged();
                }
            }
            private RelayCommand _sendMessageCommand;
            public RelayCommand SendMessageCommand
            {
                get
                {
                    return _sendMessageCommand
                           ?? (_sendMessageCommand = new RelayCommand(SendMessage));
                }
            }
            private void SendMessage()
            {
                Messenger.Default.Send(DialogMessage);
            }
        }
    }