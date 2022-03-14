using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel() { }
        public LoginViewModel(string username, string password,bool remember = false ) 
        {
            Username = username;
            Password = password;
            RememberMe = remember;
        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
