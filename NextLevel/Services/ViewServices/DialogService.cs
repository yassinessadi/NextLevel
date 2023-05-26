using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace NextLevel.Services.ViewServices
{
    public class DialogService : IDialogService
    {
        public void MakeText(string message)
        {
            Toast.Make(message, ToastDuration.Long).Show();
        }
    }
}
