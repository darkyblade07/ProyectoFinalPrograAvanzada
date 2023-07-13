using Newtonsoft.Json;
using ProyectoFinalPrograAvanzada.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace ProyectoFinalPrograAvanzada.Model
{
    public class UserModel
    {
        public UserEnt IniciarSesion (UserEnt entidad)
        {
            using (var client = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlApi"].ToString()+"api/IniciarSesion";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<UserEnt>().Result;

                }
                return null;

            }
        }


        public int RegistrarUsuario(UserEnt entidad)
        {
            using (var client = new HttpClient())
            {

                
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() +"api/RegistrarUsuario";
                JsonContent body = JsonContent.Create(entidad); 
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

    }
}