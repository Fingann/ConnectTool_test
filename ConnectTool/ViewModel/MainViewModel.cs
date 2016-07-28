using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ConnectTool.Dialogs.View;
using ConnectTool.Helpers.Interface;
using GalaSoft.MvvmLight;
using ConnectTool.Model;
using ConnectTool.Model.LogWatcher;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro.Controls.Dialogs;
using NLog;

namespace ConnectTool.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;


        private Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public int inter = 0;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDialogCoordinator dialogCoordinator, IDataService dataService )//
        {
            //Message Regiser
            MessengerInstance.Register<NotificationMessage<Call>>(this, CallNotify);
            MessengerInstance.Register<NotificationMessage<IPopupMessage>>(this, NotifyPopupMessage);

            Messenger.Default.Register<string>(this, ProcessMessage);

            _dialogCoordinator = dialogCoordinator;
            _dataService = dataService;


            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }
                    inter++;
                  
                    WelcomeTitle = inter.ToString();
                });

            _dataService.GetPopupMessage(
             (item, error) =>
             {
                 if (error != null)
                 {
                        // Report error here
                        return;
                 }
                 inter++;

                 PopupMessage = item;
             });
            TestDialogServiceCommand = new RelayCommand(async () =>
            {
                var result = await _dialogCoordinator.ShowMessageAsync(this, "Teste", "Teste", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings
                {
                    AffirmativeButtonText = "OK",
                    NegativeButtonText = "CANCELAR",
                    AnimateShow = true,
                    AnimateHide = false
                    
                });

                var test = "loloasd";

            });

        }

        public RelayCommand TestDialogServiceCommand { get; set; }


        #region Message Notification
        private void NotifyPopupMessage(NotificationMessage<IPopupMessage> obj)
        {
            PopupMessage = obj.Content;
            logger.Info("IpopupMessage Recived -> Message: {2} - Displayed: {0} Secounds - Color: {1}",
                PopupMessage.TimeSpan.Seconds, PopupMessage.MessageColor, PopupMessage.Message);
            DispatcherHelper.CheckBeginInvokeOnUI(ShowMessage);

        }

        
        private void CallNotify(NotificationMessage<Call> obj)
        {
            inter++;

            WelcomeTitle = inter.ToString();
           // WelcomeTitle = obj.Content.popup_name;
        }


        #endregion Message Notification


        #region Dialogs
        private readonly IDialogCoordinator _dialogCoordinator;
        private readonly DialogView _dialogView = new DialogView();

        private string _dialogResult;
        public string DialogResult
        {
            get { return _dialogResult; }
            set
            {
                if (_dialogResult == value)
                {
                    return;
                }
                _dialogResult = value;
                RaisePropertyChanged();
            }
        }
        private RelayCommand _showDialogCommand;
        public RelayCommand ShowDialogCommand => _showDialogCommand
                                                 ?? (_showDialogCommand = new RelayCommand(ShowDialog));

        private async void ShowDialog()
        {
            await _dialogCoordinator.ShowMetroDialogAsync(this, _dialogView);
        }

        private async void ProcessMessage(string messageContents)
        {
            DialogResult = messageContents;
            await _dialogCoordinator.HideMetroDialogAsync(this, _dialogView);
        }
        #endregion Dialogs

        #region IpopupMessage

        private RelayCommand _hideErrorMessageCommand;

        /// <summary>
        /// Gets the hide error message command.
        /// </summary>
        /// <value>
        /// The hide error message command.
        /// </value>
        public RelayCommand HideErrorMessageCommand => _hideErrorMessageCommand
                                              ?? (_hideErrorMessageCommand = new RelayCommand(
                                                  () =>
                                                  {
                                                      MessageVisible = false;
                                                  }));

        private IPopupMessage _popupMessage;

        /// <summary>
        /// Gets or sets the popup message.
        /// </summary>
        /// <value>
        /// The popup message.
        /// </value>
        public IPopupMessage PopupMessage
        {
            get { return _popupMessage; }
            set
            {
                _popupMessage = value;
                RaisePropertyChanged();
            }
        }



        private bool _messageVisible = false;

        /// <summary>
        /// Gets or sets a value indicating whether [error visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [error visible]; otherwise, <c>false</c>.
        /// </value>
        public bool MessageVisible
        {
            get { return _messageVisible; }
            set
            {
                _messageVisible = value;
                RaisePropertyChanged();
            }
        }



        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="Message">The message.</param>
        protected void ShowMessage()
        {

            MessageVisible = true;
            if (PopupMessage.TimeSpan > TimeSpan.Zero)
                HideErrorMessageAfter(PopupMessage.TimeSpan);
        }

        /// <summary>
        /// Hides the error message after a given time.
        /// </summary>
        /// <param name="delayTime">The delay time.</param>
        protected async void HideErrorMessageAfter(TimeSpan delayTime)
        {
            await Task.Delay(delayTime);
            MessageVisible = false;
        }


        #endregion IpopupMessage

        #region FlyOuts



        private bool _isFlyoutOpen;
        public bool IsFlyoutOpen
        {
            get { return _isFlyoutOpen; }
            set
            {
                _isFlyoutOpen = value;
                RaisePropertyChanged();
            }
        }


        public ICommand OpenFlyoutCommand { get { return new RelayCommand(() => IsFlyoutOpen = true); } }
        public ICommand OpenDialogCommand { get { return new RelayCommand(() => IsFlyoutOpen = true);  } }
        public ICommand OpenProgressDialogCommand {
            get { return new RelayCommand(() => IsFlyoutOpen = true); }
        } }

   
        #endregion Flyouts

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
