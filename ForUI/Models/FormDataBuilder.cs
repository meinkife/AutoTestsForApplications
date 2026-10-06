using AutoTestsForApplications.ForUI.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTestsForApplications.ForUI.Models
{
    public class FormDataBuilder
    {
        private FormData _data = new FormData();

        public FormDataBuilder WithFirstName(string value)
        {
            _data.FirstName = value;
            return this;
        }

        public FormDataBuilder WithLastName(string value)
        {
            _data.LastName = value;
            return this;
        }

        public FormDataBuilder WithEmail(string value)
        {
            _data.Email = value;
            return this;
        }
        public FormDataBuilder WithGender(Gender value)
        {
            _data.Gender = value;
            return this;
        }
        public FormDataBuilder WithHobbies(Hobbies value)
        {
            _data.Hobby = value;
            return this;
        }

        public FormDataBuilder WithDays(string value)
        {
            _data.Days = value;
            return this;
        }

        public FormDataBuilder WithMonth(string value)
        {
            _data.Month = value;
            return this;
        }
        public FormDataBuilder WithYear(string value)
        {
            _data.Year = value;
            return this;
        }
        public FormDataBuilder WithMobile(string value)
        {
            _data.Mobile = value;
            return this;
        }
        public FormDataBuilder WithSubject(string value)
        {
            _data.Subject = value;
            return this;
        }
        public FormDataBuilder WithCurrentAddress(string value)
        {
            _data.CurrentAddress = value;
            return this;
        }

        public FormDataBuilder WithState(string value)
        {
            _data.State = value;
            return this;
        }
        public FormDataBuilder WithCity(string value)
        {
            _data.City = value;
            return this;
        }
        public FormData Build()
        {
            return _data;
        }
    }

}