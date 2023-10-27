using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUG_Popup_MAUI_Community_Toolkit
{
    public interface IPopupManager
    {
        Task ShowPopup(Popup popup);
        Task ShowOkPopupAsync(string message, Action<object, bool> popupResultHandler, bool canBeDismissed);
    }
}
