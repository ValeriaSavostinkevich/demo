﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.Models
{
    public class User
    {
        public string LastName { get; set; }
        public string BookingReference { get; set; }

        public User(string lastName, string bookingReference)
        {
            this.LastName = lastName;
            this.BookingReference = bookingReference;
        }
    }
}
