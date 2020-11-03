using EnvWindows2.Données;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.NetworkOperators;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EnvWindows2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        String login;
        String mdp;
        Dictionnaire bdd = new Dictionnaire();        

        public MainPage()
        {
            bdd.chargementDictionnaire();
            this.InitializeComponent();
        }

        private void Login_Changed(object sender,  TextChangedEventArgs e)
        {
            login = InputLogin.Text;
        }

        private void Password_Changed(object sender, RoutedEventArgs e)
        {
            mdp = InputPassword.Password;
        }

        private void BoutonValider_Click(object sender, RoutedEventArgs e)
        {
            LoginStatusDialog(login, mdp);
        }

        private async void LoginStatusDialog(String login, String mdp)
        {
            String content;

            if(bdd.checkCredentials(login,mdp))
            {
                content = "Vous êtes connecté";
            }
            else
            {
                content = "Erreur de login";
            }

            ContentDialog dialog = new ContentDialog
            {
                Title = "Exercice 2",
                Content = content,
                CloseButtonText = "OK"
            };

            ContentDialogResult result = await dialog.ShowAsync();
        }
    } 
}
