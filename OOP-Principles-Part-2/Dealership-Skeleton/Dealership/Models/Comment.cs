using System;
using System.Text;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get { return this.content; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 300)
                {
                    throw new ArgumentException("Content must be between 3 and 200 characters long!");
                }

                this.content = value;
            }
        }
        public string Author { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("    ----------");
            result.AppendLine($"    {this.Content}");
            result.AppendLine($"      User: {this.Author}");
            result.AppendLine("    ----------");

            return result.ToString();
        }
    }
}