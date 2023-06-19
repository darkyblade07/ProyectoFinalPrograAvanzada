using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalPrograAvanzada.Entities
{
    public class UserEnt
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool State { get; set; }

        public int IdRole { get; set; }
    }
}