using System;

namespace MiniProfillerPoc.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Complete { get; set; }
    }
}