﻿using System;
using System.Text;
using addressbook_web_tests.AppManager;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class AutoTestBase
    {
        protected ApplicationManager Application;

        [SetUp]
        public void SetupApplicationManager()
        {
            Application = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int maxLength)
        {
            var length = Convert.ToInt32(rnd.NextDouble() * maxLength);
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }

            return stringBuilder.ToString();
        }
    }
}