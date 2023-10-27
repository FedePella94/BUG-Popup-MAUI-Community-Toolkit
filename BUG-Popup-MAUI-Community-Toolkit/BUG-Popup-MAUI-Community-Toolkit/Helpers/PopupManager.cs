using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Shapes;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using Microsoft.Maui;
using System.Reflection;

namespace BUG_Popup_MAUI_Community_Toolkit
{
    public class PopupManager : IPopupManager
    {
        public async Task ShowPopup(Popup popup) //implementare la gestione dell'errore
        {
            try
            {
                Page page = new();
                if (Application.Current?.MainPage?.Navigation?.ModalStack?.Count == 1)
                {
                    page = Application.Current?.MainPage?.Navigation?.ModalStack[0] ?? throw new NullReferenceException();
                }
                else
                {
                    page = Application.Current?.MainPage ?? throw new NullReferenceException();
                }
                await page.ShowPopupAsync(popup);
            }
            catch (Exception)
            {
                throw new Exception("Errore nella creazione del popup");
            }
            
        }
        

        #region BASIC_POPUP
        public async Task ShowOkPopupAsync(string message, Action<object, bool> popupResultHandler, bool canBeDismissed)
        {
            var buttonOk = new Button
            {
                WidthRequest = 150,
                Margin = new Thickness(6),
                VerticalOptions = LayoutOptions.End,
                Text = "OK",
            };
            buttonOk.Clicked += (sender, args) => popupResultHandler(sender, true);

            var popup = new Popup
            {
                Content = new VerticalStackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    WidthRequest = 300,
                    HeightRequest = 300,
                    Children =
                    {
                        new Label //spacing label
                        {
                            HeightRequest= 5,
                            Text = ""
                        },
                        new Image
                        {
                            Source = "info.png",
                            HeightRequest = 150,
                            WidthRequest = 150,
                            Margin = new Thickness(0, 0, 8, 0)
                        },
                        new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            Margin = new Thickness(12),
                            TextColor = Color.Parse("Blue"),
                            FontSize = 12,
                            Text = message
                        },
                        new Label //spacing label
                        {
                            HeightRequest= 5,
                            Text = ""
                        },
                        buttonOk
                    }
                },
                CanBeDismissedByTappingOutsideOfPopup = canBeDismissed
            };

            await ShowPopup(popup);
        }

        #endregion
        

    }
}
