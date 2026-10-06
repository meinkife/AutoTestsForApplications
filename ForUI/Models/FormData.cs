using AutoTestsForApplications.ForUI.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTestsForApplications.ForUI.Models
{
    public class FormData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Mobile { get; set; }
        public string Days { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Hobbies Hobby { get; set; }
        public string Subject { get; set; }
        public string CurrentAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}