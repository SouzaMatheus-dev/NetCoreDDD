using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancarias.Domain.Models
{
    public abstract class Notifiable<T> where T : Notification
    {
        public abstract void Validate();
    }
}