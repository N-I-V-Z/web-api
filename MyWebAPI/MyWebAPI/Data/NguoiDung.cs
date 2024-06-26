﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Data
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int Id { get; set; }
        public string UserName {  get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        public string HoTen {  get; set; }
        public string Email {  get; set; }
    }
}
