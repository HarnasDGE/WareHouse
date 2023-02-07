
using System;
using System.Data;
using System.Text;

namespace Lager.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? BirthdayDate { get; set; }
        public string? DataBegin { get; set; }
        public string? Hours { get; set; }
        public int Points { get; set; }
        public string? Price { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Address: {Address}";

        public string OfficialView()
        {
            StringBuilder sb = new();
            sb.Append($"ID: {Id}".PadRight(8, ' '));
            sb.Append($"Name: {FirstName} {LastName}".PadRight(30, ' '));
            sb.Append($"Begin Work: {DataBegin}".PadRight(20, ' '));

            return sb.ToString();
        }
    }
}
