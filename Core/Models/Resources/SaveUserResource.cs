using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DVideo.Core.Models.Resources
{
    public class SaveUserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password {get; set;}
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime RegistrationDate { get; set;}

        public SaveUserResource()
        {
            RegistrationDate = DateTime.Now;
        }
      
    }
}