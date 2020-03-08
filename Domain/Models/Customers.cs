using System;
namespace ValidationWithMediatr_task.Domain.Models
{  
    public enum Gender
    {
            male = 1,
            female
    }
    public class CustomerD
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string passowrd { get; set; }
        public Gender gender { get; set; }
        public string kelamin { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }


}