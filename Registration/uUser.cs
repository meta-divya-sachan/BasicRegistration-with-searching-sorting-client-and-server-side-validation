//------------------------------------------------------------------------------
// <auto-generated>

// </auto-generated>
//------------------------------------------------------------------------------

namespace Registration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class uUser
    {
        [Key]
        
        public int UserId { get; set; }

        [Required(ErrorMessage = "please enter User name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "please enter Mail.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please enter password.")]  
        public string Password { get; set; }
    }
}