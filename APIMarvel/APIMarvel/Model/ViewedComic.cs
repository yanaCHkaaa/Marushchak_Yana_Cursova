using System;
using System.Collections.Generic;

namespace APIMarvel.Model
{
    public partial class ViewedComic
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ComicId { get; set; }
    }
}
