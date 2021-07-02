﻿namespace Net6Demo.Web.MiniApi.Models
{
    public record TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
