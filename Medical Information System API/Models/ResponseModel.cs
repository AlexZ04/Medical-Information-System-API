using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class ResponseModel
    {
        [AllowNull]
        public string? Status { get; set; }
        [AllowNull]
        public string? Message { get; set; }

        public ResponseModel(string status, string message) {
            Status = status;
            Message = message;
        }
    }
}
