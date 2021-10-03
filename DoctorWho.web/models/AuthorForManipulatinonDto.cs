using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorWho.web.models
{
    public class AuthorForManipulatinonDto 
    {
        [Required(ErrorMessage = "you should fill out the AuthorName")]
        public string AuthorName { get; set; }

    }
}
