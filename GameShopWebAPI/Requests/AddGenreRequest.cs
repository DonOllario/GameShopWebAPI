﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.Requests
{
    public class AddGenreRequest
    {
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
