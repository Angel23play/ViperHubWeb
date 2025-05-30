﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Application.Core;
using ViperHub.Domain.Models;

namespace ViperHub.Application.Interfaces.Service
{
    public interface IUsuarioContract : BaseEntity<Usuario>
    {
     
            Task<bool> VerifyPassword(Usuario user, string password);
            Task<string> ChangePassword(Usuario user, string newPassword);
          



    }
}
