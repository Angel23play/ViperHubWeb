﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViperHub.Application.Dto.Tournaments
{
    public class TorneoResponse
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserId { get; set; }
    }
}
