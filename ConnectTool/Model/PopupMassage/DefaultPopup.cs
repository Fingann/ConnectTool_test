using System;
using System.Windows.Media;
using ConnectTool.Helpers.Enum;
using ConnectTool.Helpers.Interface;

namespace ConnectTool.Model.PopupMassage
{
    class DefaultPopup : IPopupMessage
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the time span.
        /// </summary>
        /// <value>
        /// The time span, default 3 secounds.
        /// </value>
        public TimeSpan TimeSpan { get; set; } = new TimeSpan(0,0,0,6);
        /// <summary>
        /// Gets or sets the color of the message.
        /// </summary>
        /// <value>
        /// The color of the message.
        /// </value>
        public Color MessageColor { get; set; } = Color.FromRgb(0,202,104);

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category, default is Info.
        /// </value>
        public PopupMessageCategory Category { get; set; } = PopupMessageCategory.Info;

        public bool ShowButton { get; set; } = true;
    }
}
