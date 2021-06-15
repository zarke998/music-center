using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.DTO
{
    public class UseCaseLogDto
    {
        public DateTime CreatedAt { get; set; }
        public int UseCaseId { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }

        public int UserId { get; set; }
    }
}
