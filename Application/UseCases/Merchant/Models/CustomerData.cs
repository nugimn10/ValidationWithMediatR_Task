using System;
namespace ValidationWithMediatr_task.Application.UseCases.Customer.Models
{  
    public enum Gender
    {
        Pria = 1,
        Wanita = 0
    }
    public class CustomerData
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string passowrd { get; set; }
        public Gender gender { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }

    public class RequestData<T>
    {
        public Data<T> data { get; set; }
    }

    public class Data<T>
    {
        public T attributes { get; set; }
    }

}