﻿namespace TechnicalTest.Models.Responses
{
    public class GenericCrud
    {
        public bool Success { get; set; }
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string Exception { get; set; } = "";
    }
}
