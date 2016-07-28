using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Navigation;
using ConnectTool.Helpers.Interface;
using ConnectTool.Helpers.Messenges;
using ConnectTool.Model.PopupMassage;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace ConnectTool.Model.LogWatcher
{



    /// <summary>
    /// CallWatcher class is the main class for Capturing log events. 
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class CallWatcher : ViewModelBase , IDisposable
    {
        #region Functions
        /// <summary>
        /// Function to check if a string is a JsonObject
        /// </summary>
        private static readonly Func<string, bool> IsJsonObject = x =>
        {
            try
            {
                JToken.Parse(x);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        };
        #endregion Functions

        #region Variable

       
        private Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IDataService _dataService;

        /// <summary>
        /// The log folder path
        /// </summary>
        public readonly string LogFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                               @"\Intelecom Group AS\Intelecom Connect\Logs";

        /// <summary>
        /// The log path
        /// </summary>
        public readonly string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                         @"\Intelecom Group AS\Intelecom Connect\Logs\All.txt";

        public WatcherEx Watcher;


        public DateTime LastchangeDateTime = DateTime.MinValue;
        public int nummeration { get; set; } = 0;


        #endregion Variable


        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CallWatcher"/> class.
        /// </summary>
        public CallWatcher(IDataService dataService)
        {
            MessengerInstance.Register<NotificationMessage<CallWatcherMesseage>>(this, NotifyMe);
            //_dataService = dataService;
            //_dataService.GetData(
            //    (item, error) =>
            //    {
            //        if (error != null)
            //        {
            //            // Report error here
            //            return;
            //        }
                   
                    
            //    });


            WatcherInfo info = new WatcherInfo
            {
                ChangesFilters = NotifyFilters.LastWrite, //NotifyFilters.DirectoryName |NotifyFilters.LastAccess 
                IncludeSubFolders = false,
                WatchesFilters = WatcherChangeTypes.Changed,
                WatchForDisposed = true,
                WatchForError = false,
                WatchPath = LogFolderPath,
                FileFilter = "*.txt",
                BufferKBytes = 8
            };


            Watcher = new WatcherEx(info);
            ManageEventHandlers(true);
            Start();

        }

        private void NotifyMe(NotificationMessage<CallWatcherMesseage> obj)
        {
            if (obj.Content.Start)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        #endregion Constructor

        #region Controls
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            logger.Trace("CallWatcher started");
            Watcher.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            logger.Trace("Filewatcher Stoped");
            Dispose();
        }
        #endregion Controls



        #region EventHandlers
        //--------------------------------------------------------------------------------
        /// <summary>
        /// Toggles the Watcher event handlers on/off
        /// </summary>
        /// <param name="add"></param>
        private void ManageEventHandlers(bool add)
        {
            // individual handler for each type of change event if you desire.
            if (Watcher == null) return;
            if (add)
            {
                //watcher.EventChangedAttribute += new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedCreationTime += new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedDirectoryName += new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedFileName += new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedLastAccess += new WatcherEventHandler(fileWatcher_EventChanged);
                Watcher.EventChangedLastWrite += WatcherOnEventChangedLastWrite;
                //new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedSecurity += new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedSize += new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventCreated += new WatcherEventHandler(fileWatcher_EventCreated);
                //watcher.EventDeleted += new WatcherEventHandler(fileWatcher_EventDeleted);
                //watcher.EventDisposed += new WatcherEventHandler(fileWatcher_EventDisposed);
                //watcher.EventError += new WatcherEventHandler(fileWatcher_EventError);
                //watcher.EventRenamed += new WatcherEventHandler(fileWatcher_EventRenamed);
            }
            else
            {
                //watcher.EventChangedAttribute -= new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedCreationTime -= new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedDirectoryName -= new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedFileName -= new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedLastAccess -= new WatcherEventHandler(fileWatcher_EventChanged);
                Watcher.EventChangedLastWrite -= WatcherOnEventChangedLastWrite;
                //watcher.EventChangedSecurity -= new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventChangedSize -= new WatcherEventHandler(fileWatcher_EventChanged);
                //watcher.EventCreated -= new WatcherEventHandler(fileWatcher_EventCreated);
                //watcher.EventDeleted -= new WatcherEventHandler(fileWatcher_EventDeleted);
                //watcher.EventDisposed -= new WatcherEventHandler(fileWatcher_EventDisposed);
                //watcher.EventError -= new WatcherEventHandler(fileWatcher_EventError);
                //watcher.EventRenamed -= new WatcherEventHandler(fileWatcher_EventRenamed);
            }
        }


        private void WatcherOnEventChangedLastWrite(object sender, WatcherExEventArgs watcherExEventArgs)
        {
            var arguments = (FileSystemEventArgs)watcherExEventArgs.Arguments;

            //checks if the changed path is the same as out logfile 
            if (arguments.FullPath != LogPath)
                return;

            //get the current time
            var now = DateTime.Now;

            //get the last time the file was written to
            var lastWriteTime = File.GetLastWriteTime(arguments.FullPath);


            if (now == lastWriteTime)
                return;
            

            if (lastWriteTime == LastchangeDateTime)
                return;


            //Get the last line of the file 
            var jsonCaller = ReadLines(LogPath).Reverse().FirstOrDefault();

            ProcessLines(jsonCaller);







            nummeration++;
            LastchangeDateTime = lastWriteTime;
        }

        #endregion EventHandlers

     
      

     





        /// <summary>
        ///     Processes the lines from the log file.
        /// </summary>
        /// <param name="lastLines">The last lines.</param>
        private void ProcessLines(string lastLinesInLog)
        {
            if (string.IsNullOrEmpty(lastLinesInLog))
                return;

            if (!IsJsonObject(lastLinesInLog))
                return;

           

            var currentCaller = new Call();

            try
            {
                
                currentCaller = JsonConvert.DeserializeObject<Call>(lastLinesInLog);

            }
            catch (JsonReaderException ex)
            {
                logger.Warn("ProcessLines could not Convert logline to Json: " + lastLinesInLog, ex);
                return;
            }
            catch (ArgumentNullException ex)
            {
                logger.Warn("ProcessLines could not convert logline to Json becasue its null ", ex);

                return;
            }


           
            //sorting the caller 
            SortCaller(currentCaller);
            
            
           
        }

        private void SortCaller(Call currentCaller)
        {
            switch (currentCaller.system_call_progress)
            {
                case "SETUP":
                   logger.Info("CALL_Progress: SETUP -> Sennding new caller via Notification:" + currentCaller.ToString());
                    //MessengerInstance.Send(new NotificationMessage<Call>(currentCaller, "New Call detected"));
                    var popupmessage = new DefaultPopup() {Message =  currentCaller.popup_name};
                    MessengerInstance.Send(new NotificationMessage<IPopupMessage>(popupmessage, "New Call detected"));



                    break;

                case "ALERTING":
                    logger.Trace("CALL_Progress: ALERTING -> " + currentCaller.ToString());

                    break;
                case "CONNECTED":
                    logger.Trace("CALL_Progress: CONNECTED -> " + currentCaller.ToString());

                    break;
                case "HANGUP":
                    logger.Trace("CALL_Progress: HANGUP -> " + currentCaller.ToString());
                    break;
                case "NOANSWER":
                    logger.Trace("CALL_Progress: NOANSWER -> " + currentCaller.ToString());
                    break;
                //case "AgentPauseOff":
                //    Console.WriteLine(5);
                //    break;
                //case "AgentLogoff":
                //    Console.WriteLine(5);
                //    break;
                default:
                    logger.Trace("DEFAULT -> Could not find a CALL_Progress" + currentCaller.ToString());
                    break;
            }
        }

        #region ReadMethod

        /// <summary>
        /// Reads the lines of the log file and yeild the return .
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static IEnumerable<string> ReadLines(string path)
        {
            using (
                var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000,
                    FileOptions.SequentialScan))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false) /*Encoding.GetEncoding("ISO-8859-1")*/))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        #endregion ReadMethod

        #region Disposing

        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        ~CallWatcher()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ManageEventHandlers(false);
                Watcher.Dispose();
                Watcher = null;
            logger.Trace("Disposing CallWatcher");
        }
            // free native resources if there are any.
         
        }

        #endregion Disposing
    }
}



